import { HttpClient, HttpClientModule } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.css']
})
export class HomeComponent implements OnInit {
  registerMode: boolean = false;
  users: any;
  constructor(private httpClient: HttpClient) {

  }

  ngOnInit(): void {
    this.getUsers();
  }
  registerToggle() {
    this.registerMode = !this.registerMode;
  }

  getUsers() {
    this.httpClient.get("https://localhost:5001/api/users").subscribe({
      next: response => this.users = response,
      error: error => console.log(error),
      complete: () => { }
    });
  }

  cancelRegisterMode(event: boolean) {
    this.registerMode = event;
  }
}
