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
import { AddQuestionTagResponse } from '../models/add-question-tag-response';
import { AddQuestionTagRequest } from '../models/add-question-tag-request';
import { DeleteQuestionTagRequest } from '../models/delete-question-tag-request';
import { ListQuestionTagsResponse } from '../models/list-question-tags-response';
import { ListQuestionTagsRequest } from '../models/list-question-tags-request';
import { AddQuestionAnswerResponse } from '../models/add-question-answer-response';
import { AddQuestionAnswerRequest } from '../models/add-question-answer-request';
import { EditQuestionAnswerResponse } from '../models/edit-question-answer-response';
import { EditQuestionAnswerRequest } from '../models/edit-question-answer-request';
import { DeleteQuestionAnswerRequest } from '../models/delete-question-answer-request';
import { ListQuestionAnswersResponse } from '../models/list-question-answers-response';
import { ListQuestionAnswersRequest } from '../models/list-question-answers-request';
import { GetQuestionAnswerResponse } from '../models/get-question-answer-response';
import { GetQuestionAnswerRequest } from '../models/get-question-answer-request';
@Injectable({
  providedIn: 'root',
})
class QuestionsService extends __BaseService {
  static readonly QuestionsAddQuestionPath = '/Questions/AddQuestion';
  static readonly QuestionsEditQuestionPath = '/Questions/EditQuestion';
  static readonly QuestionsDeleteQuestionPath = '/Questions/DeleteQuestion';
  static readonly QuestionsListQuestionsPath = '/Questions/ListQuestions';
  static readonly QuestionsGetQuestionPath = '/Questions/GetQuestion';
  static readonly QuestionsAddQuestionTagPath = '/Questions/AddQuestionTag';
  static readonly QuestionsDeleteQuestionTagPath = '/Questions/DeleteQuestionTag';
  static readonly QuestionsListQuestionTagsPath = '/Questions/ListQuestionTags';
  static readonly QuestionsAddQuestionAnswerPath = '/Questions/AddQuestionAnswer';
  static readonly QuestionsEditQuestionAnswerPath = '/Questions/EditQuestionAnswer';
  static readonly QuestionsDeleteQuestionAnswerPath = '/Questions/DeleteQuestionAnswer';
  static readonly QuestionsListQuestionAnswersPath = '/Questions/ListQuestionAnswers';
  static readonly QuestionsGetQuestionAnswerPath = '/Questions/GetQuestionAnswer';

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

  /**
   * @param request undefined
   */
  QuestionsAddQuestionTagResponse(request: AddQuestionTagRequest): __Observable<__StrictHttpResponse<AddQuestionTagResponse>> {
    let __params = this.newParams();
    let __headers = new HttpHeaders();
    let __body: any = null;
    __body = request;
    let req = new HttpRequest<any>(
      'POST',
      this.rootUrl + `/Questions/AddQuestionTag`,
      __body,
      {
        headers: __headers,
        params: __params,
        responseType: 'json'
      });

    return this.http.request<any>(req).pipe(
      __filter(_r => _r instanceof HttpResponse),
      __map((_r) => {
        return _r as __StrictHttpResponse<AddQuestionTagResponse>;
      })
    );
  }
  /**
   * @param request undefined
   */
  QuestionsAddQuestionTag(request: AddQuestionTagRequest): __Observable<AddQuestionTagResponse> {
    return this.QuestionsAddQuestionTagResponse(request).pipe(
      __map(_r => _r.body as AddQuestionTagResponse)
    );
  }

