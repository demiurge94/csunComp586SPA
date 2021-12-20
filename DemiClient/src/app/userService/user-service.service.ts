import { Injectable } from '@angular/core';
import { BehaviorSubject } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class UserService {
  private isLoggedIn = new BehaviorSubject<boolean>(false);

  public isLoggedIn$ = this.isLoggedIn.asObservable();

  constructor() { }

  public logIn() {
    this.isLoggedIn.next(true);
  }

  public logOut() {
    this.isLoggedIn.next(false);
  }
}