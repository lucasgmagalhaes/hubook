import { Component, OnInit, ViewChild } from "@angular/core";

@Component({
  selector: "hb-browse-sidebar",
  templateUrl: "./browse-sidebar.component.html",
  styleUrls: ["./browse-sidebar.component.scss"]
})
export class BrowseSidebarComponent implements OnInit {
  showFiller = false;
  @ViewChild("drawer") drawer;
  constructor() {}

  ngOnInit(): void {}

  toggle() {
    this.drawer.toggle();
  }
}
