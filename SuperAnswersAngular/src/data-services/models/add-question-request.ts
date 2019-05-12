/* tslint:disable */
export interface AddQuestionRequest {
  questionTitle?: string;
  content?: string;
  tags?: string;
  notifyMeOnResponse: boolean;
  userId?: string;
}
