import { LoginComponent } from './login/login.component';
import { NgModule } from '@angular/core';
import { RegisterComponent } from './register/register.component';
import { Routes, RouterModule } from '@angular/router';
import { ViewQuestionComponent } from './view-question/view-question.component';
import { AskQuestionComponent } from './ask-question/ask-question.component';
import { TestComponent } from './test/test.component';
import { EditQuestionComponent } from './edit-question/edit-question.component';
import { EditQuestionAnswerComponent } from './edit-question-answer/edit-question-answer.component';

const routes: Routes = [
  { path: '', component: LoginComponent },
  { path: 'askQuestion', component: AskQuestionComponent },  
  { path: 'login', component: LoginComponent },
  { path: 'viewQuestion/:id', component: ViewQuestionComponent },  
  { path: 'editQuestion/:id', component: EditQuestionComponent },   
  { path: 'editQuestionAnswer/:id', component: EditQuestionAnswerComponent },   
  { path: 'register', component: RegisterComponent },
  { path: 'test', component: TestComponent },
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
