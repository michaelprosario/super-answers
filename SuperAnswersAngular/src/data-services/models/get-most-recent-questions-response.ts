/* tslint:disable */
import { Response } from './response';
import { Question } from './question';
export interface GetMostRecentQuestionsResponse extends Response {
  questions?: Array<Question>;
}
