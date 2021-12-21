import { Component, OnInit } from '@angular/core';
import { FormBuilder , FormGroup, Validators } from '@angular/forms';  
import { AuthService } from 'src/app/login/auth.service';
@Component({
  selector: 'app-register',
  templateUrl: './register.component.html',
  styleUrls: ['./register.component.css']
})
export class RegisterComponent  {
  userForm: any;  
      
  constructor(private formBuilder: FormBuilder, private authService: AuthService) {  
      this.CreateForm();  

  }  
  
  CreateForm(){
    this.userForm = this.formBuilder.group(
      {
        'name': ['', Validators.required],  
            'email': ['', [Validators.required]],  
            'password': ['', [Validators.required]],  
            'confirmPassword': ['', [Validators.required]],
      }
    )
  }
  saveUser(){
      console.log(this.userForm.controls['name'].value);
      return this.authService.registerUser(this.userForm.controls['name'].value, this.userForm.controls['email'].value, this.userForm.controls['password'].value);
    
  }

}
