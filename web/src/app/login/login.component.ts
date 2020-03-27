import { Component, OnInit, OnDestroy } from "@angular/core";
import routes from "../routes";
import { Router } from "@angular/router";
import { SessionService } from '../core/services/session.service';

@Component({
  selector: "hb-login",
  templateUrl: "./login.component.html",
  styleUrls: ["./login.component.scss"]
})
export class LoginComponent implements OnInit, OnDestroy {
  get register() {
    return `/${routes.register}`;
  }
  constructor(private router: Router, private sessionService: SessionService) {}

  ngOnInit(): void {
    const body = document.getElementsByTagName("body")[0];
    body.classList.add("account-background");
  }

  ngOnDestroy(): void {
    const body = document.getElementsByTagName('body')[0];
    body.classList.remove('account-background');
  }

  login() {
    this.sessionService.login();
    this.router.navigate(["browse"]);
  }
}
