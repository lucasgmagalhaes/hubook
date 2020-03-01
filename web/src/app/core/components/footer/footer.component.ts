import { Component, OnInit } from "@angular/core";

@Component({
  selector: "hb-footer",
  templateUrl: "./footer.component.html",
  styleUrls: ["./footer.component.scss"]
})
export class FooterComponent implements OnInit {
  constructor() {}

  ngOnInit(): void {}

  getYear() {
    const date = new Date();
    return date.getFullYear();
  }
}
