/* tslint:disable */
import { Response } from './response';
import { QuestionAnswer } from './question-answer';
export interface GetQuestionAnswerResponse extends Response {
  questionAnswer?: QuestionAnswer;
}
