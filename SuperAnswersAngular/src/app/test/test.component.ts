import { Component, OnInit } from '@angular/core';
import { QuestionsService } from 'src/data-services/services';
import { ListQuestionsRequest } from 'src/data-services/models';
import { first } from 'rxjs/operators';

@Component({
  selector: 'app-test',
  templateUrl: './test.component.html',
  styleUrls: ['./test.component.css']
})
export class TestComponent implements OnInit {

  constructor(
    private questionsService: QuestionsService
  ) { }

  ngOnInit() {
    var request = {
      userId: "mrosario"
    };

    this.questionsService.QuestionsListQuestions(request)
    .pipe(first())
    .subscribe(response => 
    { 
        console.log(response);
        //this.getShoppingListItems();
    });

  }

}
