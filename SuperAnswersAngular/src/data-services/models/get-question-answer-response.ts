/* tslint:disable */
import { Response } from './response';
import { QuestionAnswer } from './question-answer';
import { Question } from './question';
export interface GetQuestionAnswerResponse extends Response {
  questionAnswer?: QuestionAnswer;
  question?: Question;
}
