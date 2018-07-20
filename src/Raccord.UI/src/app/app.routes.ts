import { Routes } from '@angular/router';
import { RouteSettings } from './shared';

import {
  AdminProjectRolesResolve,
  AdminProjectDashboardComponent,
  AdminProjectsListComponent,
  AdminLandingComponent,
  AdminGuard,
  AdminDashboardResolve,
  AdminProjectsResolve,
  AdminProjectResolve,
  AdminUsersListComponent,
  AdminUsersResolve,
  AdminUserDashboardComponent,
  AdminUserResolve,
  AdminUserInvitationsListComponent,
  AdminUserInvitationDashboardComponent,
  AdminUserInvitationsResolve,
  AdminUserInvitationResolve,
  AdminProjectUserDashboardComponent,
  AdminProjectUserResolve,
  AdminProjectUserInvitationDashboardComponent,
  AdminProjectUserInvitationResolve
} from './admin';

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
import {
  CreateUserFromInvitationComponent,
  InvitationResolve
} from './invitations';
import {
  UserProfileDashboardComponent
} from './profile';
import {
  UserProfileResolve
} from './shared/children/users';

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
    path: RouteSettings.ADMIN,
    canActivate: [AuthGuard, AdminGuard],
    children: [
      {
        path: '',
        component: AdminLandingComponent,
        resolve: {
          dashboardInfo: AdminDashboardResolve
        }
      },
      {
        path: RouteSettings.PROJECTS,
        children: [
          {
            path: '',
            component: AdminProjectsListComponent,
            resolve: {
              projects: AdminProjectsResolve
            }
          },
          {
            path: ':projectId',
            component: AdminProjectDashboardComponent,
            resolve: {
              project: AdminProjectResolve,
              projectRoles: AdminProjectRolesResolve
            }
          }
        ]
      },
      {
        path: RouteSettings.USERS,
        children: [
          {
            path: '',
            component: AdminUsersListComponent,
            resolve: {
              users: AdminUsersResolve
            }
          },
          {
            path: ':userId',
            component: AdminUserDashboardComponent,
            resolve: {
              user: AdminUserResolve,
              projectRoles: AdminProjectRolesResolve
            }
          }
        ]
      },
      {
        path: RouteSettings.INVITATIONS,
        children: [
          {
            path: '',
            component: AdminUserInvitationsListComponent,
            resolve: {
              userInvitations: AdminUserInvitationsResolve
            }
          },
          {
            path: ':userInvitationId',
            component: AdminUserInvitationDashboardComponent,
            resolve: {
              userInvitation: AdminUserInvitationResolve,
              projectRoles: AdminProjectRolesResolve
            }
          }
        ]
      },
      {
        path: RouteSettings.PROJECTUSERS,
        children: [
          {
            path: ':projectUserId',
            component: AdminProjectUserDashboardComponent,
            resolve: {
              projectUser: AdminProjectUserResolve,
              projectRoles: AdminProjectRolesResolve
            }
          }
        ]
      },
      {
        path: RouteSettings.PROJECTUSERINVITATIONS,
        children: [
          {
            path: ':projectUserInvitationId',
            component: AdminProjectUserInvitationDashboardComponent,
            resolve: {
              projectUserInvitation: AdminProjectUserInvitationResolve,
              projectRoles: AdminProjectRolesResolve
            }
          }
        ]
      }
    ]
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
    path: `${RouteSettings.INVITATIONS}/:invitationId`,
    component: CreateUserFromInvitationComponent,
    resolve: {
      invitation: InvitationResolve
    }
  },
  {
    path: RouteSettings.PROFILE,
    component: UserProfileDashboardComponent,
    resolve: {
      userProfile: UserProfileResolve
    }
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
