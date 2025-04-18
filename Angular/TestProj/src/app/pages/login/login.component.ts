import { HttpClient } from '@angular/common/http';
import { Component, inject } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { Router } from '@angular/router';

@Component({
  selector: 'app-login',
  standalone: true,
  imports: [FormsModule],
  templateUrl: './login.component.html',
  styleUrl: './login.component.css'
})
export class LoginComponent {
  userObj: any = {
    EmailId: '',
    Password: ''
  };
  http = inject(HttpClient);
  router = inject(Router);

  onLogin() {
    //https://freeapi.miniprojectideas.com/api/User/Login
    this.http.post("https://projectapi.gerasim.in/api/UserApp/login", this.userObj).subscribe((res: any) => {
      if (res.result) {
        alert("Login Success");
        localStorage.setItem('loginUser', this.userObj.EmailId)
        localStorage.setItem('myLogInToken', res.data.token);
        this.router.navigateByUrl('dashboard');
      } else {
        alert(res.message);
      }
    })
  }

}
