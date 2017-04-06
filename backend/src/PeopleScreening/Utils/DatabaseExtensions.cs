using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace PeopleScreening.Utils
{
    public static class DatabaseExtensions
    {
        public static async Task<IEnumerable<TElement>> ExecuteEnumerableAsync<TElement>(this DbContext context, string sqlQuery)
        {
            using (var command = context.Database.GetDbConnection().CreateCommand())
            {
                command.CommandText = sqlQuery;
                if (command.Connection.State != ConnectionState.Open)
                {
                    await command.Connection.OpenAsync();
                }

                var properties = typeof(TElement).GetProperties();
                var ctor = Expression.New(typeof(TElement));

                var list = new List<TElement>();

                using (var reader = await command.ExecuteReaderAsync())
                {
                    var readerParam = Expression.Parameter(typeof(DbDataReader));
                    var readerParamCast = Expression.Convert(readerParam, reader.GetType());
                    var bindings = new List<MemberAssignment>(properties.Length);

                    foreach (var property in properties.Where(x => x.CanWrite))
                    {
                        var valueCall = Expression.Call(
                            readerParamCast,
                            reader.GetType().GetMethod("GetFieldValue").MakeGenericMethod(property.PropertyType),
                            Expression.Call(
                                readerParamCast,
                                reader.GetType().GetMethod("GetOrdinal"), Expression.Constant(property.Name))
                            );

                        bindings.Add(Expression.Bind(property, valueCall));
                    }

                    var newElementExpr = Expression.MemberInit(ctor, bindings);

                    // results in lambda:
                    // new TElement() {Prop = reader.GetValue(reader.GetOrdinal("Prop"))}
                    var creator = Expression.Lambda<Func<DbDataReader, TElement>>(newElementExpr, readerParam).Compile();

                    while (reader.Read())
                    {
                        var element = creator(reader);
                        list.Add(element);
                    }

                    return list;
                }
            }
        }
    }
}