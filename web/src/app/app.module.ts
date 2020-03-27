import { BrowserModule } from "@angular/platform-browser";
import { NgModule } from "@angular/core";

import { AppComponent } from "./app.component";
import { BrowserAnimationsModule } from "@angular/platform-browser/animations";

import { MatToolbarModule } from "@angular/material/toolbar";
import { MatButtonModule } from "@angular/material/button";
import { HeaderComponent } from "./presentation/header/header.component";
import { FooterComponent } from "./presentation/footer/footer.component";
import { RouterModule } from "@angular/router";
import { ROUTES } from "./app.routing";
import { PresentationComponent } from "./presentation/presentation.component";
import { MatIconModule } from '@angular/material/icon';
import { MatMenuModule } from '@angular/material/menu';
import { BrowseHeaderComponent } from './core/components/browse-header/browse-header.component';
import { BrowseSidebarComponent } from './core/components/browse-sidebar/browse-sidebar.component';
import { MatSidenavModule } from '@angular/material/sidenav';

@NgModule({
  declarations: [
    AppComponent,
    HeaderComponent,
    FooterComponent,
    BrowseHeaderComponent,
    BrowseSidebarComponent,
    PresentationComponent
  ],
  imports: [
    BrowserModule,
    MatIconModule,
    MatSidenavModule,
    BrowserAnimationsModule,
    MatToolbarModule,
    MatButtonModule,
    MatMenuModule,
    RouterModule.forRoot(ROUTES)
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule {}
