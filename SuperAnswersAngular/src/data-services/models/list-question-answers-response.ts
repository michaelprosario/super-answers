/* tslint:disable */
import { Response } from './response';
import { QuestionAnswer } from './question-answer';
export interface ListQuestionAnswersResponse extends Response {
  records?: Array<QuestionAnswer>;
}
