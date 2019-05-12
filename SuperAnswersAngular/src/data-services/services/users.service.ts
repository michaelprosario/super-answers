/* tslint:disable */
import { Injectable } from '@angular/core';
import { HttpClient, HttpRequest, HttpResponse, HttpHeaders } from '@angular/common/http';
import { BaseService as __BaseService } from '../base-service';
import { ApiConfiguration as __Configuration } from '../api-configuration';
import { StrictHttpResponse as __StrictHttpResponse } from '../strict-http-response';
import { Observable as __Observable } from 'rxjs';
import { map as __map, filter as __filter } from 'rxjs/operators';

import { UserDto } from '../models/user-dto';
@Injectable({
  providedIn: 'root',
})
class UsersService extends __BaseService {
  static readonly UsersAuthenticatePath = '/Users/Authenticate';
  static readonly UsersRegisterPath = '/Users/Register';
  static readonly UsersGetAllPath = '/Users/GetAll';
  static readonly UsersGetByIdPath = '/Users/GetById/{id}';
  static readonly UsersDeletePath = '/Users/Delete/{id}';

  constructor(
    config: __Configuration,
    http: HttpClient
  ) {
    super(config, http);
  }

  /**
   * @param userDto undefined
   */
  UsersAuthenticateResponse(userDto: UserDto): __Observable<__StrictHttpResponse<Blob>> {
    let __params = this.newParams();
    let __headers = new HttpHeaders();
    let __body: any = null;
    __body = userDto;
    let req = new HttpRequest<any>(
      'POST',
      this.rootUrl + `/Users/Authenticate`,
      __body,
      {
        headers: __headers,
        params: __params,
        responseType: 'blob'
      });

    return this.http.request<any>(req).pipe(
      __filter(_r => _r instanceof HttpResponse),
      __map((_r) => {
        return _r as __StrictHttpResponse<Blob>;
      })
    );
  }
  /**
   * @param userDto undefined
   */
  UsersAuthenticate(userDto: UserDto): __Observable<Blob> {
    return this.UsersAuthenticateResponse(userDto).pipe(
      __map(_r => _r.body as Blob)
    );
  }

  /**
   * @param userDto undefined
   */
  UsersRegisterResponse(userDto: UserDto): __Observable<__StrictHttpResponse<Blob>> {
    let __params = this.newParams();
    let __headers = new HttpHeaders();
    let __body: any = null;
    __body = userDto;
    let req = new HttpRequest<any>(
      'POST',
      this.rootUrl + `/Users/Register`,
      __body,
      {
        headers: __headers,
        params: __params,
        responseType: 'blob'
      });

    return this.http.request<any>(req).pipe(
      __filter(_r => _r instanceof HttpResponse),
      __map((_r) => {
        return _r as __StrictHttpResponse<Blob>;
      })
    );
  }
  /**
   * @param userDto undefined
   */
  UsersRegister(userDto: UserDto): __Observable<Blob> {
    return this.UsersRegisterResponse(userDto).pipe(
      __map(_r => _r.body as Blob)
    );
  }
  UsersGetAllResponse(): __Observable<__StrictHttpResponse<Blob>> {
    let __params = this.newParams();
    let __headers = new HttpHeaders();
    let __body: any = null;
    let req = new HttpRequest<any>(
      'POST',
      this.rootUrl + `/Users/GetAll`,
      __body,
      {
        headers: __headers,
        params: __params,
        responseType: 'blob'
      });

    return this.http.request<any>(req).pipe(
      __filter(_r => _r instanceof HttpResponse),
      __map((_r) => {
        return _r as __StrictHttpResponse<Blob>;
      })
    );
  }  UsersGetAll(): __Observable<Blob> {
    return this.UsersGetAllResponse().pipe(
      __map(_r => _r.body as Blob)
    );
  }

  /**
   * @param id undefined
   */
  UsersGetByIdResponse(id: null | string): __Observable<__StrictHttpResponse<Blob>> {
    let __params = this.newParams();
    let __headers = new HttpHeaders();
    let __body: any = null;

    let req = new HttpRequest<any>(
      'POST',
      this.rootUrl + `/Users/GetById/${id}`,
      __body,
      {
        headers: __headers,
        params: __params,
        responseType: 'blob'
      });

    return this.http.request<any>(req).pipe(
      __filter(_r => _r instanceof HttpResponse),
      __map((_r) => {
        return _r as __StrictHttpResponse<Blob>;
      })
    );
  }
  /**
   * @param id undefined
   */
  UsersGetById(id: null | string): __Observable<Blob> {
    return this.UsersGetByIdResponse(id).pipe(
      __map(_r => _r.body as Blob)
    );
  }

  /**
   * @param id undefined
   */
  UsersDeleteResponse(id: null | string): __Observable<__StrictHttpResponse<Blob>> {
    let __params = this.newParams();
    let __headers = new HttpHeaders();
    let __body: any = null;

    let req = new HttpRequest<any>(
      'POST',
      this.rootUrl + `/Users/Delete/${id}`,
      __body,
      {
        headers: __headers,
        params: __params,
        responseType: 'blob'
      });

    return this.http.request<any>(req).pipe(
      __filter(_r => _r instanceof HttpResponse),
      __map((_r) => {
        return _r as __StrictHttpResponse<Blob>;
      })
    );
  }
  /**
   * @param id undefined
   */
  UsersDelete(id: null | string): __Observable<Blob> {
    return this.UsersDeleteResponse(id).pipe(
      __map(_r => _r.body as Blob)
    );
  }
}

module UsersService {
}

export { UsersService }
