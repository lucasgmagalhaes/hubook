import { Component, OnInit } from "@angular/core";
import routes from "../../routes";

@Component({
  selector: "hb-login",
  templateUrl: "./login.component.html",
  styleUrls: ["./login.component.scss"]
})
export class LoginComponent implements OnInit {
  get register() {
    return `/${routes.register}`;
  }
  constructor() {}

  ngOnInit(): void {}

  login() {}
}
