import { Component, OnInit } from '@angular/core';
import { UsersService } from '../users.service';
import { User } from '../entities/user';

@Component({
  selector: 'app-register',
  templateUrl: './register.component.html',
  styleUrls: ['./register.component.css']
})
export class RegisterComponent implements OnInit {

  constructor(private usersServices: UsersService) { }

  firstName: string = "";
  lastName: string = "";
  userName: string = "";
  password: string = "";
  confirmPassword: string;

  ngOnInit() {

  }

  getFormErrors(): string[] {
    let errors = [];

    if (this.firstName === "") {
      errors.push("First name is required");
    }

    if (this.lastName === "") {
      errors.push("Last name is required");
    }

    if (this.userName === "") {
      errors.push("User name is required");
    }

    if (this.password === "") {
      errors.push("Password is required");
    }

    if (this.password !== this.confirmPassword) {
      errors.push("Make sure the password and confirmed password match");
    }

    return errors;
  }

  handleSubmit() {
    var errors = this.getFormErrors();
    if (errors.length == 0) {
      let user = new User();
      user.firstName = this.firstName;
      user.lastName = this.lastName;
      user.username = this.userName;
      user.password = this.password;
      this.usersServices.register(user);
    } else {
      errors.forEach(x => {
        alert(x);
      })
    }
  }
}
