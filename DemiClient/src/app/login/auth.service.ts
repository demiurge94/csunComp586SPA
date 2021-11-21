import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root'
})
export class AuthService {

  constructor(private http: HttpClient) { }

  login(credentials: string){
    return this.http.post('https://localhost:44358/api/Authenticate/Login', credentials, {
      headers: new HttpHeaders({
        "content-Type" : "application/json"
      })
    } );
  }
}
