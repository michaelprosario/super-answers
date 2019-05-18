import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Observable, of } from 'rxjs';
import { catchError, map, tap, first } from 'rxjs/operators';
import { environment } from '../environments/environment'

const httpOptions = {
  headers: new HttpHeaders({ 'Content-Type': 'application/json' })
};

export class BaseResponse {
  code: number;
  message:string;
  validationErrors:string[];
}

export class BasicRequest {
  userId: string;
}


export class AddQuestionResponse {
}

export class Response {
  code: any;  
  message: string;  
  validationErrors: any;  
}

export class ResponseCode {
}

export class ValidationFailure {
  propertyName: string;  
  errorMessage: string;  
  attemptedValue: any;  
  customState: any;  
  severity: any;  
  errorCode: string;  
  formattedMessageArguments: any;  
  formattedMessagePlaceholderValues: any;  
  resourceName: string;  
}

export class Severity {
}

export class AddQuestionRequest {
  questionTitle: string;  
  content: string;  
  tags: string;  
  notifyMeOnResponse: boolean;  
  userId: string;  
}

export class EditQuestionResponse {
}

export class EditQuestionRequest {
  questionTitle: string;  
  content: string;  
  tags: string;  
  notifyMeOnResponse: boolean;  
  userId: string;  
  questionId: string;  
}

export class VoidResponse {
}

export class DeleteQuestionRequest {
  id: string;  
  userId: string;  
}

export class ListQuestionsResponse {
}

export class Question {
  id: string;  
  questionTitle: string;  
  tags: string;  
  tagArray: any;  
  content: string;  
  createdBy: string;  
  updatedBy: string;  
  createdAt: string;  
  updatedAt: string;  
  votes: number;  
}

export class ListQuestionsRequest {
  userId: string;  
}

export class GetQuestionResponse {
}

export class QuestionAnswer {
  questionId: string;  
  answer: string;  
  createdAt: string;  
  createdBy: string;  
  updatedAt: string;  
  updatedBy: string;  
  votes: number;  
  id: string;  
}

export class GetQuestionRequest {
  id: string;  
  userId: string;  
}

export class AddQuestionTagResponse {
}

export class AddQuestionTagRequest {
  title: string;  
  createdAt: string;  
  createdBy: string;  
  updatedAt: string;  
  updatedBy: string;  
  userId: string;  
}

export class DeleteQuestionTagRequest {
  id: string;  
  userId: string;  
}

export class ListQuestionTagsResponse {
}

export class QuestionTag {
  title: string;  
  createdAt: string;  
  createdBy: string;  
  updatedAt: string;  
  updatedBy: string;  
  id: string;  
}

export class ListQuestionTagsRequest {
  userId: string;  
}

export class AddQuestionAnswerResponse {
}

export class AddQuestionAnswerRequest {
  questionId: string;  
  answer: string;  
  userId: string;  
}

export class EditQuestionAnswerResponse {
}

export class EditQuestionAnswerRequest {
  id: string;  
  questionId: string;  
  answer: string;  
  createdAt: string;  
  createdBy: string;  
  updatedAt: string;  
  updatedBy: string;  
  votes: number;  
  userId: string;  
}

export class DeleteQuestionAnswerRequest {
  id: string;  
  userId: string;  
}

export class ListQuestionAnswersResponse {
}

export class ListQuestionAnswersRequest {
  userId: string;  
}

export class GetQuestionAnswerResponse {
}

export class GetQuestionAnswerRequest {
  id: string;  
  userId: string;  
}

export class AddQuestionVoteResponse {
}

export class AddQuestionVoteRequest {
  questionId: string;  
  createdAt: string;  
  createdBy: string;  
  updatedAt: string;  
  updatedBy: string;  
  userId: string;  
}

export class DeleteQuestionVoteRequest {
  id: string;  
  userId: string;  
}

export class UserDto {
  id: string;  
  firstName: string;  
  lastName: string;  
  username: string;  
  password: string;  
}

