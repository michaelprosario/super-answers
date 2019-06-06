import { Component, OnInit } from '@angular/core';
import { Question, GetQuestionRequest, AddQuestionVoteRequest, EditQuestionAnswerRequest, GetQuestionAnswerRequest, QuestionAnswer } from 'src/data-services/models';
import { ActivatedRoute, Router } from '@angular/router';
import { QuestionsService } from 'src/data-services/services';
import { first } from 'rxjs/operators';

@Component({
  selector: 'app-edit-question-answer',
  templateUrl: './edit-question-answer.component.html',
  styleUrls: ['./edit-question-answer.component.scss']
})
export class EditQuestionAnswerComponent implements OnInit {
  questionId: string;
  questionAnswerId: string;
  question: Question;
  answer: QuestionAnswer;
  isLoading: boolean;

  constructor(
    private route: ActivatedRoute,
    private questionsService: QuestionsService,
    private router: Router
  ) {
    this.questionAnswerId = this.route.snapshot.paramMap.get('id');
    this.isLoading = true;

    this.answer = {
      answer: '',
      createdAt: null,
      updatedAt: null,
      votes: 0
    }
  }

  ngOnInit() {
    this.loadQuestionContent();
  }

  loadQuestionContent(){
    let request: GetQuestionAnswerRequest = {};
    request.id = this.questionAnswerId;
    request.userId = "test";

    this.questionsService.QuestionsGetQuestionAnswer(request)
      .pipe(first()).subscribe(
        response => {
          this.question = response.question;
          this.answer = response.questionAnswer;
          this.isLoading = false;
        }
      )
  }

  handleAskQuestion(){
    this.router.navigate(['/askQuestion']);
  }

  viewQuestion(){
    this.router.navigate(['/viewQuestion/' + this.answer.questionId])
  }

  handleEditQuestion(){
    this.router.navigate(['/editQuestion/' + this.questionId]);
  }  

  postAnswer(){
    if(this.answer.answer === ''){
      alert('Enter a valid answer');
      return false;
    }

    let request: EditQuestionAnswerRequest = {
      answer: this.answer.answer,  
      id: this.questionAnswerId  
    };

    this.questionsService.QuestionsEditQuestionAnswer(request)
      .pipe(first()).subscribe(
        response => {
          this.viewQuestion();
        }
      )
  }
}
