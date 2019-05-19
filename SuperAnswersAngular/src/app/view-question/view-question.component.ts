import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { QuestionsService } from 'src/data-services/services';
import { GetQuestionRequest, Question, AddQuestionAnswerRequest, AddQuestionVoteRequest } from 'src/data-services/models';
import { first } from 'rxjs/operators';
import { routerNgProbeToken } from '@angular/router/src/router_module';

@Component({
  selector: 'app-view-question',
  templateUrl: './view-question.component.html',
  styleUrls: ['./view-question.component.css']
})
export class ViewQuestionComponent implements OnInit {
  questionId: string;
  question: Question;
  answers = [];
  answer = '';

  constructor(
    private route: ActivatedRoute,
    private questionsService: QuestionsService,
    private router: Router
  ) {
    this.questionId = this.route.snapshot.paramMap.get('id');
    this.question = {
      tagArray: [],
      createdAt: null,
      updatedAt: null,
      votes: 0
    };
  }

  ngOnInit() {
    this.loadQuestionContent();
  }

  loadQuestionContent(){
    let request: GetQuestionRequest = {};
    request.id = this.questionId;
    request.userId = "test";

    this.questionsService.QuestionsGetQuestion(request)
      .pipe(first()).subscribe(
        response => {
          this.question = response.question;
          this.answers = response.answers;
        }
      )
  }

  handleQuestionVote(){
    const request: AddQuestionVoteRequest = {};
    request.questionId = this.questionId;
    request.userId = 'test';

    this.questionsService.QuestionsAddQuestionVote(request)
      .pipe(first()).subscribe(
        response => {
          if (response.message === null) {
            this.question.votes++;
          }
        }
      );
  }

  handleAskQuestion(){
    this.router.navigate(['/askQuestion']);
  }

  postAnswer(){
    if(this.answer.trim() === ''){
      alert('Enter a valid answer');
      return false;
    }

    let request: AddQuestionAnswerRequest = {
      answer: this.answer,
      questionId: this.questionId
    };

    this.questionsService.QuestionsAddQuestionAnswer(request)
      .pipe(first()).subscribe(
        response => {
          this.answer = '';
          this.loadQuestionContent();
        }
      )
  }

}
