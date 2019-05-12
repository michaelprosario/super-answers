/* tslint:disable */
export interface EditQuestionRequest {
  questionTitle?: string;
  content?: string;
  tags?: string;
  notifyMeOnResponse: boolean;
  userId?: string;
  questionId?: string;
}
