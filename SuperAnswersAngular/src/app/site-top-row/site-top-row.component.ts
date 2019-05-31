import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';

@Component({
  selector: 'app-site-top-row',
  templateUrl: './site-top-row.component.html',
  styleUrls: ['./site-top-row.component.scss']
})
export class SiteTopRowComponent implements OnInit {

  searchPhrase: string = '';
  
  constructor(
    private router: Router
  ) { }

  ngOnInit() {
  }

  keyDownFunction(event) {
    if(event.keyCode == 13) {
      this.router.navigate(['/searchQuestions/' + this.searchPhrase]);
    }
  }  
}
