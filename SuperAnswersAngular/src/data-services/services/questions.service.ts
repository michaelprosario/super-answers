/* tslint:disable */
import { Injectable } from '@angular/core';
import { HttpClient, HttpRequest, HttpResponse, HttpHeaders } from '@angular/common/http';
import { BaseService as __BaseService } from '../base-service';
import { ApiConfiguration as __Configuration } from '../api-configuration';
import { StrictHttpResponse as __StrictHttpResponse } from '../strict-http-response';
import { Observable as __Observable } from 'rxjs';
import { map as __map, filter as __filter } from 'rxjs/operators';

import { AddQuestionResponse } from '../models/add-question-response';
import { AddQuestionCommand } from '../models/add-question-command';
import { EditQuestionResponse } from '../models/edit-question-response';
import { EditQuestionCommand } from '../models/edit-question-command';
import { VoidResponse } from '../models/void-response';
import { DeleteQuestionCommand } from '../models/delete-question-command';
import { ListQuestionsResponse } from '../models/list-questions-response';
import { ListQuestionsQuery } from '../models/list-questions-query';
import { GetQuestionResponse } from '../models/get-question-response';
import { GetQuestionQuery } from '../models/get-question-query';
import { AddQuestionTagResponse } from '../models/add-question-tag-response';
import { AddQuestionTagCommand } from '../models/add-question-tag-command';
import { DeleteQuestionTagCommand } from '../models/delete-question-tag-command';
import { ListQuestionTagsResponse } from '../models/list-question-tags-response';
import { ListQuestionTagsQuery } from '../models/list-question-tags-query';
import { AddQuestionAnswerResponse } from '../models/add-question-answer-response';
import { AddQuestionAnswerCommand } from '../models/add-question-answer-command';
import { EditQuestionAnswerResponse } from '../models/edit-question-answer-response';
import { EditQuestionAnswerCommand } from '../models/edit-question-answer-command';
import { DeleteQuestionAnswerCommand } from '../models/delete-question-answer-command';
import { ListQuestionAnswersResponse } from '../models/list-question-answers-response';
import { ListQuestionAnswersQuery } from '../models/list-question-answers-query';
import { GetQuestionAnswerResponse } from '../models/get-question-answer-response';
import { GetQuestionAnswerQuery } from '../models/get-question-answer-query';
import { AddAnswerVoteResponse } from '../models/add-answer-vote-response';
import { AddAnswerVoteCommand } from '../models/add-answer-vote-command';
import { AddQuestionVoteResponse } from '../models/add-question-vote-response';
import { AddQuestionVoteCommand } from '../models/add-question-vote-command';
import { DeleteQuestionVoteCommand } from '../models/delete-question-vote-command';
import { SearchByKeywordResponse } from '../models/search-by-keyword-response';
import { SearchByKeywordQuery } from '../models/search-by-keyword-query';
import { GetMostRecentQuestionsResponse } from '../models/get-most-recent-questions-response';
import { GetMostRecentQuestionsQuery } from '../models/get-most-recent-questions-query';
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
  static readonly QuestionsAddAnswerVotePath = '/Questions/AddAnswerVote';
  static readonly QuestionsAddQuestionVotePath = '/Questions/AddQuestionVote';
  static readonly QuestionsDeleteQuestionVotePath = '/Questions/DeleteQuestionVote';
  static readonly QuestionsSearchByKeywordPath = '/Questions/SearchByKeyword';
  static readonly QuestionsGetMostRecentQuestionsPath = '/Questions/GetMostRecentQuestions';

  constructor(
    config: __Configuration,
    http: HttpClient
  ) {
    super(config, http);
  }

  /**
   * @param command undefined
   */
  QuestionsAddQuestionResponse(command: AddQuestionCommand): __Observable<__StrictHttpResponse<AddQuestionResponse>> {
    let __params = this.newParams();
    let __headers = new HttpHeaders();
    let __body: any = null;
    __body = command;
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
   * @param command undefined
   */
  QuestionsAddQuestion(command: AddQuestionCommand): __Observable<AddQuestionResponse> {
    return this.QuestionsAddQuestionResponse(command).pipe(
      __map(_r => _r.body as AddQuestionResponse)
    );
  }

  /**
   * @param command undefined
   */
  QuestionsEditQuestionResponse(command: EditQuestionCommand): __Observable<__StrictHttpResponse<EditQuestionResponse>> {
    let __params = this.newParams();
    let __headers = new HttpHeaders();
    let __body: any = null;
    __body = command;
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
   * @param command undefined
   */
  QuestionsEditQuestion(command: EditQuestionCommand): __Observable<EditQuestionResponse> {
    return this.QuestionsEditQuestionResponse(command).pipe(
      __map(_r => _r.body as EditQuestionResponse)
    );
  }

  /**
   * @param command undefined
   */
  QuestionsDeleteQuestionResponse(command: DeleteQuestionCommand): __Observable<__StrictHttpResponse<VoidResponse>> {
    let __params = this.newParams();
    let __headers = new HttpHeaders();
    let __body: any = null;
    __body = command;
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
   * @param command undefined
   */
  QuestionsDeleteQuestion(command: DeleteQuestionCommand): __Observable<VoidResponse> {
    return this.QuestionsDeleteQuestionResponse(command).pipe(
      __map(_r => _r.body as VoidResponse)
    );
  }

  /**
   * @param query undefined
   */
  QuestionsListQuestionsResponse(query: ListQuestionsQuery): __Observable<__StrictHttpResponse<ListQuestionsResponse>> {
    let __params = this.newParams();
    let __headers = new HttpHeaders();
    let __body: any = null;
    __body = query;
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
   * @param query undefined
   */
  QuestionsListQuestions(query: ListQuestionsQuery): __Observable<ListQuestionsResponse> {
    return this.QuestionsListQuestionsResponse(query).pipe(
      __map(_r => _r.body as ListQuestionsResponse)
    );
  }

  /**
   * @param query undefined
   */
  QuestionsGetQuestionResponse(query: GetQuestionQuery): __Observable<__StrictHttpResponse<GetQuestionResponse>> {
    let __params = this.newParams();
    let __headers = new HttpHeaders();
    let __body: any = null;
    __body = query;
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
   * @param query undefined
   */
  QuestionsGetQuestion(query: GetQuestionQuery): __Observable<GetQuestionResponse> {
    return this.QuestionsGetQuestionResponse(query).pipe(
      __map(_r => _r.body as GetQuestionResponse)
    );
  }

  /**
   * @param command undefined
   */
  QuestionsAddQuestionTagResponse(command: AddQuestionTagCommand): __Observable<__StrictHttpResponse<AddQuestionTagResponse>> {
    let __params = this.newParams();
    let __headers = new HttpHeaders();
    let __body: any = null;
    __body = command;
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
   * @param command undefined
   */
  QuestionsAddQuestionTag(command: AddQuestionTagCommand): __Observable<AddQuestionTagResponse> {
    return this.QuestionsAddQuestionTagResponse(command).pipe(
      __map(_r => _r.body as AddQuestionTagResponse)
    );
  }

  /**
   * @param command undefined
   */
  QuestionsDeleteQuestionTagResponse(command: DeleteQuestionTagCommand): __Observable<__StrictHttpResponse<VoidResponse>> {
    let __params = this.newParams();
    let __headers = new HttpHeaders();
    let __body: any = null;
    __body = command;
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
   * @param command undefined
   */
  QuestionsDeleteQuestionTag(command: DeleteQuestionTagCommand): __Observable<VoidResponse> {
    return this.QuestionsDeleteQuestionTagResponse(command).pipe(
      __map(_r => _r.body as VoidResponse)
    );
  }

  /**
   * @param query undefined
   */
  QuestionsListQuestionTagsResponse(query: ListQuestionTagsQuery): __Observable<__StrictHttpResponse<ListQuestionTagsResponse>> {
    let __params = this.newParams();
    let __headers = new HttpHeaders();
    let __body: any = null;
    __body = query;
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
   * @param query undefined
   */
  QuestionsListQuestionTags(query: ListQuestionTagsQuery): __Observable<ListQuestionTagsResponse> {
    return this.QuestionsListQuestionTagsResponse(query).pipe(
      __map(_r => _r.body as ListQuestionTagsResponse)
    );
  }

  /**
   * @param command undefined
   */
  QuestionsAddQuestionAnswerResponse(command: AddQuestionAnswerCommand): __Observable<__StrictHttpResponse<AddQuestionAnswerResponse>> {
    let __params = this.newParams();
    let __headers = new HttpHeaders();
    let __body: any = null;
    __body = command;
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
   * @param command undefined
   */
  QuestionsAddQuestionAnswer(command: AddQuestionAnswerCommand): __Observable<AddQuestionAnswerResponse> {
    return this.QuestionsAddQuestionAnswerResponse(command).pipe(
      __map(_r => _r.body as AddQuestionAnswerResponse)
    );
  }

  /**
   * @param command undefined
   */
  QuestionsEditQuestionAnswerResponse(command: EditQuestionAnswerCommand): __Observable<__StrictHttpResponse<EditQuestionAnswerResponse>> {
    let __params = this.newParams();
    let __headers = new HttpHeaders();
    let __body: any = null;
    __body = command;
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
   * @param command undefined
   */
  QuestionsEditQuestionAnswer(command: EditQuestionAnswerCommand): __Observable<EditQuestionAnswerResponse> {
    return this.QuestionsEditQuestionAnswerResponse(command).pipe(
      __map(_r => _r.body as EditQuestionAnswerResponse)
    );
  }

  /**
   * @param command undefined
   */
  QuestionsDeleteQuestionAnswerResponse(command: DeleteQuestionAnswerCommand): __Observable<__StrictHttpResponse<VoidResponse>> {
    let __params = this.newParams();
    let __headers = new HttpHeaders();
    let __body: any = null;
    __body = command;
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
   * @param command undefined
   */
  QuestionsDeleteQuestionAnswer(command: DeleteQuestionAnswerCommand): __Observable<VoidResponse> {
    return this.QuestionsDeleteQuestionAnswerResponse(command).pipe(
      __map(_r => _r.body as VoidResponse)
    );
  }

  /**
   * @param request undefined
   */
  QuestionsListQuestionAnswersResponse(request: ListQuestionAnswersQuery): __Observable<__StrictHttpResponse<ListQuestionAnswersResponse>> {
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
  QuestionsListQuestionAnswers(request: ListQuestionAnswersQuery): __Observable<ListQuestionAnswersResponse> {
    return this.QuestionsListQuestionAnswersResponse(request).pipe(
      __map(_r => _r.body as ListQuestionAnswersResponse)
    );
  }

  /**
   * @param query undefined
   */
  QuestionsGetQuestionAnswerResponse(query: GetQuestionAnswerQuery): __Observable<__StrictHttpResponse<GetQuestionAnswerResponse>> {
    let __params = this.newParams();
    let __headers = new HttpHeaders();
    let __body: any = null;
    __body = query;
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
   * @param query undefined
   */
  QuestionsGetQuestionAnswer(query: GetQuestionAnswerQuery): __Observable<GetQuestionAnswerResponse> {
    return this.QuestionsGetQuestionAnswerResponse(query).pipe(
      __map(_r => _r.body as GetQuestionAnswerResponse)
    );
  }

  /**
   * @param command undefined
   */
  QuestionsAddAnswerVoteResponse(command: AddAnswerVoteCommand): __Observable<__StrictHttpResponse<AddAnswerVoteResponse>> {
    let __params = this.newParams();
    let __headers = new HttpHeaders();
    let __body: any = null;
    __body = command;
    let req = new HttpRequest<any>(
      'POST',
      this.rootUrl + `/Questions/AddAnswerVote`,
      __body,
      {
        headers: __headers,
        params: __params,
        responseType: 'json'
      });

    return this.http.request<any>(req).pipe(
      __filter(_r => _r instanceof HttpResponse),
      __map((_r) => {
        return _r as __StrictHttpResponse<AddAnswerVoteResponse>;
      })
    );
  }
  /**
   * @param command undefined
   */
  QuestionsAddAnswerVote(command: AddAnswerVoteCommand): __Observable<AddAnswerVoteResponse> {
    return this.QuestionsAddAnswerVoteResponse(command).pipe(
      __map(_r => _r.body as AddAnswerVoteResponse)
    );
  }

  /**
   * @param command undefined
   */
  QuestionsAddQuestionVoteResponse(command: AddQuestionVoteCommand): __Observable<__StrictHttpResponse<AddQuestionVoteResponse>> {
    let __params = this.newParams();
    let __headers = new HttpHeaders();
    let __body: any = null;
    __body = command;
    let req = new HttpRequest<any>(
      'POST',
      this.rootUrl + `/Questions/AddQuestionVote`,
      __body,
      {
        headers: __headers,
        params: __params,
        responseType: 'json'
      });

    return this.http.request<any>(req).pipe(
      __filter(_r => _r instanceof HttpResponse),
      __map((_r) => {
        return _r as __StrictHttpResponse<AddQuestionVoteResponse>;
      })
    );
  }
  /**
   * @param command undefined
   */
  QuestionsAddQuestionVote(command: AddQuestionVoteCommand): __Observable<AddQuestionVoteResponse> {
    return this.QuestionsAddQuestionVoteResponse(command).pipe(
      __map(_r => _r.body as AddQuestionVoteResponse)
    );
  }

  /**
   * @param command undefined
   */
  QuestionsDeleteQuestionVoteResponse(command: DeleteQuestionVoteCommand): __Observable<__StrictHttpResponse<VoidResponse>> {
    let __params = this.newParams();
    let __headers = new HttpHeaders();
    let __body: any = null;
    __body = command;
    let req = new HttpRequest<any>(
      'POST',
      this.rootUrl + `/Questions/DeleteQuestionVote`,
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
   * @param command undefined
   */
  QuestionsDeleteQuestionVote(command: DeleteQuestionVoteCommand): __Observable<VoidResponse> {
    return this.QuestionsDeleteQuestionVoteResponse(command).pipe(
      __map(_r => _r.body as VoidResponse)
    );
  }

  /**
   * @param query undefined
   */
  QuestionsSearchByKeywordResponse(query: SearchByKeywordQuery): __Observable<__StrictHttpResponse<SearchByKeywordResponse>> {
    let __params = this.newParams();
    let __headers = new HttpHeaders();
    let __body: any = null;
    __body = query;
    let req = new HttpRequest<any>(
      'POST',
      this.rootUrl + `/Questions/SearchByKeyword`,
      __body,
      {
        headers: __headers,
        params: __params,
        responseType: 'json'
      });

    return this.http.request<any>(req).pipe(
      __filter(_r => _r instanceof HttpResponse),
      __map((_r) => {
        return _r as __StrictHttpResponse<SearchByKeywordResponse>;
      })
    );
  }
  /**
   * @param query undefined
   */
  QuestionsSearchByKeyword(query: SearchByKeywordQuery): __Observable<SearchByKeywordResponse> {
    return this.QuestionsSearchByKeywordResponse(query).pipe(
      __map(_r => _r.body as SearchByKeywordResponse)
    );
  }

  /**
   * @param query undefined
   */
  QuestionsGetMostRecentQuestionsResponse(query: GetMostRecentQuestionsQuery): __Observable<__StrictHttpResponse<GetMostRecentQuestionsResponse>> {
    let __params = this.newParams();
    let __headers = new HttpHeaders();
    let __body: any = null;
    __body = query;
    let req = new HttpRequest<any>(
      'POST',
      this.rootUrl + `/Questions/GetMostRecentQuestions`,
      __body,
      {
        headers: __headers,
        params: __params,
        responseType: 'json'
      });

    return this.http.request<any>(req).pipe(
      __filter(_r => _r instanceof HttpResponse),
      __map((_r) => {
        return _r as __StrictHttpResponse<GetMostRecentQuestionsResponse>;
      })
    );
  }
  /**
   * @param query undefined
   */
  QuestionsGetMostRecentQuestions(query: GetMostRecentQuestionsQuery): __Observable<GetMostRecentQuestionsResponse> {
    return this.QuestionsGetMostRecentQuestionsResponse(query).pipe(
      __map(_r => _r.body as GetMostRecentQuestionsResponse)
    );
  }
}

module QuestionsService {
}

export { QuestionsService }
