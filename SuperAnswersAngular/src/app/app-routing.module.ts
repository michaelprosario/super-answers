import { LoginComponent } from './login/login.component';
import { NgModule } from '@angular/core';
import { RegisterComponent } from './register/register.component';
import { Routes, RouterModule } from '@angular/router';
import { ViewQuestionComponent } from './view-question/view-question.component';
import { AskQuestionComponent } from './ask-question/ask-question.component';
import { TestComponent } from './test/test.component';
import { AnswerQuestionComponent } from './answer-question/answer-question.component';
import { EditQuestionComponent } from './edit-question/edit-question.component';

const routes: Routes = [
  { path: '', component: LoginComponent },
  { path: 'askQuestion', component: AskQuestionComponent },  
  { path: 'answerQuestion', component: AnswerQuestionComponent },  
  { path: 'login', component: LoginComponent },
  { path: 'viewQuestion/:id', component: ViewQuestionComponent },  
  { path: 'editQuestion/:id', component: EditQuestionComponent },   
  { path: 'register', component: RegisterComponent },
  { path: 'test', component: TestComponent },
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
