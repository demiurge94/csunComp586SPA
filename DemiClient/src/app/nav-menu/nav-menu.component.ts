import { Component } from '@angular/core';
import { AuthService } from '../login/auth.service';
@Component({
  selector: 'app-nav-menu',
  templateUrl: './nav-menu.component.html',
  styleUrls: ['./nav-menu.component.css']
})
export class NavMenuComponent {
  isExpanded = false;
  userIsAuthenticated!: boolean;
  constructor(private authService: AuthService,  ){
    
  }
  isAuthenticated(){
    return this.userIsAuthenticated = this.authService.isAuthenticated;

  }
  collapse() {
    this.isExpanded = false;
  }

  toggle() {
    this.isExpanded = !this.isExpanded;
  }
  onLogout(){
    this.authService.logout(); 
  }
}
