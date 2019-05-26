/* tslint:disable */
import { Response } from './response';
import { Question } from './question';
export interface SearchByKeywordResponse extends Response {
  questions?: Array<Question>;
}
