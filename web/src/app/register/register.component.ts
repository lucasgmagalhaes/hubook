import { Component, OnInit, OnDestroy, AfterViewInit } from "@angular/core";
import routes from "../routes";

@Component({
  selector: "hb-register",
  templateUrl: "./register.component.html",
  styleUrls: ["./register.component.scss"]
})
export class RegisterComponent implements OnDestroy, AfterViewInit {
  get login() {
    return `/${routes.login}`;
  }

  constructor() {}
  ngAfterViewInit(): void {
    const body = document.getElementsByTagName("mat-drawer-container")[0];
    body.classList.add("account-background");
  }

  ngOnInit(): void {}

  ngOnDestroy(): void {
    const body = document.getElementsByTagName("mat-drawer-container")[0];
    body.classList.remove("account-background");
  }
}
