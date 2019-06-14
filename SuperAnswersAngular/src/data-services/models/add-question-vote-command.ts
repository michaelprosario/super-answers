/* tslint:disable */
import { CommandOfAddQuestionVoteResponse } from './command-of-add-question-vote-response';
export interface AddQuestionVoteCommand extends CommandOfAddQuestionVoteResponse {
  questionId?: string;
  userId?: string;
}
