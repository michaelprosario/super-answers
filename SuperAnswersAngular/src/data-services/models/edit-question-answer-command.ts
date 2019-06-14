/* tslint:disable */
import { CommandOfEditQuestionAnswerResponse } from './command-of-edit-question-answer-response';
export interface EditQuestionAnswerCommand extends CommandOfEditQuestionAnswerResponse {
  id?: string;
  answer?: string;
  userId?: string;
}
