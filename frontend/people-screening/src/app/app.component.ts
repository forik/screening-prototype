import { Component } from '@angular/core';
import { Http } from "@angular/http";

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent {
  title = 'app works!';

  constructor(private http: Http) {

  }

  onSendNotifications() {
    const event = window.event;
    if (event) {
      event.preventDefault();
    }

    this.http.post('api/employee/notifications/expiredscreening', null)
      .subscribe(resp => alert('Notifications sent! Please check logs for results'));
  }
}
