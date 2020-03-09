import { Routes } from "@angular/router";
import routes from "./routes";

export const ROUTES: Routes = [
  {
    path: '',
    loadChildren: () => import("./account/account.module").then(m => m.AccountModule),
  }
];
