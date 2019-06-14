/* tslint:disable */
import { CommandOfEditQuestionResponse } from './command-of-edit-question-response';
export interface EditQuestionCommand extends CommandOfEditQuestionResponse {
  questionTitle?: string;
  content?: string;
  tags?: string;
  notifyMeOnResponse: boolean;
  userId?: string;
  questionId?: string;
}
