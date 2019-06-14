import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { QuestionsService } from 'src/data-services/services';
import { GetQuestionQuery, Question, AddQuestionAnswerCommand, AddQuestionVoteCommand, AddAnswerVoteResponse, AddAnswerVoteCommand, QuestionAnswer } from 'src/data-services/models';
import { first } from 'rxjs/operators';
import { routerNgProbeToken } from '@angular/router/src/router_module';

@Component({
  selector: 'app-view-question',
  templateUrl: './view-question.component.html',
  styleUrls: ['./view-question.component.scss']
})
export class ViewQuestionComponent implements OnInit {
  questionId: string;
  question: Question;
  answers = [];
  answer = '';
  isLoading: boolean;

  constructor(
    private route: ActivatedRoute,
    private questionsService: QuestionsService,
    private router: Router
  ) {
    this.questionId = this.route.snapshot.paramMap.get('id');
    this.isLoading = true;
  }

  ngOnInit() {
    this.loadQuestionContent();
  }

  loadQuestionContent(){
    let query: GetQuestionQuery = {};
    query.id = this.questionId;
    query.userId = "test";

    this.questionsService.QuestionsGetQuestion(query)
      .pipe(first()).subscribe(
        response => {
          this.question = response.question;
          this.answers = response.answers;
          this.isLoading = false;
        }
      )
  }

  handleQuestionVote(){
    const command: AddQuestionVoteCommand = {};
    command.questionId = this.questionId;
    command.userId = 'test';

    this.questionsService.QuestionsAddQuestionVote(command)
      .pipe(first()).subscribe(
        response => {
          if (response.message === null) {
            this.question.votes++;
          }
        }
      );
  }

  handleAnswerVote(answer) {   
    const command: AddAnswerVoteCommand = {};
    command.questionAnswerId = answer.id;
    command.userId = 'test';

    this.questionsService.QuestionsAddAnswerVote(command)
      .pipe(first()).subscribe(
        response => {
          if (response.message === null) {
            answer.votes++;
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

    let command: AddQuestionAnswerCommand = {
      answer: this.answer,
      questionId: this.questionId
    };

    this.questionsService.QuestionsAddQuestionAnswer(command)
      .pipe(first()).subscribe(
        response => {
          this.answer = '';
          this.loadQuestionContent();
        }
      )
  }

  handleEditQuestion(){
    this.router.navigate(['/editQuestion/' + this.questionId]);
  }

  editAnswer(answer: QuestionAnswer){
    this.router.navigate(['/editQuestionAnswer/' + answer.id]);
  }
}
