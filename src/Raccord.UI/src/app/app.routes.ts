import { Routes } from '@angular/router';
import { RouteSettings } from './shared';

import { DashboardComponent } from './dashboard';

import { NoContentComponent } from './no-content';
import {
  ProjectsListComponent
} from './projects';
import {
  PagedProjectsResolve,
  ShortPagedProjectsResolve
} from './shared/children/projects';
import { ErrorComponent } from './shared';

import {
  AuthGuard,
  LoginComponent
} from './security';

export const ROUTES: Routes = [
  { path: RouteSettings.LOGIN,  component: LoginComponent },
  {
    path: RouteSettings.DASHBOARD,
    component: DashboardComponent,
    canActivate: [AuthGuard],
    resolve: {
      projects: ShortPagedProjectsResolve
    }
  },
  {
    path: RouteSettings.PROJECTS,
    canActivate: [AuthGuard],
    children: [
      {
        path: '',
        component: ProjectsListComponent,
        resolve: {
          projects: PagedProjectsResolve
        }
      }
    ]
  },
  { path: RouteSettings.ERROR, component: ErrorComponent },
  { path: '**',    component: NoContentComponent },
];
