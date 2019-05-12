import { Component, OnInit } from '@angular/core';
import { QuestionsService } from 'src/data-services/services';
import { first } from 'rxjs/operators';
import { AddQuestionRequest } from 'src/data-services/models';

@Component({
  selector: 'app-ask-question',
  templateUrl: './ask-question.component.html',
  styleUrls: ['./ask-question.component.css']
})
export class AskQuestionComponent implements OnInit {

  private questionTitle: string;
  private questionContent: string;
  private questionTags: string;

  constructor(
    private questionsService: QuestionsService
  ) { }

  ngOnInit() {
  }

  handleAskQuestion(){
    let addQuestionRequest = {
      questionTitle: this.questionTitle,
      content: this.questionContent,
      tags: this.questionTags,
      notifyMeOnResponse: false
    }

    this.questionsService.QuestionsAddQuestion(addQuestionRequest)
    .pipe(first())
    .subscribe(response => 
    { 
        console.log(response);
    });

    
    console.log("saved.")
  }

}
