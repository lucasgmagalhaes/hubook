import { Component, OnInit, Output, EventEmitter } from '@angular/core';

@Component({
  selector: 'hb-browse-header',
  templateUrl: './browse-header.component.html',
  styleUrls: ['./browse-header.component.scss']
})
export class BrowseHeaderComponent implements OnInit {

  @Output()
  barToggled = new EventEmitter<void>();

  constructor() { }

  ngOnInit(): void {
  }

  emitBarTogled(){
    this.barToggled.emit();
  }
}
