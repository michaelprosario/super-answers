import { Component, OnInit } from '@angular/core';
import { QuestionsService } from 'src/data-services/services';
import { first } from 'rxjs/operators';
import { AddQuestionCommand, ListQuestionsQuery } from 'src/data-services/models';
import { SiteTopRowComponent } from 'src/app/site-top-row/site-top-row.component';
import { Router } from '@angular/router';

@Component({
  selector: 'app-ask-question',
  templateUrl: './ask-question.component.html',
  styleUrls: ['./ask-question.component.scss']
})
export class AskQuestionComponent implements OnInit {

  questionTitle: string;
  questionContent: string;
  selectedTags = [];
  validTags = [];
  formErrors = [];

  constructor(
    private questionsService: QuestionsService,
    private router: Router
  ) { 
    
  }

  ngOnInit() 
  {
    let query: ListQuestionsQuery = {}
    this.questionsService.QuestionsListQuestionTags(query).pipe(first()).subscribe(
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
    let addQuestionCommand : AddQuestionCommand = {
      questionTitle: this.questionTitle,
      content: this.questionContent,
      tags: tagsArray.toString(),
      notifyMeOnResponse: false
    }

    this.questionsService.QuestionsAddQuestion(addQuestionCommand)
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
