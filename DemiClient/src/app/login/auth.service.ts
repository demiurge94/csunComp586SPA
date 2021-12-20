import { HttpClient, HttpErrorResponse, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { EmailValidator } from '@angular/forms';
import { Observable, throwError } from 'rxjs';
import { catchError, map, retry } from 'rxjs/operators'; 
@Injectable({
  providedIn: 'root'
})
export class AuthService {
  isAuthenticated = false;
  token = null; 
  
  constructor(private http: HttpClient) { }

  login(username: string, password: string) {
    return this.http.post<any>('https://demiapi20211220010523.azurewebsites.net/api/Authenticate/Login', {username: username, password: password})
    .pipe(map(user => {
        if (user && user.token) {
          localStorage.setItem("jwt", user.token);
          console.log("token: " + user.token);
          this.isAuthenticated = true; 
          this.token = user.token; 
        }
      }),
      
    );
  }
  

  /*public isAuthenticated(): boolean {
    if(localStorage.getItem('jwt') != null){
      console.log("Is authenticated!");
      return true;
    }
    return false;
  } */
  
  logout(){
    localStorage.removeItem("jwt");
    this.isAuthenticated = false; 
    this.token = null; 
  }
  public isLoggedIn(){
    if (!localStorage.getItem("jwt")){
      return false;
    }
    return true; 
  }
  
  public isNotLoggedIn(){
    if(!localStorage.getItem("jwt")){
      return true;
    }
    return false;
  }

  /*login(credentials: string){
    return this.http.post('https://localhost:44358/api/Authenticate/Login', credentials, {
      headers: new HttpHeaders({
        "content-Type" : "application/json"
      })
    } );
  }*/
  registerUser(userName: string, Email: string, Password: string){
    return this.http.post<any>('https://localhost:44358/api/Authenticate/Register', {username: userName, password: Password, email:Email });
  }
}
export interface Register{
  UserName: string;
  Email : string;
  Password: string;
}