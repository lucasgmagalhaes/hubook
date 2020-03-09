import { Component } from '@angular/core';
import { environment } from 'src/environments/environment';
import webAppVersion from './version';
import { Router } from '@angular/router';
import routes from './routes';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.scss']
})
export class AppComponent {
  title = 'Hubrary';

  constructor(private _router: Router){
    if (!environment.production) {
      console.info(`App running in development mode. Version: ${webAppVersion}`);
    }
  }

  isAuthPage() {
    return this._router.url.includes(routes.login) || this._router.url.includes(routes.register);
  }
}
