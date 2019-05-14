import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { QuestionsService } from 'src/data-services/services';
import { GetQuestionRequest } from 'src/data-services/models';
import { first } from 'rxjs/operators';

@Component({
  selector: 'app-view-question',
  templateUrl: './view-question.component.html',
  styleUrls: ['./view-question.component.css']
})
export class ViewQuestionComponent implements OnInit {
  questionId: string;

  constructor(
    private route: ActivatedRoute,
    private questionsService: QuestionsService,
    private router: Router
  ) {
    this.questionId = this.route.snapshot.paramMap.get('id');
  }

  ngOnInit() {
    let request: GetQuestionRequest = {};
    request.id = this.questionId;
    request.userId = "test";

    
    this.questionsService.QuestionsGetQuestion(request)
      .pipe(first()).subscribe(
        response => {
          console.log(response.question)
        }
      )
  }

}
