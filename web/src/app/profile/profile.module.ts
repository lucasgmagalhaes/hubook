import { NgModule } from "@angular/core";
import { CommonModule } from "@angular/common";
import { ProfileComponent } from "./profile.component";
import { Routes, RouterModule } from "@angular/router";

const ROUTES: Routes = [
  {
    path: "",
    component: ProfileComponent
  }
];

@NgModule({
  declarations: [ProfileComponent],
  imports: [CommonModule, RouterModule.forChild(ROUTES)]
})
export class ProfileModule {}
