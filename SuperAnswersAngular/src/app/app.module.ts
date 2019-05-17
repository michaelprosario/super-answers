
import { AnswerQuestionComponent } from './answer-question/answer-question.component';
import { AppComponent } from './app.component';
import { AppRoutingModule } from './app-routing.module';
import { AskQuestionComponent } from './ask-question/ask-question.component';
import { AuthGuard } from './guards/auth.guard';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { BrowserModule } from '@angular/platform-browser';
import { ErrorInterceptor } from './helpers/error.interceptor';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { HttpClientModule, HTTP_INTERCEPTORS } from '@angular/common/http';
import { JwtInterceptor } from './helpers/jwt.interceptor';
import { LoginComponent } from './login/login.component';
import { NgModule } from '@angular/core';
import { RegisterComponent } from './register/register.component';
import { TagInputModule } from 'ngx-chips';
import { TestComponent } from './test/test.component';
import { ViewQuestionComponent } from './view-question/view-question.component';
import { SiteTopRowComponent } from './site-top-row/site-top-row.component';
import { LeftMenuComponent } from './left-menu/left-menu.component';
import { LMarkdownEditorModule } from 'ngx-markdown-editor';


@NgModule({
  declarations: [
    AnswerQuestionComponent,
    AppComponent,
    AskQuestionComponent,
    LoginComponent,
    RegisterComponent,
    TestComponent,
    ViewQuestionComponent,
    SiteTopRowComponent,
    LeftMenuComponent,
  ],
  imports: [
    AppRoutingModule,
    BrowserAnimationsModule,
    BrowserAnimationsModule,
    BrowserModule,
    FormsModule,
    FormsModule,
    HttpClientModule,
    ReactiveFormsModule,    
    TagInputModule,
    LMarkdownEditorModule,
  ],
  providers: [
    AuthGuard,
    { provide: HTTP_INTERCEPTORS, useClass: JwtInterceptor, multi: true },
    { provide: HTTP_INTERCEPTORS, useClass: ErrorInterceptor, multi: true },
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
