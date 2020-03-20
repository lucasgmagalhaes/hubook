import { NgModule } from "@angular/core";
import { RouterModule, Routes } from "@angular/router";
import { BrowseComponent } from "./browse.component";
import { SidebarComponent } from "./components/sidebar/sidebar.component";
import { HeaderComponent } from "./components/header/header.component";
import { MatToolbarModule } from "@angular/material/toolbar";
import { MatButtonModule } from "@angular/material/button";
import { MatSidenavModule } from "@angular/material/sidenav";

const ROUTES: Routes = [
  {
    path: "",
    component: BrowseComponent
  }
];

@NgModule({
  declarations: [BrowseComponent, HeaderComponent, SidebarComponent],
  imports: [
    MatToolbarModule,
    MatButtonModule,
    MatSidenavModule,
    RouterModule.forChild(ROUTES)
  ]
})
export class BrowseModule {}
