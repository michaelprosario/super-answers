import { Component, OnInit } from '@angular/core';
import { Question, GetMostRecentQuestionsQuery } from 'src/data-services/models';
import { ActivatedRoute, Router } from '@angular/router';
import { QuestionsService } from 'src/data-services/services';
import { first } from 'rxjs/operators';

@Component({
  selector: 'app-recent-questions',
  templateUrl: './recent-questions.component.html',
  styleUrls: ['./recent-questions.component.scss']
})
export class RecentQuestionsComponent implements OnInit {

  searchResults: Question[];

  constructor(
    private route: ActivatedRoute,
    private questionsService: QuestionsService,
    private router: Router
  ) {
    this.searchResults = [];
  }

  handleAskQuestion(){
    this.router.navigate(['/askQuestion']);
  }  

  ngOnInit() {

    let query: GetMostRecentQuestionsQuery = {};
    
    let current = this;
    this.questionsService.QuestionsGetMostRecentQuestions(query)
      .pipe(first()).subscribe(
        response => {
          current.searchResults = response.questions;
        }
      )
  }
}
