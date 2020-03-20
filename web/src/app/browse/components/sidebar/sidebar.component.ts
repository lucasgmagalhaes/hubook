import { Component, OnInit, ViewChild } from "@angular/core";

@Component({
  selector: "hb-sidebar",
  templateUrl: "./sidebar.component.html",
  styleUrls: ["./sidebar.component.scss"]
})
export class SidebarComponent implements OnInit {
  showFiller = false;
  @ViewChild("drawer") drawer;
  constructor() {}

  ngOnInit(): void {}

  toggle() {
    this.drawer.toggle();
  }
}
