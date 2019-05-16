import { Component, OnInit } from '@angular/core';
import { QuestionsService } from 'src/data-services/services';
import { first } from 'rxjs/operators';
import { AddQuestionRequest, ListQuestionsRequest } from 'src/data-services/models';
import { SiteTopRowComponent } from 'src/app/site-top-row/site-top-row.component';
import { Router } from '@angular/router';

@Component({
  selector: 'app-ask-question',
  templateUrl: './ask-question.component.html',
  styleUrls: ['./ask-question.component.css']
})
export class AskQuestionComponent implements OnInit {

  private questionTitle: string;
  private questionContent: string;
  private questionTags: string;
  private selectedTags = [];
  private validTags = [];
  private formErrors = [];

  constructor(
    private questionsService: QuestionsService,
    private router: Router
  ) { }

  ngOnInit() 
  {
    let request: ListQuestionsRequest = {}
    this.questionsService.QuestionsListQuestionTags(request).pipe(first()).subscribe(
      response => {
        response.records.map(r => this.validTags.push(r.title));
      }
    )

    document.getElementById("txtQuestion").focus();
  }

  handleAskQuestion() {
    this.formErrors.length = 0;

    let tagsArray = [];
    this.selectedTags.map(t => tagsArray.push(t.value) );
    let addQuestionRequest : AddQuestionRequest = {
      questionTitle: this.questionTitle,
      content: this.questionContent,
      tags: tagsArray.toString(),
      notifyMeOnResponse: false
    }

    this.questionsService.QuestionsAddQuestion(addQuestionRequest)
    .pipe(first())
    .subscribe(response => 
    {         
        if(response.validationErrors && response.validationErrors.length > 0){
          response.validationErrors.map(error => this.formErrors.push(error.errorMessage));
        }else{
          this.router.navigate(['/viewQuestion/' + response.id]);
        }
    });    
  }

}
