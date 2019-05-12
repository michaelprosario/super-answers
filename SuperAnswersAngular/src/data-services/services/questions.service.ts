/* tslint:disable */
import { Injectable } from '@angular/core';
import { HttpClient, HttpRequest, HttpResponse, HttpHeaders } from '@angular/common/http';
import { BaseService as __BaseService } from '../base-service';
import { ApiConfiguration as __Configuration } from '../api-configuration';
import { StrictHttpResponse as __StrictHttpResponse } from '../strict-http-response';
import { Observable as __Observable } from 'rxjs';
import { map as __map, filter as __filter } from 'rxjs/operators';

import { AddQuestionResponse } from '../models/add-question-response';
import { AddQuestionRequest } from '../models/add-question-request';
import { EditQuestionResponse } from '../models/edit-question-response';
import { EditQuestionRequest } from '../models/edit-question-request';
import { VoidResponse } from '../models/void-response';
import { DeleteQuestionRequest } from '../models/delete-question-request';
import { ListQuestionsResponse } from '../models/list-questions-response';
import { ListQuestionsRequest } from '../models/list-questions-request';
import { GetQuestionResponse } from '../models/get-question-response';
import { GetQuestionRequest } from '../models/get-question-request';
@Injectable({
  providedIn: 'root',
})
class QuestionsService extends __BaseService {
  static readonly QuestionsAddQuestionPath = '/Questions/AddQuestion';
  static readonly QuestionsEditQuestionPath = '/Questions/EditQuestion';
  static readonly QuestionsDeleteQuestionPath = '/Questions/DeleteQuestion';
  static readonly QuestionsListQuestionsPath = '/Questions/ListQuestions';
  static readonly QuestionsGetQuestionPath = '/Questions/GetQuestion';

  constructor(
    config: __Configuration,
    http: HttpClient
  ) {
    super(config, http);
  }

  /**
   * @param request undefined
   */
  QuestionsAddQuestionResponse(request: AddQuestionRequest): __Observable<__StrictHttpResponse<AddQuestionResponse>> {
    let __params = this.newParams();
    let __headers = new HttpHeaders();
    let __body: any = null;
    __body = request;
    let req = new HttpRequest<any>(
      'POST',
      this.rootUrl + `/Questions/AddQuestion`,
      __body,
      {
        headers: __headers,
        params: __params,
        responseType: 'json'
      });

    return this.http.request<any>(req).pipe(
      __filter(_r => _r instanceof HttpResponse),
      __map((_r) => {
        return _r as __StrictHttpResponse<AddQuestionResponse>;
      })
    );
  }
  /**
   * @param request undefined
   */
  QuestionsAddQuestion(request: AddQuestionRequest): __Observable<AddQuestionResponse> {
    return this.QuestionsAddQuestionResponse(request).pipe(
      __map(_r => _r.body as AddQuestionResponse)
    );
  }

  /**
   * @param request undefined
   */
  QuestionsEditQuestionResponse(request: EditQuestionRequest): __Observable<__StrictHttpResponse<EditQuestionResponse>> {
    let __params = this.newParams();
    let __headers = new HttpHeaders();
    let __body: any = null;
    __body = request;
    let req = new HttpRequest<any>(
      'POST',
      this.rootUrl + `/Questions/EditQuestion`,
      __body,
      {
        headers: __headers,
        params: __params,
        responseType: 'json'
      });

    return this.http.request<any>(req).pipe(
      __filter(_r => _r instanceof HttpResponse),
      __map((_r) => {
        return _r as __StrictHttpResponse<EditQuestionResponse>;
      })
    );
  }
  /**
   * @param request undefined
   */
  QuestionsEditQuestion(request: EditQuestionRequest): __Observable<EditQuestionResponse> {
    return this.QuestionsEditQuestionResponse(request).pipe(
      __map(_r => _r.body as EditQuestionResponse)
    );
  }

  /**
   * @param request undefined
   */
  QuestionsDeleteQuestionResponse(request: DeleteQuestionRequest): __Observable<__StrictHttpResponse<VoidResponse>> {
    let __params = this.newParams();
    let __headers = new HttpHeaders();
    let __body: any = null;
    __body = request;
    let req = new HttpRequest<any>(
      'POST',
      this.rootUrl + `/Questions/DeleteQuestion`,
      __body,
      {
        headers: __headers,
        params: __params,
        responseType: 'json'
      });

    return this.http.request<any>(req).pipe(
      __filter(_r => _r instanceof HttpResponse),
      __map((_r) => {
        return _r as __StrictHttpResponse<VoidResponse>;
      })
    );
  }
  /**
   * @param request undefined
   */
  QuestionsDeleteQuestion(request: DeleteQuestionRequest): __Observable<VoidResponse> {
    return this.QuestionsDeleteQuestionResponse(request).pipe(
      __map(_r => _r.body as VoidResponse)
    );
  }

  /**
   * @param request undefined
   */
  QuestionsListQuestionsResponse(request: ListQuestionsRequest): __Observable<__StrictHttpResponse<ListQuestionsResponse>> {
    let __params = this.newParams();
    let __headers = new HttpHeaders();
    let __body: any = null;
    __body = request;
    let req = new HttpRequest<any>(
      'POST',
      this.rootUrl + `/Questions/ListQuestions`,
      __body,
      {
        headers: __headers,
        params: __params,
        responseType: 'json'
      });

    return this.http.request<any>(req).pipe(
      __filter(_r => _r instanceof HttpResponse),
      __map((_r) => {
        return _r as __StrictHttpResponse<ListQuestionsResponse>;
      })
    );
  }
  /**
   * @param request undefined
   */
  QuestionsListQuestions(request: ListQuestionsRequest): __Observable<ListQuestionsResponse> {
    return this.QuestionsListQuestionsResponse(request).pipe(
      __map(_r => _r.body as ListQuestionsResponse)
    );
  }

  /**
   * @param request undefined
   */
  QuestionsGetQuestionResponse(request: GetQuestionRequest): __Observable<__StrictHttpResponse<GetQuestionResponse>> {
    let __params = this.newParams();
    let __headers = new HttpHeaders();
    let __body: any = null;
    __body = request;
    let req = new HttpRequest<any>(
      'POST',
      this.rootUrl + `/Questions/GetQuestion`,
      __body,
      {
        headers: __headers,
        params: __params,
        responseType: 'json'
      });

    return this.http.request<any>(req).pipe(
      __filter(_r => _r instanceof HttpResponse),
      __map((_r) => {
        return _r as __StrictHttpResponse<GetQuestionResponse>;
      })
    );
  }
  /**
   * @param request undefined
   */
  QuestionsGetQuestion(request: GetQuestionRequest): __Observable<GetQuestionResponse> {
    return this.QuestionsGetQuestionResponse(request).pipe(
      __map(_r => _r.body as GetQuestionResponse)
    );
  }
}

module QuestionsService {
}

export { QuestionsService }
