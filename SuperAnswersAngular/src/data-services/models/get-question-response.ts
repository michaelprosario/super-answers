/* tslint:disable */
import { Response } from './response';
import { Question } from './question';
import { QuestionAnswer } from './question-answer';
export interface GetQuestionResponse extends Response {
  question?: Question;
  answers?: [];
}
