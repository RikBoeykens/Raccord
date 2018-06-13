import { Routes } from '@angular/router';
import { RouteSettings } from './shared';

import { DashboardComponent } from './dashboard';

import { NoContentComponent } from './no-content';

import {
  AuthGuard,
  LoginComponent
} from './security';

export const ROUTES: Routes = [
  { path: '',      component: DashboardComponent, canActivate: [AuthGuard] },
  { path: RouteSettings.DASHBOARD,  component: DashboardComponent, canActivate: [AuthGuard] },
  { path: RouteSettings.LOGIN,  component: LoginComponent },
  { path: '**',    component: NoContentComponent },
];
