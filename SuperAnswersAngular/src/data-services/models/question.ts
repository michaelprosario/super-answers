/* tslint:disable */
export interface Question {
  contentAsMarkDown?: string;
  id?: string;
  tags?: string;
  tagArray?: Array<string>;
  content?: string;
  questionTitle?: string;
  createdBy?: string;
  updatedBy?: string;
  createdAt: string;
  updatedAt: string;
  votes: number;
}
