import { Component, OnInit } from '@angular/core';
import routes from 'src/app/routes';

@Component({
  selector: 'hb-header',
  templateUrl: './header.component.html',
  styleUrls: ['./header.component.scss']
})
export class HeaderComponent implements OnInit {

  login = routes.login;

  constructor() { }

  ngOnInit(): void {
  }

}