  /**
   * @param request undefined
   */
  QuestionsDeleteQuestionTagResponse(request: DeleteQuestionTagRequest): __Observable<__StrictHttpResponse<VoidResponse>> {
    let __params = this.newParams();
    let __headers = new HttpHeaders();
    let __body: any = null;
    __body = request;
    let req = new HttpRequest<any>(
      'POST',
      this.rootUrl + `/Questions/DeleteQuestionTag`,
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
  QuestionsDeleteQuestionTag(request: DeleteQuestionTagRequest): __Observable<VoidResponse> {
    return this.QuestionsDeleteQuestionTagResponse(request).pipe(
      __map(_r => _r.body as VoidResponse)
    );
  }

  /**
   * @param request undefined
   */
  QuestionsListQuestionTagsResponse(request: ListQuestionTagsRequest): __Observable<__StrictHttpResponse<ListQuestionTagsResponse>> {
    let __params = this.newParams();
    let __headers = new HttpHeaders();
    let __body: any = null;
    __body = request;
    let req = new HttpRequest<any>(
      'POST',
      this.rootUrl + `/Questions/ListQuestionTags`,
      __body,
      {
        headers: __headers,
        params: __params,
        responseType: 'json'
      });

    return this.http.request<any>(req).pipe(
      __filter(_r => _r instanceof HttpResponse),
      __map((_r) => {
        return _r as __StrictHttpResponse<ListQuestionTagsResponse>;
      })
    );
  }
  /**
   * @param request undefined
   */
  QuestionsListQuestionTags(request: ListQuestionTagsRequest): __Observable<ListQuestionTagsResponse> {
    return this.QuestionsListQuestionTagsResponse(request).pipe(
      __map(_r => _r.body as ListQuestionTagsResponse)
    );
  }

  /**
   * @param request undefined
   */
  QuestionsAddQuestionAnswerResponse(request: AddQuestionAnswerRequest): __Observable<__StrictHttpResponse<AddQuestionAnswerResponse>> {
    let __params = this.newParams();
    let __headers = new HttpHeaders();
    let __body: any = null;
    __body = request;
    let req = new HttpRequest<any>(
      'POST',
      this.rootUrl + `/Questions/AddQuestionAnswer`,
      __body,
      {
        headers: __headers,
        params: __params,
        responseType: 'json'
      });

    return this.http.request<any>(req).pipe(
      __filter(_r => _r instanceof HttpResponse),
      __map((_r) => {
        return _r as __StrictHttpResponse<AddQuestionAnswerResponse>;
      })
    );
  }
  /**
   * @param request undefined
   */
  QuestionsAddQuestionAnswer(request: AddQuestionAnswerRequest): __Observable<AddQuestionAnswerResponse> {
    return this.QuestionsAddQuestionAnswerResponse(request).pipe(
      __map(_r => _r.body as AddQuestionAnswerResponse)
    );
  }

  /**
   * @param request undefined
   */
  QuestionsEditQuestionAnswerResponse(request: EditQuestionAnswerRequest): __Observable<__StrictHttpResponse<EditQuestionAnswerResponse>> {
    let __params = this.newParams();
    let __headers = new HttpHeaders();
    let __body: any = null;
    __body = request;
    let req = new HttpRequest<any>(
      'POST',
      this.rootUrl + `/Questions/EditQuestionAnswer`,
      __body,
      {
        headers: __headers,
        params: __params,
        responseType: 'json'
      });

    return this.http.request<any>(req).pipe(
      __filter(_r => _r instanceof HttpResponse),
      __map((_r) => {
        return _r as __StrictHttpResponse<EditQuestionAnswerResponse>;
      })
    );
  }
  /**
   * @param request undefined
   */
  QuestionsEditQuestionAnswer(request: EditQuestionAnswerRequest): __Observable<EditQuestionAnswerResponse> {
    return this.QuestionsEditQuestionAnswerResponse(request).pipe(
      __map(_r => _r.body as EditQuestionAnswerResponse)
    );
  }

  /**
   * @param request undefined
   */
  QuestionsDeleteQuestionAnswerResponse(request: DeleteQuestionAnswerRequest): __Observable<__StrictHttpResponse<VoidResponse>> {
    let __params = this.newParams();
    let __headers = new HttpHeaders();
    let __body: any = null;
    __body = request;
    let req = new HttpRequest<any>(
      'POST',
      this.rootUrl + `/Questions/DeleteQuestionAnswer`,
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
  QuestionsDeleteQuestionAnswer(request: DeleteQuestionAnswerRequest): __Observable<VoidResponse> {
    return this.QuestionsDeleteQuestionAnswerResponse(request).pipe(
      __map(_r => _r.body as VoidResponse)
    );
  }

  /**
   * @param request undefined
   */
  QuestionsListQuestionAnswersResponse(request: ListQuestionAnswersRequest): __Observable<__StrictHttpResponse<ListQuestionAnswersResponse>> {
    let __params = this.newParams();
    let __headers = new HttpHeaders();
    let __body: any = null;
    __body = request;
    let req = new HttpRequest<any>(
      'POST',
      this.rootUrl + `/Questions/ListQuestionAnswers`,
      __body,
      {
        headers: __headers,
        params: __params,
        responseType: 'json'
      });

    return this.http.request<any>(req).pipe(
      __filter(_r => _r instanceof HttpResponse),
      __map((_r) => {
        return _r as __StrictHttpResponse<ListQuestionAnswersResponse>;
      })
    );
  }
  /**
   * @param request undefined
   */
  QuestionsListQuestionAnswers(request: ListQuestionAnswersRequest): __Observable<ListQuestionAnswersResponse> {
    return this.QuestionsListQuestionAnswersResponse(request).pipe(
      __map(_r => _r.body as ListQuestionAnswersResponse)
    );
  }

  /**
   * @param request undefined
   */
  QuestionsGetQuestionAnswerResponse(request: GetQuestionAnswerRequest): __Observable<__StrictHttpResponse<GetQuestionAnswerResponse>> {
    let __params = this.newParams();
    let __headers = new HttpHeaders();
    let __body: any = null;
    __body = request;
    let req = new HttpRequest<any>(
      'POST',
      this.rootUrl + `/Questions/GetQuestionAnswer`,
      __body,
      {
        headers: __headers,
        params: __params,
        responseType: 'json'
      });

    return this.http.request<any>(req).pipe(
      __filter(_r => _r instanceof HttpResponse),
      __map((_r) => {
        return _r as __StrictHttpResponse<GetQuestionAnswerResponse>;
      })
    );
  }
  /**
   * @param request undefined
   */
  QuestionsGetQuestionAnswer(request: GetQuestionAnswerRequest): __Observable<GetQuestionAnswerResponse> {
    return this.QuestionsGetQuestionAnswerResponse(request).pipe(
      __map(_r => _r.body as GetQuestionAnswerResponse)
    );
  }
}

module QuestionsService {
}

export { QuestionsService }
