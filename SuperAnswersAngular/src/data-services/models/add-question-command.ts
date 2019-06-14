/* tslint:disable */
import { CommandOfAddQuestionResponse } from './command-of-add-question-response';
export interface AddQuestionCommand extends CommandOfAddQuestionResponse {
  questionTitle?: string;
  content?: string;
  tags?: string;
  notifyMeOnResponse: boolean;
  userId?: string;
}
