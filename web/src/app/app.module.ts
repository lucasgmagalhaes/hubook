import { BrowserModule } from "@angular/platform-browser";
import { NgModule } from "@angular/core";
import { AppComponent } from "./app.component";
import { BrowserAnimationsModule } from "@angular/platform-browser/animations";
import { HeaderComponent } from "./presentation/header/header.component";
import { FooterComponent } from "./presentation/footer/footer.component";
import { RouterModule } from "@angular/router";
import { ROUTES } from "./app.routing";
import { PresentationComponent } from "./presentation/presentation.component";
import { BrowseHeaderComponent } from "./core/components/browse-header/browse-header.component";
import { BrowseSidebarComponent } from "./core/components/browse-sidebar/browse-sidebar.component";
import { MaterialModule } from "./material/material.module";
import { NotificationsComponent } from './core/components/browse-header/notifications/notifications.component';
import { NotificationComponent } from './core/components/browse-header/notification/notification.component';

@NgModule({
  declarations: [
    AppComponent,
    HeaderComponent,
    FooterComponent,
    BrowseHeaderComponent,
    BrowseSidebarComponent,
    PresentationComponent,
    NotificationsComponent,
    NotificationComponent
  ],
  imports: [
    BrowserModule,
    BrowserAnimationsModule,
    MaterialModule,
    RouterModule.forRoot(ROUTES)
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule {}
