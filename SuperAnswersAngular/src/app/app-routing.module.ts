import { LoginComponent } from './login/login.component';
import { NgModule } from '@angular/core';
import { RegisterComponent } from './register/register.component';
import { Routes, RouterModule } from '@angular/router';
import { ViewQuestionComponent } from './view-question/view-question.component';
import { AskQuestionComponent } from './ask-question/ask-question.component';
import { TestComponent } from './test/test.component';

const routes: Routes = [
  { path: '', component: LoginComponent },
  { path: 'register', component: RegisterComponent },
  { path: 'login', component: LoginComponent },
  { path: 'question', component: ViewQuestionComponent },  
  { path: 'askQuestion', component: AskQuestionComponent },  
  { path: 'test', component: TestComponent },
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
