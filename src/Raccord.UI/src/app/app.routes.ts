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
  BreakdownItemLandingComponent,
  BreakdownItemResolve,
  BreakdownTypeLandingComponent,
  BreakdownTypeResolve,
  BreakdownLandingComponent,
  BreakdownsListComponent,
  BreakdownResolve,
  BreakdownsResolve,
  SelectedBreakdownResolve,
  CallsheetComponent,
  CallsheetSidesComponent,
  CallsheetsListComponent,
  CallsheetResolve,
  CallsheetSummaryResolve,
  ProjectCallsheetsResolve,
  CastMemberLandingComponent,
  CastMembersListComponent,
  CastMemberResolve,
  CastMembersResolve,
  CastDashboardComponent,
  CastDashboardResolve,
  CrewDepartmentsResolve,
  CrewUnitDashboardComponent,
  CrewUnitDashboardResolve,
  UnitListLandingComponent,
  CrewUnitSummaryResolve,
  CrewUnitsResolve,
  CrewDashboardComponent,
  LocationSetLandingComponent,
  LocationSetResolve,
  LocationLandingComponent,
  LocationsListComponent,
  LocationResolve,
  LocationsResolve,
  LocationDashboardComponent,
  LocationDashboardResolve,
  ScheduleDaysResolve,
  ScheduleLandingComponent,
  SchedulesListComponent,
  SchedulesResolve,
  SchedulingDashboardComponent,
  SchedulingDashboardResolve,
  CharacterLandingComponent,
  CharactersListComponent,
  CharacterResolve,
  CharactersResolve,
  ScenesListComponent,
  SceneResolve,
  ScenesResolve,
  SceneLandingComponent,
  ScriptLocationLandingComponent,
  ScriptLocationsListComponent,
  ScriptLocationResolve,
  ScriptLocationsResolve,
  ScriptTextLandingComponent,
  ScriptTextUserComponent,
  ScriptTextResolve,
  ScriptTextCallsheetResolve,
  ScriptTextUserResolve,
  ScriptDashboardComponent,
  ScriptDashboardResolve,
  SlateLandingComponent,
  SlatesListComponent,
  SlatesResolve,
  SlateResolve,
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
  LoginComponent,
  LoggedInGuard
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
import { SearchDashboardComponent } from './search';

