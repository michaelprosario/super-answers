/* tslint:disable */
import { CommandOfAddQuestionAnswerResponse } from './command-of-add-question-answer-response';
export interface AddQuestionAnswerCommand extends CommandOfAddQuestionAnswerResponse {
  questionId?: string;
  answer?: string;
  userId?: string;
}
