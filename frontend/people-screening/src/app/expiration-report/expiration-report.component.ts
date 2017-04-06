import { Component, OnInit } from '@angular/core';
import { Http } from "@angular/http";
import { Observable } from "rxjs/Observable";
import 'rxjs/add/operator/map';


@Component({
  selector: 'app-expiration-report',
  templateUrl: './expiration-report.component.html',
  styleUrls: ['./expiration-report.component.css']
})
export class ExpirationReportComponent implements OnInit {
  data = [];
  page = 1;

  private innerData = [];
  private skip = 0;
  take = 50;
  totalItems = 0;

  constructor(private http: Http) { }

  ngOnInit() {
    this.http.get('api/employee/report/screening/maxexpiration')
      .map(resp => resp.json())
      .subscribe(data => {
        this.innerData = data;
        this.totalItems = this.innerData.length;
        this.data = this.innerData.slice(0, this.take);
      });
  }

  onPageChange(page: number) {
    this.data = this.innerData.slice((page - 1) * this.take, this.take * page);
  }

}
