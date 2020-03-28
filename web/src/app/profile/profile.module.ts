import { NgModule } from "@angular/core";
import { CommonModule } from "@angular/common";
import { ProfileComponent } from "./profile.component";
import { Routes, RouterModule } from "@angular/router";
import { MaterialModule } from "../material/material.module";
import { ReactiveFormsModule, FormsModule } from "@angular/forms";

const ROUTES: Routes = [
  {
    path: "",
    component: ProfileComponent
  }
];

@NgModule({
  declarations: [ProfileComponent],
  imports: [
    CommonModule,
    FormsModule,
    ReactiveFormsModule,
    MaterialModule,
    RouterModule.forChild(ROUTES)
  ]
})
export class ProfileModule {}
