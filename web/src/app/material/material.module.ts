import { NgModule } from "@angular/core";
import { CommonModule } from "@angular/common";
import { MatTooltipModule } from "@angular/material/tooltip";
import { MatCardModule } from "@angular/material/card";
import { MatButtonModule } from "@angular/material/button";
import { MatIconModule } from "@angular/material/icon";
import { MatInputModule } from "@angular/material/input";
import { MatDatepickerModule } from "@angular/material/datepicker";
import { MatNativeDateModule } from "@angular/material/core";
import { MatAutocompleteModule } from "@angular/material/autocomplete";
import { MatDividerModule } from "@angular/material/divider";
import { MatToolbarModule } from "@angular/material/toolbar";
import { MatMenuModule } from "@angular/material/menu";
import { MatSidenavModule } from "@angular/material/sidenav";
import { MatListModule } from "@angular/material/list";
@NgModule({
  declarations: [],
  exports: [
    MatTooltipModule,
    MatCardModule,
    MatButtonModule,
    MatIconModule,
    MatInputModule,
    MatDatepickerModule,
    MatNativeDateModule,
    MatAutocompleteModule,
    MatDividerModule,
    MatToolbarModule,
    MatMenuModule,
    MatSidenavModule,
    MatListModule
  ],
  imports: [CommonModule]
})
export class MaterialModule {}
