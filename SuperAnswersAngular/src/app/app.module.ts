
import { AppComponent } from './app.component';
import { AppRoutingModule } from './app-routing.module';
import { AskQuestionComponent } from './ask-question/ask-question.component';
import { AuthGuard } from './guards/auth.guard';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { BrowserModule } from '@angular/platform-browser';
import { CovalentTextEditorModule } from '@covalent/text-editor';
import { EditQuestionAnswerComponent } from './edit-question-answer/edit-question-answer.component';
import { EditQuestionComponent } from './edit-question/edit-question.component';
import { ErrorInterceptor } from './helpers/error.interceptor';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { HttpClientModule, HTTP_INTERCEPTORS } from '@angular/common/http';
import { JwtInterceptor } from './helpers/jwt.interceptor';
import { LeftMenuComponent } from './left-menu/left-menu.component';
import { LoginComponent } from './login/login.component';
import { NgModule } from '@angular/core';
import { QuestionComponent } from './question/question.component';
import { QuestionSearchComponent } from './question-search/question-search.component';
import { RecentQuestionsComponent } from './recent-questions/recent-questions.component';
import { RegisterComponent } from './register/register.component';
import { SiteTopRowComponent } from './site-top-row/site-top-row.component';
import { TagInputModule } from 'ngx-chips';
import { TestComponent } from './test/test.component';
import { ViewQuestionComponent } from './view-question/view-question.component';
import { MDBBootstrapModule } from 'angular-bootstrap-md';

@NgModule({
  declarations: [
    AppComponent,
    AskQuestionComponent,
    EditQuestionAnswerComponent,
    EditQuestionComponent,
    LeftMenuComponent,
    LoginComponent,
    QuestionComponent,
    QuestionSearchComponent,
    RecentQuestionsComponent,
    RegisterComponent,
    SiteTopRowComponent,
    TestComponent,
    ViewQuestionComponent,
  ],
  imports: [
    AppRoutingModule,
    BrowserAnimationsModule,
    BrowserAnimationsModule,
    BrowserModule,
    CovalentTextEditorModule,
    FormsModule,
    FormsModule,
    HttpClientModule,
    MDBBootstrapModule.forRoot(),
    ReactiveFormsModule,    
    TagInputModule,
  ],
  providers: [
    AuthGuard,
    { provide: HTTP_INTERCEPTORS, useClass: JwtInterceptor, multi: true },
    { provide: HTTP_INTERCEPTORS, useClass: ErrorInterceptor, multi: true },
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
