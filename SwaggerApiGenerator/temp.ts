

export class AddQuestionResponse {
}


export class Response {
  code: any;  
  message: string;  
  validationErrors: any;  
}


export class ResponseCode {
}


export class ValidationFailure {
  propertyName: string;  
  errorMessage: string;  
  attemptedValue: any;  
  customState: any;  
  severity: any;  
  errorCode: string;  
  formattedMessageArguments: any;  
  formattedMessagePlaceholderValues: any;  
  resourceName: string;  
}


export class Severity {
}


export class AddQuestionRequest {
  questionTitle: string;  
  content: string;  
  tags: string;  
  notifyMeOnResponse: boolean;  
  userId: string;  
}


export class EditQuestionResponse {
}


export class EditQuestionRequest {
  questionTitle: string;  
  content: string;  
  tags: string;  
  notifyMeOnResponse: boolean;  
  userId: string;  
  questionId: string;  
}


export class VoidResponse {
}


export class DeleteQuestionRequest {
  id: string;  
  userId: string;  
}


export class ListQuestionsResponse {
}


export class Question {
  id: string;  
  questionTitle: string;  
  tags: string;  
  tagArray: any;  
  content: string;  
  createdBy: string;  
  updatedBy: string;  
  createdAt: string;  
  updatedAt: string;  
  votes: number;  
}

export class ListQuestionsRequest {
  userId: string;  
}

export class GetQuestionResponse {
}

export class QuestionAnswer {
  questionId: string;  
  answer: string;  
  createdAt: string;  
  createdBy: string;  
  updatedAt: string;  
  updatedBy: string;  
  votes: number;  
  id: string;  
}

export class GetQuestionRequest {
  id: string;  
  userId: string;  
}

export class AddQuestionTagResponse {
}

export class AddQuestionTagRequest {
  title: string;  
  createdAt: string;  
  createdBy: string;  
  updatedAt: string;  
  updatedBy: string;  
  userId: string;  
}

export class DeleteQuestionTagRequest {
  id: string;  
  userId: string;  
}


export class ListQuestionTagsResponse {
}


export class QuestionTag {
  title: string;  
  createdAt: string;  
  createdBy: string;  
  updatedAt: string;  
  updatedBy: string;  
  id: string;  
}


export class ListQuestionTagsRequest {
  userId: string;  
}


export class AddQuestionAnswerResponse {
}


export class AddQuestionAnswerRequest {
  questionId: string;  
  answer: string;  
  userId: string;  
}


export class EditQuestionAnswerResponse {
}


export class EditQuestionAnswerRequest {
  id: string;  
  questionId: string;  
  answer: string;  
  createdAt: string;  
  createdBy: string;  
  updatedAt: string;  
  updatedBy: string;  
  votes: number;  
  userId: string;  
}


export class DeleteQuestionAnswerRequest {
  id: string;  
  userId: string;  
}


export class ListQuestionAnswersResponse {
}


export class ListQuestionAnswersRequest {
  userId: string;  
}


export class GetQuestionAnswerResponse {
}


export class GetQuestionAnswerRequest {
  id: string;  
  userId: string;  
}


export class AddQuestionVoteResponse {
}


export class AddQuestionVoteRequest {
  questionId: string;  
  createdAt: string;  
  createdBy: string;  
  updatedAt: string;  
  updatedBy: string;  
  userId: string;  
}


export class DeleteQuestionVoteRequest {
  id: string;  
  userId: string;  
}


export class UserDto {
  id: string;  
  firstName: string;  
  lastName: string;  
  username: string;  
  password: string;  
}
