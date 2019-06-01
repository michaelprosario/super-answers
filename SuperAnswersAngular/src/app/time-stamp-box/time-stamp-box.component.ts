import { Component, OnInit, Input } from '@angular/core';
import { Question } from 'src/data-services/models';

@Component({
  selector: 'app-time-stamp-box',
  templateUrl: './time-stamp-box.component.html',
  styleUrls: ['./time-stamp-box.component.scss']
})
export class TimeStampBoxComponent implements OnInit {

  constructor() { }

  @Input() record: any;
  ngOnInit() {
  }

}
