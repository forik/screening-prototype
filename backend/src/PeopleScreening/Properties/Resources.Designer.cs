﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace PeopleScreening.Properties {
    using System;
    using System.Reflection;
    
    
    /// <summary>
    ///   A strongly-typed resource class, for looking up localized strings, etc.
    /// </summary>
    // This class was auto-generated by the StronglyTypedResourceBuilder
    // class via a tool like ResGen or Visual Studio.
    // To add or remove a member, edit your .ResX file then rerun ResGen
    // with the /str option, or rebuild your VS project.
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("System.Resources.Tools.StronglyTypedResourceBuilder", "4.0.0.0")]
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
    [global::System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    internal class Resources {
        
        private static global::System.Resources.ResourceManager resourceMan;
        
        private static global::System.Globalization.CultureInfo resourceCulture;
        
        [global::System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode")]
        internal Resources() {
        }
        
        /// <summary>
        ///   Returns the cached ResourceManager instance used by this class.
        /// </summary>
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Advanced)]
        internal static global::System.Resources.ResourceManager ResourceManager {
            get {
                if (object.ReferenceEquals(resourceMan, null)) {
                    global::System.Resources.ResourceManager temp = new global::System.Resources.ResourceManager("PeopleScreening.Properties.Resources", typeof(Resources).GetTypeInfo().Assembly);
                    resourceMan = temp;
                }
                return resourceMan;
            }
        }
        
        /// <summary>
        ///   Overrides the current thread's CurrentUICulture property for all
        ///   resource lookups using this strongly typed resource class.
        /// </summary>
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Advanced)]
        internal static global::System.Globalization.CultureInfo Culture {
            get {
                return resourceCulture;
            }
            set {
                resourceCulture = value;
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to [{&quot;FirstName&quot;:&quot;Phyllis&quot;,&quot;LastName&quot;:&quot;Warren&quot;,&quot;Alias&quot;:&quot;pwarren0@epa.gov&quot;,&quot;TeamName&quot;:&quot;Sales&quot;},
        ///{&quot;FirstName&quot;:&quot;Robert&quot;,&quot;LastName&quot;:&quot;Evans&quot;,&quot;Alias&quot;:&quot;revans1@histats.com&quot;,&quot;TeamName&quot;:&quot;Research and Development&quot;},
        ///{&quot;FirstName&quot;:&quot;Judy&quot;,&quot;LastName&quot;:&quot;Jordan&quot;,&quot;Alias&quot;:&quot;jjordan2@booking.com&quot;,&quot;TeamName&quot;:&quot;Business Development&quot;},
        ///{&quot;FirstName&quot;:&quot;Steve&quot;,&quot;LastName&quot;:&quot;Fowler&quot;,&quot;Alias&quot;:&quot;sfowler3@scribd.com&quot;,&quot;TeamName&quot;:&quot;Sales&quot;},
        ///{&quot;FirstName&quot;:&quot;Judy&quot;,&quot;LastName&quot;:&quot;Allen&quot;,&quot;Alias&quot;:&quot;jallen4@shutterfly.com&quot;,&quot;TeamName&quot;:&quot;Product Management&quot;},
        ///{&quot;Fi [rest of string was truncated]&quot;;.
        /// </summary>
        internal static string FakeEmployees {
            get {
                return ResourceManager.GetString("FakeEmployees", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to [{&quot;Type&quot;:&quot;Home Ing&quot;,&quot;Description&quot;:&quot;Maecenas rhoncus aliquam lacus.&quot;},
        ///{&quot;Type&quot;:&quot;Fix San&quot;,&quot;Description&quot;:&quot;Duis bibendum.&quot;},
        ///{&quot;Type&quot;:&quot;Aerified&quot;,&quot;Description&quot;:&quot;Suspendisse accumsan tortor quis turpis.&quot;},
        ///{&quot;Type&quot;:&quot;Keylex&quot;,&quot;Description&quot;:&quot;Sed ante.&quot;},
        ///{&quot;Type&quot;:&quot;Flowdesk&quot;,&quot;Description&quot;:&quot;Quisque arcu libero, rutrum ac, lobortis vel, dapibus at, diam.&quot;},
        ///{&quot;Type&quot;:&quot;Lotstring&quot;,&quot;Description&quot;:&quot;Quisque porta volutpat erat.&quot;},
        ///{&quot;Type&quot;:&quot;Keylex&quot;,&quot;Description&quot;:&quot;Mauris enim leo, rhoncus sed, vestibulum sit amet, cursus id, turpis [rest of string was truncated]&quot;;.
        /// </summary>
        internal static string FakeScreenings {
            get {
                return ResourceManager.GetString("FakeScreenings", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to with max_expiration
        ///as (
        ///    select p.EmployeeId, s.Type, p.ExpirationDate
        ///    from (
        ///        select 
        ///            EmployeeId,
        ///            ScreeningId,
        ///            ExpirationDate,
        ///            ROW_NUMBER() over (partition by EmployeeId order by ExpirationDate desc) row
        ///        from EmployeeScreening
        ///    ) p
        ///    inner join dbo.ScreeningProcess	s
        ///    on p.ScreeningId = s.Id and p.row = 1
        ///) 
        ///select e.Id
        ///, e.FirstName + &apos; &apos; + e.LastName + &apos;(&apos; + e.Alias + &apos;)&apos; AS Employee
        ///, m.FirstName + &apos; &apos; + m.Las [rest of string was truncated]&quot;;.
        /// </summary>
        internal static string MaxScreeningReportQuery {
            get {
                return ResourceManager.GetString("MaxScreeningReportQuery", resourceCulture);
            }
        }
    }
}