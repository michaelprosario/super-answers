/* tslint:disable */
import { ResponseCode } from './response-code';
import { ValidationFailure } from './validation-failure';
export interface Response {
  code: ResponseCode;
  message?: string;
  validationErrors?: Array<ValidationFailure>;
}
