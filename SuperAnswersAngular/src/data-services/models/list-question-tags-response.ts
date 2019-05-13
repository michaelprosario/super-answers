/* tslint:disable */
import { Response } from './response';
import { QuestionTag } from './question-tag';
export interface ListQuestionTagsResponse extends Response {
  records?: Array<QuestionTag>;
}
