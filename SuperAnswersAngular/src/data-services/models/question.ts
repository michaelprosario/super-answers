import { QuestionAnswer } from './question-answer';

/* tslint:disable */
export interface Question {
  id?: string;
  questionTitle?: string;
  tags?: string;
  tagArray?: Array<string>;
  answers?: Array<QuestionAnswer>;
  content?: string;
  createdBy?: string;
  updatedBy?: string;
  createdAt: string;
  updatedAt: string;
}
