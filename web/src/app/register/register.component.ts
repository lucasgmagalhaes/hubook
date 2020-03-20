import { Component, OnInit } from "@angular/core";
import routes from "../routes";

@Component({
  selector: "hb-register",
  templateUrl: "./register.component.html",
  styleUrls: ["./register.component.scss"]
})
export class RegisterComponent implements OnInit {
  get login() {
    return `/${routes.login}`;
  }

  constructor() {}

  ngOnInit(): void {}
}
