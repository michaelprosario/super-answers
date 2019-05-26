/* tslint:disable */
export interface Question {
  createdBy?: string;
  id?: string;
  tags?: string;
  tagArray?: Array<string>;
  content?: string;
  contentAsMarkDown?: string;
  questionTitle?: string;
  updatedBy?: string;
  createdAt: string;
  updatedAt: string;
  votes: number;
  answerCount: number;
}
