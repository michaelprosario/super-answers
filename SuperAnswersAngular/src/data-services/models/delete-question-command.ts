/* tslint:disable */
import { CommandOfVoidResponse } from './command-of-void-response';
export interface DeleteQuestionCommand extends CommandOfVoidResponse {
  id?: string;
  userId?: string;
}
