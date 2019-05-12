/* tslint:disable */
import { Response } from './response';
import { Question } from './question';
export interface GetQuestionResponse extends Response {
  question?: Question;
}
