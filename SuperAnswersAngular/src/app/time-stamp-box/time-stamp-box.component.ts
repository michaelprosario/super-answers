import { Component, OnInit, Input } from '@angular/core';

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
