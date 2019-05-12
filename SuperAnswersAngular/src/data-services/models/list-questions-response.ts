/* tslint:disable */
import { Response } from './response';
import { Question } from './question';
export interface ListQuestionsResponse extends Response {
  records?: Array<Question>;
}
