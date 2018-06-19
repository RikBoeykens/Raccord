import { Routes } from '@angular/router';
import { RouteSettings } from './shared';

import { DashboardComponent } from './dashboard';

import { NoContentComponent } from './no-content';
import {
  ProjectsListComponent,
  ProjectDashboardComponent
} from './projects';
import {
  PagedProjectsResolve,
  ShortPagedProjectsResolve,
  CurrentProjectResolve,
  ResetCurrentProjectResolve
} from './shared/children/projects';
import { ErrorComponent } from './shared';

import {
  AuthGuard,
  LoginComponent
} from './security';

export const ROUTES: Routes = [
  {
    path: RouteSettings.LOGIN,
    component: LoginComponent,
    resolve: {
      ResetCurrentProjectResolve
    }
  },
  {
    path: RouteSettings.DASHBOARD,
    component: DashboardComponent,
    canActivate: [AuthGuard],
    resolve: {
      projects: ShortPagedProjectsResolve,
      ResetCurrentProjectResolve
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
          projects: PagedProjectsResolve,
          ResetCurrentProjectResolve
        }
      },
      {
        path: ':projectId',
        component: ProjectDashboardComponent,
        resolve: {
          CurrentProjectResolve
        }
      }
    ]
  },
  {
    path: RouteSettings.ERROR,
    component: ErrorComponent,
    resolve: {
      ResetCurrentProjectResolve
    }
  },
  {
    path: '**',
    component: NoContentComponent,
    resolve: {
      ResetCurrentProjectResolve
    }
  },
];
