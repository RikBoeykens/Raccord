import {
  MatButtonModule,
  MatCheckboxModule,
  MatProgressBarModule,
  MatInputModule,
  MatSnackBarModule
} from '@angular/material';
import { NgModule } from '@angular/core';

@NgModule({
  imports: [
    MatButtonModule,
    MatCheckboxModule,
    MatProgressBarModule,
    MatInputModule,
    MatSnackBarModule
  ],
  exports: [
    MatButtonModule,
    MatCheckboxModule,
    MatProgressBarModule,
    MatInputModule,
    MatSnackBarModule
  ],
})
export class AngularMaterialModule { }
