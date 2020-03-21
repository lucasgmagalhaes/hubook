import { Component, OnInit, OnDestroy } from "@angular/core";
import routes from "../routes";

@Component({
  selector: "hb-register",
  templateUrl: "./register.component.html",
  styleUrls: ["./register.component.scss"]
})
export class RegisterComponent implements OnInit, OnDestroy {
  get login() {
    return `/${routes.login}`;
  }

  constructor() {}

  ngOnInit(): void {
    const body = document.getElementsByTagName("body")[0];
    body.classList.add("account-background");
  }

  ngOnDestroy(): void {
    const body = document.getElementsByTagName("body")[0];
    body.classList.remove("account-background");
  }
}
