/* tslint:disable */
export interface Question {
  id?: string;
  questionTitle?: string;
  tags?: string;
  tagArray?: Array<string>;
  content?: string;
  createdBy?: string;
  updatedBy?: string;
  createdAt: string;
  updatedAt: string;
  votes: number;
}
