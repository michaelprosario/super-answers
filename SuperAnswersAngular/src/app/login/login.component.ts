import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { UsersService } from '../users.service';
import { first } from 'rxjs/operators';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.scss']
})
export class LoginComponent implements OnInit {

  userName: string = "";
  password: string = "";
  returnUrl: string = "";
  message: string = "";

  constructor(
    private router: Router,
    private route: ActivatedRoute,
    private usersService: UsersService
  ) { }

  ngOnInit() {
    this.returnUrl = this.route.snapshot.queryParams['returnUrl'] || '/';
    this.usersService.logout();
  }

  handleLogin(){
    this.usersService.login(this.userName, this.password)
    .pipe(first())
    .subscribe(response => 
    { 
      this.message = "";
      this.router.navigate(["/recentQuestions"]);
    }, 
    error => {
      this.message = "Enter valid user name and password";
    });
  }

}
