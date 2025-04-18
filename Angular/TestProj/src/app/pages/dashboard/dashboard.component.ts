import { JsonPipe } from '@angular/common';
import { HttpClient } from '@angular/common/http';
import { Component, inject, OnInit } from '@angular/core';

@Component({
  selector: 'app-dashboard',
  standalone: true,
  imports: [JsonPipe],
  templateUrl: './dashboard.component.html',
  styleUrl: './dashboard.component.css'
})
export class DashboardComponent implements OnInit {
  http = inject(HttpClient);
  userList: any[] = [];
  constructor() { }
  ngOnInit(): void {
    this.getAllUsers();
  }
  getAllUsers() {
    this.http.get("https://projectapi.gerasim.in/api/UserApp/GetAllUsers").subscribe((Res: any) => {
      this.userList = Res.data;
    })
  }
}
