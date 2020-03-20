import { Routes } from "@angular/router";
import { PresentationComponent } from "./presentation/presentation.component";

export const ROUTES: Routes = [
  {
    path: "",
    component: PresentationComponent
  },
  {
    path: "login",
    loadChildren: () => import("./login/login.module").then(m => m.LoginModule)
  },
  {
    path: "register",
    loadChildren: () =>
      import("./register/register.module").then(m => m.RegisterModule)
  },
  {
    path: "browse",
    loadChildren: () =>
      import("./browse/browse.module").then(m => m.BrowseModule)
  }
];
