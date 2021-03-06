import { LoginComponent } from './login/login.component';
import { NgModule } from '@angular/core';
import { RegisterComponent } from './register/register.component';
import { Routes, RouterModule } from '@angular/router';
import { ViewQuestionComponent } from './view-question/view-question.component';
import { AskQuestionComponent } from './ask-question/ask-question.component';
import { EditQuestionComponent } from './edit-question/edit-question.component';
import { EditQuestionAnswerComponent } from './edit-question-answer/edit-question-answer.component';
import { QuestionSearchComponent } from './question-search/question-search.component';
import { RecentQuestionsComponent } from './recent-questions/recent-questions.component';

const routes: Routes = [
  { path: '', component: LoginComponent },
  { path: 'askQuestion', component: AskQuestionComponent },  
  { path: 'editQuestion/:id', component: EditQuestionComponent },   
  { path: 'editQuestionAnswer/:id', component: EditQuestionAnswerComponent },   
  { path: 'login', component: LoginComponent },
  { path: 'register', component: RegisterComponent },
  { path: 'recentQuestions', component: RecentQuestionsComponent },
  { path: 'searchQuestions/:terms', component: QuestionSearchComponent },   
  { path: 'viewQuestion/:id', component: ViewQuestionComponent },  
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
