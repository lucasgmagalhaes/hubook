import { Routes } from "@angular/router";
import routes from "./routes";

export const ROUTES: Routes = [
  {
    path: routes.login,
    loadChildren: () => import("./login/login.module").then(m => m.LoginModule)
  }
];