export const ROUTES: Routes = [
  {
    path: RouteSettings.LOGIN,
    component: LoginComponent,
    canActivate: [LoggedInGuard],
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
    ],
    resolve: {
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
        children: [
          {
            path: '',
            component: ProjectDashboardComponent
          },
          {
            path: RouteSettings.SCRIPTTEXT,
            children: [
              {
                path: '',
                component: ScriptTextLandingComponent,
                resolve: {
                  sceneTexts: ScriptTextResolve,
                }
              },
              {
                path: RouteSettings.USER,
                component: ScriptTextUserComponent,
                resolve: {
                  sceneTexts: ScriptTextUserResolve,
                }
              }
            ]
          },
          {
            path: RouteSettings.SCRIPT,
            children: [
              {
                path: '',
                component: ScriptDashboardComponent,
                resolve: {
                  dashboardInfo: ScriptDashboardResolve
                }
              }
            ]
          },
          {
            path: RouteSettings.SCENES,
            children: [
              {
                path: '',
                component: ScenesListComponent,
                resolve: {
                  scenes: ScenesResolve,
                  selectedBreakdown: SelectedBreakdownResolve
                }
              },
              {
                path: ':sceneId',
                component: SceneLandingComponent,
                resolve: {
                  scene: SceneResolve
                }
              }
            ]
          },
          {
            path: RouteSettings.SCRIPTLOCATIONS,
            children: [
              {
                path: '',
                component: ScriptLocationsListComponent,
                resolve: {
                  scriptLocations: ScriptLocationsResolve
                }
              },
              {
                path: ':scriptLocationId',
                component: ScriptLocationLandingComponent,
                resolve: {
                  scriptLocation: ScriptLocationResolve
                }
              }
            ]
          },
          {
            path: RouteSettings.CHARACTERS,
            children: [
              {
                path: '',
                component: CharactersListComponent,
                resolve: {
                  characters: CharactersResolve
                }
              },
              {
                path: ':characterId',
                component: CharacterLandingComponent,
                resolve: {
                  character: CharacterResolve
                }
              }
            ]
          },
          {
            path: RouteSettings.LOCATIONSDASHBOARD,
            children: [
              {
                path: '',
                component: LocationDashboardComponent,
                resolve: {
                  dashboardInfo: LocationDashboardResolve
                }
              }
            ]
          },
          {
            path: RouteSettings.LOCATIONS,
            children: [
              {
                path: '',
                component: LocationsListComponent,
                resolve: {
                  locations: LocationsResolve
                }
              },
              {
                path: ':locationId',
                component: LocationLandingComponent,
                resolve: {
                  location: LocationResolve
                }
              }
            ]
          },
          {
            path: RouteSettings.LOCATIONSETS,
            children: [
              {
                path: ':locationSetId',
                component: LocationSetLandingComponent,
                resolve: {
                  locationSet: LocationSetResolve
                }
              }
            ]
          },
          {
            path: RouteSettings.CASTDASHBOARD,
            children: [
              {
                path: '',
                component: CastDashboardComponent,
                resolve: {
                  dashboardInfo: CastDashboardResolve
                }
              }
            ]
          },
          {
            path: RouteSettings.CAST,
            children: [
              {
                path: '',
                component: CastMembersListComponent,
                resolve: {
                  castMembers: CastMembersResolve
                }
              },
              {
                path: ':castMemberId',
                component: CastMemberLandingComponent,
                resolve: {
                  castMember: CastMemberResolve
                }
              }
            ]
          },
          {
            path: RouteSettings.SCHEDULING,
            children: [
              {
                path: '',
                component: SchedulingDashboardComponent,
                resolve: {
                  dashboardInfo: SchedulingDashboardResolve
                }
              }
            ]
          },
          {
            path: RouteSettings.CALLSHEETS,
            children: [
              {
                path: '',
                component: CallsheetsListComponent,
                resolve: {
                  callsheets: ProjectCallsheetsResolve
                }
              },
              {
                path: ':callsheetId',
                children: [
                  {
                    path: '',
                    component: CallsheetComponent,
                    resolve: {
                      callsheet: CallsheetResolve
                    }
                  },
                  {
                    path: RouteSettings.SIDES,
                    component: CallsheetSidesComponent,
                    resolve: {
                      callsheet: CallsheetSummaryResolve,
                      sceneTexts: ScriptTextCallsheetResolve
                    }
                  }
                ]
              }
            ]
          },
          {
            path: RouteSettings.SCHEDULES,
            children: [
              {
                path: '',
                component: SchedulesListComponent,
                resolve: {
                  schedules: SchedulesResolve
                }
              },
              {
                path: ':crewUnitId',
                component: ScheduleLandingComponent,
                resolve: {
                  scheduleDays: ScheduleDaysResolve,
                  crewUnit: CrewUnitSummaryResolve
                }
              }
            ]
          },
          {
            path: RouteSettings.CREW,
            children: [
              {
                path: '',
                component: CrewDashboardComponent,
                resolve: {
                  crewUnits: CrewUnitsResolve
                }
              },
              {
                path: ':crewUnitId',
                component: CrewUnitDashboardComponent,
                resolve: {
                  dashboardInfo: CrewUnitDashboardResolve
                }
              }
            ]
          },
          {
            path: `${RouteSettings.UNITLISTS}/:crewUnitId`,
            component: UnitListLandingComponent,
            resolve: {
              crewUnit: CrewUnitSummaryResolve,
              crewDepartments: CrewDepartmentsResolve
            }
          },
          {
            path: RouteSettings.BREAKDOWNS,
            children: [
              {
                path: '',
                component: BreakdownsListComponent,
                resolve: {
                  breakdowns: BreakdownsResolve
                }
              },
              {
                path: ':breakdownId',
                children: [
                  {
                    path: '',
                    component: BreakdownLandingComponent,
                    resolve: {
                      breakdown: BreakdownResolve
                    }
                  },
                  {
                    path: `${RouteSettings.BREAKDOWNTYPES}/:breakdownTypeId`,
                    component: BreakdownTypeLandingComponent,
                    resolve: {
                      breakdownType: BreakdownTypeResolve
                    }
                  },
                  {
                    path: `${RouteSettings.BREAKDOWNITEMS}/:breakdownItemId`,
                    component: BreakdownItemLandingComponent,
                    resolve: {
                      breakdownItem: BreakdownItemResolve
                    }
                  }
                ]
              }
            ]
          },
          {
            path: RouteSettings.SLATES,
            children: [
              {
                path: '',
                component: SlatesListComponent,
                resolve: {
                  slates: SlatesResolve
                }
              },
              {
                path: ':slateId',
                component: SlateLandingComponent,
                resolve: {
                  slate: SlateResolve
                }
              }
            ]
          }
        ],
        resolve: {
          CurrentProjectResolve
        }
      }
    ]
  },
  {
    path: `${RouteSettings.INVITATIONS}/:invitationId`,
    component: CreateUserFromInvitationComponent,
    canActivate: [LoggedInGuard],
    resolve: {
      invitation: InvitationResolve
    }
  },
  {
    path: RouteSettings.PROFILE,
    component: UserProfileDashboardComponent,
    canActivate: [AuthGuard],
    resolve: {
      userProfile: UserProfileResolve,
      ResetCurrentProjectResolve
    }
  },
  {
    path: RouteSettings.SEARCH,
    component: SearchDashboardComponent,
    canActivate: [AuthGuard],
    resolve: {
      ResetCurrentProjectResolve
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
