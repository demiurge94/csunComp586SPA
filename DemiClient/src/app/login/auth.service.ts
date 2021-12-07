import { HttpClient, HttpErrorResponse, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable, throwError } from 'rxjs';
import { catchError, map, retry } from 'rxjs/operators'; 
@Injectable({
  providedIn: 'root'
})
export class AuthService {

  constructor(private http: HttpClient) { }

  login(username: string, password: string) {
    return this.http.post<any>('https://localhost:44358/api/Authenticate/Login', {username: username, password: password})
    .pipe(map(user => {
        if (user && user.token) {
          localStorage.setItem("jwt", user.token);
          console.log("token: " + user.token);
        }
      }),
      
    );
  }


  /*login(credentials: string){
    return this.http.post('https://localhost:44358/api/Authenticate/Login', credentials, {
      headers: new HttpHeaders({
        "content-Type" : "application/json"
      })
    } );
  }*/
}
