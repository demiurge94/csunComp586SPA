import { Component, OnInit } from '@angular/core';
import { NgForm } from '@angular/forms';
import { AuthService } from './auth.service';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent implements OnInit {
  invalidLogin: boolean = false; 
  constructor(private authService: AuthService) { }

  ngOnInit(): void {
  }
  login (form: NgForm){
    const credentials = JSON.stringify(form.value); 
    
    this.authService.login(credentials).subscribe((response: any) => {
        const token = (<any>response).token; 
        console.log("token: " + token); 
        localStorage.setItem("jwt", token); 
        this.invalidLogin = false; 
    }, () => this.invalidLogin = true); 
  }
}
