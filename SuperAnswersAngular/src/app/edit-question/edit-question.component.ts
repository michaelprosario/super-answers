import { Component, OnInit } from '@angular/core';
import { Question, GetQuestionRequest, EditQuestionRequest } from 'src/data-services/models';
import { ActivatedRoute, Router } from '@angular/router';
import { QuestionsService } from 'src/data-services/services';
import { first } from 'rxjs/operators';

@Component({
  selector: 'app-edit-question',
  templateUrl: './edit-question.component.html',
  styleUrls: ['./edit-question.component.css']
})
export class EditQuestionComponent implements OnInit {
  questionId: string;
  question: Question;
  answers = [];
  answer = '';
  private validTags = [];  
  private formErrors = [];  
  private selectedTags = [];

  constructor(
    private route: ActivatedRoute,
    private questionsService: QuestionsService,
    private router: Router
  ) {
    this.questionId = this.route.snapshot.paramMap.get('id');
    this.question = {
      questionTitle: '',
      createdAt: null,
      createdBy: '',
      updatedAt: null,
      updatedBy: '',
      votes:0
    }
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

    document.getElementById("txtQuestion").focus();

    let request: GetQuestionRequest = {};
    request.id = this.questionId;
    request.userId = "test";

    this.questionsService.QuestionsGetQuestion(request)
      .pipe(first()).subscribe(
        response => {
          this.question = response.question;
          console.log(this.question);
        }
      )
  }

  handleUpdateQuestion() {
    this.formErrors.length = 0;

    let tagsArray = [];
    this.question.tagArray.map(t => tagsArray.push(t.value) );
    let editQuestionRequest : EditQuestionRequest = {
      questionTitle: this.question.questionTitle,
      content: this.question.contentAsMarkDown,
      tags: tagsArray.toString(),
      notifyMeOnResponse: false,
      questionId: this.question.id
    }


    this.questionsService.QuestionsEditQuestion(editQuestionRequest)
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
