import { Component, OnInit } from '@angular/core';
import { Question, SearchByKeywordQuery } from 'src/data-services/models';
import { ActivatedRoute, Router } from '@angular/router';
import { QuestionsService } from 'src/data-services/services';
import { first } from 'rxjs/operators';

@Component({
  selector: 'app-question-search',
  templateUrl: './question-search.component.html',
  styleUrls: ['./question-search.component.scss']
})
export class QuestionSearchComponent implements OnInit {

  searchResults: Question[];
  terms: string;

  constructor(
    private route: ActivatedRoute,
    private questionsService: QuestionsService,
    private router: Router
  ) {
    this.searchResults = [];
    this.router.routeReuseStrategy.shouldReuseRoute = () => false;
  }

  handleAskQuestion(){
    this.router.navigate(['/askQuestion']);
  }  

  ngOnInit() {
    this.terms = this.route.snapshot.paramMap.get('terms');

    let query: SearchByKeywordQuery = {};
    query.searchTerms = this.terms;
    query.userId = "test";
    
    let current = this;
    this.questionsService.QuestionsSearchByKeyword(query)
      .pipe(first()).subscribe(
        response => {
          current.searchResults = response.questions;
        }
      )
  }
}
