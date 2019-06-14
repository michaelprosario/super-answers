/* tslint:disable */
import { Injectable } from '@angular/core';
import { HttpClient, HttpRequest, HttpResponse, HttpHeaders } from '@angular/common/http';
import { BaseService as __BaseService } from '../base-service';
import { ApiConfiguration as __Configuration } from '../api-configuration';
import { StrictHttpResponse as __StrictHttpResponse } from '../strict-http-response';
import { Observable as __Observable } from 'rxjs';
import { map as __map, filter as __filter } from 'rxjs/operators';

import { UserDto } from '../models/user-dto';
import { RegisterUserResponse } from '../models/register-user-response';
import { RegisterUserCommand } from '../models/register-user-command';
@Injectable({
  providedIn: 'root',
})
class UsersService extends __BaseService {
  static readonly UsersAuthenticatePath = '/Users/Authenticate';
  static readonly UsersRegisterUserPath = '/Users/RegisterUser';

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
   * @param request undefined
   */
  UsersRegisterUserResponse(request: RegisterUserCommand): __Observable<__StrictHttpResponse<RegisterUserResponse>> {
    let __params = this.newParams();
    let __headers = new HttpHeaders();
    let __body: any = null;
    __body = request;
    let req = new HttpRequest<any>(
      'POST',
      this.rootUrl + `/Users/RegisterUser`,
      __body,
      {
        headers: __headers,
        params: __params,
        responseType: 'json'
      });

    return this.http.request<any>(req).pipe(
      __filter(_r => _r instanceof HttpResponse),
      __map((_r) => {
        return _r as __StrictHttpResponse<RegisterUserResponse>;
      })
    );
  }
  /**
   * @param request undefined
   */
  UsersRegisterUser(request: RegisterUserCommand): __Observable<RegisterUserResponse> {
    return this.UsersRegisterUserResponse(request).pipe(
      __map(_r => _r.body as RegisterUserResponse)
    );
  }
}

module UsersService {
}

export { UsersService }
