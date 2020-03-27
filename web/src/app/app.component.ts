import { Component, OnInit, ViewChild } from "@angular/core";
import { environment } from "src/environments/environment";
import webAppVersion from "./version";
import { SessionService } from "./core/services/session.service";
import { MatDrawer } from "@angular/material/sidenav";
import { Observable } from 'rxjs';

@Component({
  selector: "app-root",
  templateUrl: "./app.component.html",
  styleUrls: ["./app.component.scss"]
})
export class AppComponent implements OnInit {
  title = "Hubrary";
  isAuthenticated$: Observable<boolean>;

  @ViewChild("drawer") private drawer: MatDrawer;

  constructor(private sessionService: SessionService) {
    if (!environment.production) {
      console.info(
        `App running in development mode. Version: ${webAppVersion}`
      );
    }
  }

  ngOnInit(): void {
    this.isAuthenticated$ = this.sessionService.isAuthenticated();
  }

  toggleSidebar() {
    this.drawer.toggle();
  }
}
