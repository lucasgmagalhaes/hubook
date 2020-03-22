import { Component, OnInit, Output, EventEmitter } from '@angular/core';

@Component({
  selector: 'hb-browse-header',
  templateUrl: './header.component.html',
  styleUrls: ['./header.component.scss']
})
export class HeaderComponent implements OnInit {

  @Output()
  barToggled = new EventEmitter<void>();

  constructor() { }

  ngOnInit(): void {
  }

  emitBarTogled(){
    this.barToggled.emit();
  }
}
