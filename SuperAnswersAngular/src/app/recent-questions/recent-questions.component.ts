import { Component, OnInit } from '@angular/core';
import { Question, GetMostRecentQuestionsRequest } from 'src/data-services/models';
import { ActivatedRoute, Router } from '@angular/router';
import { QuestionsService } from 'src/data-services/services';
import { first } from 'rxjs/operators';

@Component({
  selector: 'app-recent-questions',
  templateUrl: './recent-questions.component.html',
  styleUrls: ['./recent-questions.component.css']
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

  ngOnInit() {

    let request: GetMostRecentQuestionsRequest = {};
    request.userId = "test";
    
    let current = this;
    this.questionsService.QuestionsGetMostRecentQuestions(request)
      .pipe(first()).subscribe(
        response => {
          current.searchResults = response.questions;
        }
      )
  }
}
