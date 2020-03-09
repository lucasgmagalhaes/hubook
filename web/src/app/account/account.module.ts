import { NgModule } from "@angular/core";
import { CommonModule } from "@angular/common";
import { MatCardModule } from "@angular/material/card";
import { MatButtonModule } from "@angular/material/button";
import { MatInputModule } from "@angular/material/input";
import { Routes, RouterModule } from "@angular/router";
import { LoginComponent } from "./login/login.component";
import routes from "../routes";
import { RegisterComponent } from "./register/register.component";

const ROUTES: Routes = [
  {
    path: "",
    redirectTo: routes.login
  },
  {
    path: routes.login,
    component: LoginComponent
  },
  {
    path: routes.register,
    component: RegisterComponent
  }
];

@NgModule({
  declarations: [LoginComponent, RegisterComponent],
  imports: [
    CommonModule,
    MatCardModule,
    MatButtonModule,
    MatInputModule,
    RouterModule.forChild(ROUTES)
  ]
})
export class AccountModule {}
