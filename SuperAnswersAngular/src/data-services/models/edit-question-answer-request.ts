/* tslint:disable */
export interface EditQuestionAnswerRequest {
  id?: string;
  questionId?: string;
  answer?: string;
  createdAt: string;
  createdBy?: string;
  updatedAt: string;
  updatedBy?: string;
  votes: number;
  userId?: string;
}
