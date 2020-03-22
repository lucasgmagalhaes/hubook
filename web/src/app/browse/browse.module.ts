import { NgModule } from "@angular/core";
import { RouterModule, Routes } from "@angular/router";
import { BrowseComponent } from "./browse.component";
import { SidebarComponent } from "./components/sidebar/sidebar.component";
import { HeaderComponent } from "./components/header/header.component";
import { MatToolbarModule } from "@angular/material/toolbar";
import { MatButtonModule } from "@angular/material/button";
import { MatSidenavModule } from "@angular/material/sidenav";
import { MatInputModule } from "@angular/material/input";
import { MatIconModule } from "@angular/material/icon";
import { MatMenuModule } from "@angular/material/menu";
import { MatBadgeModule } from "@angular/material/badge";
import { BookCardComponent } from './components/book-card/book-card.component';

const ROUTES: Routes = [
  {
    path: "",
    component: BrowseComponent
  }
];

@NgModule({
  declarations: [BrowseComponent, HeaderComponent, SidebarComponent, BookCardComponent],
  imports: [
    MatToolbarModule,
    MatButtonModule,
    MatInputModule,
    MatSidenavModule,
    MatIconModule,
    MatMenuModule,
    MatBadgeModule,
    RouterModule.forChild(ROUTES)
  ]
})
export class BrowseModule {}
