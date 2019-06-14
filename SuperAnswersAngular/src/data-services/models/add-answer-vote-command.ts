/* tslint:disable */
import { CommandOfAddAnswerVoteResponse } from './command-of-add-answer-vote-response';
export interface AddAnswerVoteCommand extends CommandOfAddAnswerVoteResponse {
  questionAnswerId?: string;
  userId?: string;
}
