import { Component, OnInit, Input, Output, EventEmitter } from '@angular/core';

@Component({
  selector: 'am-title',
  templateUrl: './title.component.html',
  styleUrls: ['./title.component.scss']
})
export class TitleComponent implements OnInit {

  editMode = false;
  @Input() name: string;
  @Output() whenSaveClicked = new EventEmitter<string>();

  constructor() { }

  ngOnInit() {
  }

  saveClick() {
    this.whenSaveClicked.emit(this.name);
  }

}
