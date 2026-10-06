import { Component } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { AuthService } from '../../services/auth.service';
import { LoginRequest } from '../../Models/loginRequest';
import { Router } from '@angular/router';
@Component({
  selector: 'app-login',
  imports: [FormsModule],
  templateUrl: './login.component.html',
  styleUrl: './login.component.css'
})

export class LoginComponent {
  constructor(private authService:AuthService,private router:Router){}
  login():void{
    const request:LoginRequest={
    username:this.username,
    password: this.password
  };
  this.authService.login(request).subscribe({
    next:(response)=>{
      localStorage.setItem("token",response.token);
      this.router.navigate(['/dashboard']);
      console.log("Login Successful");
    },
    error:(err)=>{
      console.log(err);
      
    }
  });
  }
  username="";
  password="";
  
}
  
