import { Component, OnInit } from "@angular/core";
import routes from '../routes';
import { Router } from '@angular/router';

@Component({
  selector: "hb-login",
  templateUrl: "./login.component.html",
  styleUrls: ["./login.component.scss"]
})
export class LoginComponent implements OnInit {
  get register() {
    return `/${routes.register}`;
  }
  constructor(private router: Router) {}

  ngOnInit(): void {}

  login() {
    this.router.navigate(["browse"]);
  }
}
