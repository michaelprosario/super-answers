import { Component, OnInit } from '@angular/core';
import { Question, GetQuestionQuery, EditQuestionCommand } from 'src/data-services/models';
import { ActivatedRoute, Router } from '@angular/router';
import { QuestionsService } from 'src/data-services/services';
import { first } from 'rxjs/operators';

@Component({
  selector: 'app-edit-question',
  templateUrl: './edit-question.component.html',
  styleUrls: ['./edit-question.component.scss']
})
export class EditQuestionComponent implements OnInit {
  questionId: string;
  question: Question;
  answers = [];
  answer = '';
  validTags = [];  
  formErrors = [];  
  selectedTags = [];
  isLoading : boolean;

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

  loadQuestionContent() {
    
    this.questionsService.QuestionsListQuestionTags({}).pipe(first()).subscribe(
      response => {
        response.records.map(r => this.validTags.push(r.title));
      }
    )

    let query: GetQuestionQuery = {};
    query.id = this.questionId;
    query.userId = "test";

    this.questionsService.QuestionsGetQuestion(query)
      .pipe(first()).subscribe(
        response => {
          this.question = response.question;
          this.isLoading = false;
        }
      )
  }

  viewQuestion(){
    this.router.navigate(['/viewQuestion/' + this.questionId])
  }  

  handleUpdateQuestion() {
    this.formErrors.length = 0;

    let tagsArray = [];
    
    this.question.tagArray.map(t => tagsArray.push(t) );
    let editQuestionCommand : EditQuestionCommand = {
      questionTitle: this.question.questionTitle,
      content: this.question.contentAsMarkDown,
      tags: tagsArray.toString(),
      notifyMeOnResponse: false,
      questionId: this.question.id
    }

    this.questionsService.QuestionsEditQuestion(editQuestionCommand)
    .pipe(first())
    .subscribe(response => 
    {         
        if(response.validationErrors && response.validationErrors.length > 0){
          response.validationErrors.map(error => this.formErrors.push(error.errorMessage));
        }else{
          this.router.navigate(['/viewQuestion/' + this.question.id]);
        }
    });    
  }  

}
