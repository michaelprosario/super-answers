import { Component, OnInit } from '@angular/core';

import { User } from '../entities/user';
import { first } from 'rxjs/operators';
import { Router, ActivatedRoute } from '@angular/router';
import { UsersService } from 'src/data-services/services';
import { RegisterUserRequest } from 'src/data-services/models';

@Component({
  selector: 'app-register',
  templateUrl: './register.component.html',
  styleUrls: ['./register.component.scss']
})
export class RegisterComponent implements OnInit {

  constructor(
    private router: Router,
    private route: ActivatedRoute,
    private usersService: UsersService
  ) { }

  firstName: string = "";
  lastName: string = "";
  userName: string = "";
  password: string = "";
  confirmPassword: string = "";
  formErrors = [];

  ngOnInit() {

  }


  handleSubmit() {
      this.formErrors.length = 0;

      if(this.password !== this.confirmPassword){
        this.formErrors.push('Password and confirm password does not match.');
        return false;
      }

      let request: RegisterUserRequest = {};
      request.firstName = this.firstName;
      request.lastName = this.lastName;
      request.userName = this.userName;
      request.password = this.password;

      this.usersService.UsersRegisterUser(request)
      .pipe(first())
      .subscribe(response => 
      { 
        
        if(!response.validationErrors){
          alert("User account has been created");
          this.router.navigate(["/login"]);
        }else{
          response.validationErrors.map(error => this.formErrors.push(error.errorMessage));          
        }
        
      }, 
      error => {
        alert(error.message);
      });

  }
}