@Injectable({
  providedIn: 'root'
})
export class QuestionsService {

constructor( private http: HttpClient ) {}


AddQuestion (request: AddQuestionRequest): Observable<AddQuestionResponse> {
    return this.http.post<AddQuestionResponse>(environment.apiUrl + '/Questions/AddQuestion', request, httpOptions);
}

EditQuestion (request: EditQuestionRequest): Observable<EditQuestionResponse> {
    return this.http.post<EditQuestionResponse>(environment.apiUrl + '/Questions/EditQuestion', request, httpOptions);
}

DeleteQuestion (request: DeleteQuestionRequest): Observable<DeleteQuestionResponse> {
    return this.http.post<DeleteQuestionResponse>(environment.apiUrl + '/Questions/DeleteQuestion', request, httpOptions);
}

ListQuestions (request: ListQuestionsRequest): Observable<ListQuestionsResponse> {
    return this.http.post<ListQuestionsResponse>(environment.apiUrl + '/Questions/ListQuestions', request, httpOptions);
}

GetQuestion (request: GetQuestionRequest): Observable<GetQuestionResponse> {
    return this.http.post<GetQuestionResponse>(environment.apiUrl + '/Questions/GetQuestion', request, httpOptions);
}

AddQuestionTag (request: AddQuestionTagRequest): Observable<AddQuestionTagResponse> {
    return this.http.post<AddQuestionTagResponse>(environment.apiUrl + '/Questions/AddQuestionTag', request, httpOptions);
}

DeleteQuestionTag (request: DeleteQuestionTagRequest): Observable<DeleteQuestionTagResponse> {
    return this.http.post<DeleteQuestionTagResponse>(environment.apiUrl + '/Questions/DeleteQuestionTag', request, httpOptions);
}

ListQuestionTags (request: ListQuestionTagsRequest): Observable<ListQuestionTagsResponse> {
    return this.http.post<ListQuestionTagsResponse>(environment.apiUrl + '/Questions/ListQuestionTags', request, httpOptions);
}

AddQuestionAnswer (request: AddQuestionAnswerRequest): Observable<AddQuestionAnswerResponse> {
    return this.http.post<AddQuestionAnswerResponse>(environment.apiUrl + '/Questions/AddQuestionAnswer', request, httpOptions);
}

EditQuestionAnswer (request: EditQuestionAnswerRequest): Observable<EditQuestionAnswerResponse> {
    return this.http.post<EditQuestionAnswerResponse>(environment.apiUrl + '/Questions/EditQuestionAnswer', request, httpOptions);
}

DeleteQuestionAnswer (request: DeleteQuestionAnswerRequest): Observable<DeleteQuestionAnswerResponse> {
    return this.http.post<DeleteQuestionAnswerResponse>(environment.apiUrl + '/Questions/DeleteQuestionAnswer', request, httpOptions);
}

ListQuestionAnswers (request: ListQuestionAnswersRequest): Observable<ListQuestionAnswersResponse> {
    return this.http.post<ListQuestionAnswersResponse>(environment.apiUrl + '/Questions/ListQuestionAnswers', request, httpOptions);
}

GetQuestionAnswer (request: GetQuestionAnswerRequest): Observable<GetQuestionAnswerResponse> {
    return this.http.post<GetQuestionAnswerResponse>(environment.apiUrl + '/Questions/GetQuestionAnswer', request, httpOptions);
}

AddQuestionVote (request: AddQuestionVoteRequest): Observable<AddQuestionVoteResponse> {
    return this.http.post<AddQuestionVoteResponse>(environment.apiUrl + '/Questions/AddQuestionVote', request, httpOptions);
}

DeleteQuestionVote (request: DeleteQuestionVoteRequest): Observable<DeleteQuestionVoteResponse> {
    return this.http.post<DeleteQuestionVoteResponse>(environment.apiUrl + '/Questions/DeleteQuestionVote', request, httpOptions);
}

}


