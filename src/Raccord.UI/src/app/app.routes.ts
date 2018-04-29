import { Routes } from '@angular/router';
import { DashboardComponent } from './dashboard';
import { NoContentComponent } from './no-content';
import { SearchComponent } from './search/component';
import { AddProjectComponent } from './projects';
import { EditProjectComponent } from './projects';
import { ProjectLandingComponent } from './projects';
import { ProjectsListComponent } from './projects';
import {
  ScenesListComponent,
  EditScenesListComponent,
  SceneLandingComponent,
  SceneTimingsComponent,
  ScriptLocationsListComponent,
  EditScriptLocationsListComponent,
  ScriptLocationLandingComponent,
  IntExtListComponent,
  EditIntExtListComponent,
  IntExtLandingComponent,
  DayNightListComponent,
  EditDayNightListComponent,
  DayNightLandingComponent,
  ImagesListComponent,
  ImageLandingComponent,
  CharactersListComponent,
  EditCharactersListComponent,
  CharacterLandingComponent,
  BreakdownsListComponent,
  BreakdownLandingComponent,
  BreakdownSettingsComponent,
  BreakdownTypeLandingComponent,
  BreakdownItemLandingComponent,
  EditScheduleComponent,
  ScheduleLandingComponent,
  MyScheduleLandingComponent,
  ScheduleSceneLandingComponent,
  LocationsListComponent,
  EditLocationsListComponent,
  LocationLandingComponent,
  LocationSetLandingComponent,
  CallsheetsListComponent,
  CallsheetComponent,
  CallsheetWizardStep1Component,
  CallsheetWizardStep2Component,
  CallsheetWizardStep3Component,
  CallsheetWizardStep4Component,
  ScriptTextCallsheetComponent,
  SlatesListComponent,
  SlateLandingComponent,
  ChartLandingComponent,
  ShootingDayReportsListComponent,
  ShootingDayReportLandingComponent,
  CrewLandingComponent,
  CrewUnitsListComponent,
  MyCrewUnitsListComponent,
  CrewUnitsNavListComponent,
  ScriptUploadComponent,
  ScriptUploadLandingComponent,
  ScriptTextLandingComponent,
  ScriptTextUserComponent,
  CastMembersListComponent,
  EditCastMembersListComponent,
  CastMemberLandingComponent
} from './projects';
import { ScenePropertiesLandingComponent } from './projects';
import { LoginComponent } from './security';
import {
  AdminProjectsListComponent,
  AdminAddProjectComponent,
  AdminProjectLandingComponent,
  AdminProjectSettingsComponent,
  AdminUsersListComponent,
  AdminAddUserComponent,
  AdminUserLandingComponent,
  AdminProjectUserLandingComponent,
  AdminCrewUnitLandingComponent,
  AdminCrewUnitsListComponent,
} from './admin';
import{
  UserProfileLandingComponent
} from './profile';

import { ProjectResolve } from './projects';
import { ProjectSummaryResolve } from './projects';
import { ProjectsResolve } from './projects';
import {
  SceneResolve,
  ScenesResolve,
  SceneCharactersResolve,
  ScriptLocationResolve,
  ScriptLocationsResolve
} from './projects';
import { IntExtResolve } from './projects';
import { IntExtsResolve } from './projects';
import { DayNightResolve } from './projects';
import { DayNightsResolve } from './projects';
import { ImageResolve } from './projects';
import { ImagesResolve } from './projects';
import { CharacterResolve } from './projects';
import { CharactersResolve } from './projects';
import {
  BreakdownsResolve,
  BreakdownResolve,
  BreakdownSummaryResolve,
  SelectedBreakdownResolve,
  BreakdownTypeResolve,
  BreakdownTypesResolve,
  BreakdownItemResolve,
  BreakdownItemsResolve,
  ScheduleDaysResolve,
  ScheduleDayUsersResolve,
  ScheduleSceneResolve,
  LocationsResolve,
  LocationResolve,
  LocationSetResolve,
  SceneLocationSetsResolve,
  AvailableCallsheetShootingDaysResolve,
  AvailableCompletionShootingDaysResolve,
  CompletedShootingDaysResolve,
  ShootingDaysResolve,
  ShootingDayResolve,
  CallsheetsResolve,
  CallsheetResolve,
  CallsheetSummaryResolve,
  CallsheetSceneLocationsResolve,
  CallsheetSceneCharactersResolve,
  CallsheetCharactersCharactersResolve,
  SlateResolve,
  SlatesResolve,
  TakeResolve,
  TakesResolve,
  CrewDepartmentsResolve,
  CrewUnitResolve,
  CrewUnitSummaryResolve,
  CrewUnitsResolve,
  UserCrewUnitsResolve,
  ScriptUploadResolve,
  ScriptTextResolve,
  ScriptTextCallsheetResolve,
  ScriptTextUserResolve,
  CastMemberResolve,
  CastMembersResolve
} from './projects';
import {
  AdminProjectsResolve,
  AdminProjectResolve,
  AdminGuard,
  AdminUsersResolve,
  AdminUserResolve,
  AdminProjectUsersResolve,
  AdminUserProjectsResolve,
  AdminProjectUserResolve,
  AdminProjectRolesResolve,
  AdminCrewUnitResolve
} from './admin';

import {
  CanEditGeneralProjectPermissionGuard,
  CanEditUsersProjectPermissionGuard,
  CanReadCallsheetProjectPermissionGuard,
  CanReadGeneralProjectPermissionGuard
} from './account';

import { CanDeactivateGuard } from './shared/service/can-deactivate-guard.service';
import { AuthGuard } from './security';
import { ProjectChartsResolve } from './charts/index';
import { UserProfileResolve } from './profile';

export const ROUTES: Routes = [
  { path: '',      component: DashboardComponent, canActivate: [AuthGuard] },
  { path: 'dashboard',  component: DashboardComponent, canActivate: [AuthGuard] },
  { path: 'login',  component: LoginComponent },
  { path: 'search',  component: SearchComponent, canActivate: [AuthGuard] },
  {
    path: 'admin',
    canActivate: [AdminGuard],
    children: [
      {
        path: 'projects',
        children: [
          {
            path: '',
            component: AdminProjectsListComponent,
            resolve: {
              projects: AdminProjectsResolve
            }
          },
          {
            path: 'add',
            component: AdminAddProjectComponent,
            canDeactivate: [CanDeactivateGuard],
          },
          {
            path: ':projectId',
            children: [
              {
                path: '',
                component: AdminProjectLandingComponent,
                resolve: {
                  project: AdminProjectResolve,
                  projectUsers: AdminProjectUsersResolve
                }
              },
              {
                path: 'settings',
                component: AdminProjectSettingsComponent,
                resolve: {
                  project: AdminProjectResolve
                },
                canDeactivate: [CanDeactivateGuard],
              },
              {
                path: 'units',
                children: [
                  {
                    path: '',
                    component: AdminCrewUnitsListComponent,
                    resolve: {
                      project: ProjectSummaryResolve,
                      crewUnits: CrewUnitsResolve
                    }
                  },
                  {
                    path: ':crewUnitId',
                    component: AdminCrewUnitLandingComponent,
                    resolve: {
                      project: ProjectSummaryResolve,
                      crewUnit: AdminCrewUnitResolve
                    }
                  }
                ]
              },
            ]
          }
        ]
      },
      {
        path: 'users',
        children: [
          {
            path: '',
            component: AdminUsersListComponent,
            resolve: {
              users: AdminUsersResolve
            }
          },
          {
            path: 'add',
            component: AdminAddUserComponent,
            canDeactivate: [CanDeactivateGuard],
          },
          {
            path: ':userId',
            children: [
              {
                path: '',
                component: AdminUserLandingComponent,
                resolve: {
                  user: AdminUserResolve,
                  projects: AdminUserProjectsResolve,
                  projectRoles: AdminProjectRolesResolve
                }
              },
            ]
          }
        ]
      },
      {
        path: 'projectusers',
        children: [
          {
            path: ':projectUserId',
            component: AdminProjectUserLandingComponent,
            resolve: {
              projectUser: AdminProjectUserResolve,
              projectRoles: AdminProjectRolesResolve,
            }
          },
        ]
      }
    ]
  },
  {
    path: 'projects',
    canActivate: [AuthGuard],
    children: [
      {
        path: '',
        component: ProjectsListComponent,
        resolve: {
          projects: ProjectsResolve
        }
      },
      {
        path: ':projectId',
        children: [
          {
            path: '',
            component: ProjectLandingComponent,
            resolve: {
              project: ProjectResolve
            }
          },
          {
            path: 'scenes',
            canActivate: [CanReadGeneralProjectPermissionGuard],
            children: [
              {
                path: '',
                component: ScenesListComponent,
                resolve: {
                  project: ProjectSummaryResolve,
                  scenes: ScenesResolve,
                  breakdown: SelectedBreakdownResolve
                },
              },
              {
                path: 'edit',
                canActivate: [CanEditGeneralProjectPermissionGuard],
                component: EditScenesListComponent,
                resolve: {
                  project: ProjectSummaryResolve,
                  scenes: ScenesResolve
                },
              },
              {
                path: 'timings',
                component: SceneTimingsComponent,
                resolve: {
                  project: ProjectSummaryResolve,
                  scenes: ScenesResolve
                },
              },
              {
                path: ':sceneId',
                component: SceneLandingComponent,
                resolve: {
                  project: ProjectSummaryResolve,
                  scene: SceneResolve
                }
              }
            ]
          },
          {
            path: 'scriptlocations',
            canActivate: [CanReadGeneralProjectPermissionGuard],
            children: [
              {
                path: '',
                component: ScriptLocationsListComponent,
                resolve: {
                  project: ProjectSummaryResolve,
                  scriptLocations: ScriptLocationsResolve
                },
              },
              {
                path: 'edit',
                canActivate: [CanEditGeneralProjectPermissionGuard],
                component: EditScriptLocationsListComponent,
                resolve: {
                  project: ProjectSummaryResolve,
                  scriptLocations: ScriptLocationsResolve
                },
              },
              {
                path: ':scriptLocationId',
                component: ScriptLocationLandingComponent,
                resolve: {
                  project: ProjectSummaryResolve,
                  scriptLocation: ScriptLocationResolve
                },
              }
            ]
          },
          {
            path: 'sceneproperties',
            canActivate: [CanReadGeneralProjectPermissionGuard],
            component: ScenePropertiesLandingComponent,
            resolve: {
              project: ProjectSummaryResolve,
            }
          },
          {
            path: 'daynights',
            canActivate: [CanReadGeneralProjectPermissionGuard],
            children: [
              {
                path: '',
                component: DayNightListComponent,
                resolve: {
                  project: ProjectSummaryResolve,
                  dayNights: DayNightsResolve
                },
              },
              {
                path: 'edit',
                canActivate: [CanEditGeneralProjectPermissionGuard],
                component: EditDayNightListComponent,
                resolve: {
                  project: ProjectSummaryResolve,
                  dayNights: DayNightsResolve
                },
              },
              {
                path: ':dayNightId',
                component: DayNightLandingComponent,
                resolve: {
                  project: ProjectSummaryResolve,
                  dayNight: DayNightResolve
                },
              }
            ]
          },
          {
            path: 'intexts',
            canActivate: [CanReadGeneralProjectPermissionGuard],
            children: [
              {
                path: '',
                component: IntExtListComponent,
                resolve: {
                  project: ProjectSummaryResolve,
                  intExts: IntExtsResolve
                },
              },
              {
                path: 'edit',
                canActivate: [CanEditGeneralProjectPermissionGuard],
                component: EditIntExtListComponent,
                resolve: {
                  project: ProjectSummaryResolve,
                  intExts: IntExtsResolve
                },
              },
              {
                path: ':intExtId',
                component: IntExtLandingComponent,
                resolve: {
                  project: ProjectSummaryResolve,
                  intExt: IntExtResolve
                },
              }
            ]
          },
          {
            path: 'images',
            canActivate: [CanReadGeneralProjectPermissionGuard],
            children: [
              {
                path: '',
                component: ImagesListComponent,
                resolve: {
                  project: ProjectSummaryResolve,
                  images: ImagesResolve
                },
              },
              {
                path: ':imageId',
                component: ImageLandingComponent,
                resolve: {
                  project: ProjectSummaryResolve,
                  image: ImageResolve
                },
              }
            ]
          },
          {
            path: 'characters',
            canActivate: [CanReadGeneralProjectPermissionGuard],
            children: [
              {
                path: '',
                component: CharactersListComponent,
                resolve: {
                  project: ProjectSummaryResolve,
                  characters: CharactersResolve
                },
              },
              {
                path: 'edit',
                canActivate: [CanEditGeneralProjectPermissionGuard],
                component: EditCharactersListComponent,
                resolve: {
                  project: ProjectSummaryResolve,
                  characters: CharactersResolve
                },
              },
              {
                path: ':characterId',
                component: CharacterLandingComponent,
                resolve: {
                  project: ProjectSummaryResolve,
                  character: CharacterResolve
                },
              }
            ]
          },
          {
            path: 'cast',
            canActivate: [CanReadGeneralProjectPermissionGuard],
            children: [
              {
                path: '',
                component: CastMembersListComponent,
                resolve: {
                  project: ProjectSummaryResolve,
                  castMembers: CastMembersResolve
                },
              },
              {
                path: 'edit',
                canActivate: [CanEditGeneralProjectPermissionGuard],
                component: EditCastMembersListComponent,
                resolve: {
                  project: ProjectSummaryResolve,
                  castMembers: CastMembersResolve
                },
              },
              {
                path: ':castMemberId',
                component: CastMemberLandingComponent,
                resolve: {
                  project: ProjectSummaryResolve,
                  castMember: CastMemberResolve
                },
              }
            ]
          },
          {
            path: 'breakdowns',
            canActivate: [CanReadGeneralProjectPermissionGuard],
            children: [
              {
                path: '',
                component: BreakdownsListComponent,
                resolve: {
                  project: ProjectSummaryResolve,
                  breakdowns: BreakdownsResolve
                },
              },
              {
                path: ':breakdownId',
                children: [
                  {
                    path: '',
                    component: BreakdownLandingComponent,
                    resolve: {
                      project: ProjectSummaryResolve,
                      breakdown: BreakdownResolve
                    },
                  },
                  {
                    path: 'settings',
                    component: BreakdownSettingsComponent,
                    resolve: {
                      project: ProjectSummaryResolve,
                      breakdown: BreakdownResolve
                    },
                  },
                  {
                    path: 'types/:breakdownTypeId',
                    children: [
                      {
                        path: '',
                        component: BreakdownTypeLandingComponent,
                        resolve: {
                          project: ProjectSummaryResolve,
                          breakdownType: BreakdownTypeResolve
                        }
                      }
                    ]
                  },
                  {
                    path: 'items/:breakdownItemId',
                    children: [
                      {
                        path: '',
                        component: BreakdownItemLandingComponent,
                        resolve: {
                          project: ProjectSummaryResolve,
                          breakdownItem: BreakdownItemResolve
                        }
                      }
                    ]
                  }
                ]
              }
            ]
          },
          {
            path: 'scheduling',
            canActivate: [CanReadGeneralProjectPermissionGuard],
            children: [
              {
                path: 'user',
                component: MyScheduleLandingComponent,
                resolve: {
                  project: ProjectSummaryResolve,
                  scheduleDays: ScheduleDayUsersResolve
                }
              },
              {
                path: ':crewUnitId',
                canActivate: [CanReadGeneralProjectPermissionGuard],
                children: [
                  {
                    path: '',
                    component: ScheduleLandingComponent,
                    resolve: {
                      project: ProjectSummaryResolve,
                      crewUnit: CrewUnitSummaryResolve,
                      scheduleDays: ScheduleDaysResolve,
                    }
                  },
                  {
                    path: 'edit',
                    canActivate: [CanEditGeneralProjectPermissionGuard],
                    children: [
                      {
                        path: '',
                        component: EditScheduleComponent,
                        resolve: {
                          project: ProjectSummaryResolve,
                          crewUnit: CrewUnitSummaryResolve,
                          scheduleDays: ScheduleDaysResolve,
                          breakdown: SelectedBreakdownResolve
                        }
                      },
                      {
                        path: ':sceneId/scene/:scheduleSceneId',
                        component: ScheduleSceneLandingComponent,
                        resolve: {
                          project: ProjectSummaryResolve,
                          crewUnit: CrewUnitSummaryResolve,
                          scheduleScene: ScheduleSceneResolve,
                          characters: SceneCharactersResolve,
                          locationSets: SceneLocationSetsResolve
                        }
                      }
                    ]
                  },
                ]
              },
            ]
          },
          {
            path: 'locations',
            canActivate: [CanReadGeneralProjectPermissionGuard],
            children: [
              {
                path: '',
                component: LocationsListComponent,
                resolve: {
                  project: ProjectSummaryResolve,
                  locations: LocationsResolve
                }
              },
              {
                path: 'edit',
                component: EditLocationsListComponent,
                canActivate: [CanEditGeneralProjectPermissionGuard],
                resolve: {
                  project: ProjectSummaryResolve,
                  locations: LocationsResolve
                }
              },
              {
                path: ':locationId',
                component: LocationLandingComponent,
                resolve: {
                  project: ProjectSummaryResolve,
                  location: LocationResolve
                }
              }
            ]
          },
          {
            path: 'locationsets',
            canActivate: [CanReadGeneralProjectPermissionGuard],
            children: [
              {
                path: ':locationSetId',
                component: LocationSetLandingComponent,
                resolve: {
                  project: ProjectSummaryResolve,
                  locationSet: LocationSetResolve
                }
              }
            ]
          },
          {
            path: 'callsheets',
            canActivate: [CanReadCallsheetProjectPermissionGuard],
            children: [
              {
                path: '',
                component: CallsheetsListComponent,
                resolve: {
                  project: ProjectSummaryResolve,
                  callsheets:  CallsheetsResolve
                }
              },
              {
                path: ':callsheetId',
                component: CallsheetComponent,
                resolve: {
                  project: ProjectSummaryResolve,
                  callsheet: CallsheetResolve
                }
              },
              {
                path: ':callsheetId/wizard',
                canActivate: [CanEditGeneralProjectPermissionGuard],
                children: [
                  {
                    path: '1',
                    component: CallsheetWizardStep1Component,
                    resolve: {
                      project: ProjectSummaryResolve,
                      callsheet: CallsheetResolve
                    }
                  },
                  {
                    path: '2',
                    component: CallsheetWizardStep2Component,
                    resolve: {
                      project: ProjectSummaryResolve,
                      callsheet: CallsheetSummaryResolve,
                      scenes: CallsheetSceneLocationsResolve
                    }
                  },
                  {
                    path: '3',
                    component: CallsheetWizardStep3Component,
                    resolve: {
                      project: ProjectSummaryResolve,
                      callsheet: CallsheetSummaryResolve,
                      scenes: CallsheetSceneCharactersResolve
                    }
                  },
                  {
                    path: '4',
                    component: CallsheetWizardStep4Component,
                    resolve: {
                      project: ProjectSummaryResolve,
                      callsheet: CallsheetSummaryResolve,
                      characters: CallsheetCharactersCharactersResolve
                    }
                  }
                ]
              }
            ]
          },
          {
            path: 'slates',
            canActivate: [CanReadGeneralProjectPermissionGuard],
            children: [
              {
                path: '',
                component: SlatesListComponent,
                resolve: {
                  project: ProjectSummaryResolve,
                  slates: SlatesResolve,
                }
              },
              {
                path: ':slateId',
                component: SlateLandingComponent,
                resolve: {
                  project: ProjectSummaryResolve,
                  slate: SlateResolve,
                  scenes: ScenesResolve,
                  shootingDays: ShootingDaysResolve
                }
              }
            ]
          },
          {
            path: 'charts',
            canActivate: [CanReadGeneralProjectPermissionGuard],
            children: [
              {
                path: '',
                component: ChartLandingComponent,
                resolve: {
                  project: ProjectSummaryResolve,
                  charts: ProjectChartsResolve
                }
              }
            ],
          },
          {
            path: 'shootingdays',
            canActivate: [CanReadGeneralProjectPermissionGuard],
            children: [
              {
                path: '',
                component: ShootingDayReportsListComponent,
                resolve: {
                  project: ProjectSummaryResolve,
                  shootingDays: CompletedShootingDaysResolve,
                  availableDays: AvailableCompletionShootingDaysResolve
                }
              },
              {
                path: ':shootingDayId',
                component: ShootingDayReportLandingComponent,
                resolve: {
                  project: ProjectSummaryResolve,
                  shootingDay: ShootingDayResolve
                }
              }
            ]
          },
          {
            path: 'units',
            canActivate: [CanReadGeneralProjectPermissionGuard],
            children: [
              {
                path: '',
                component: CrewUnitsListComponent,
                resolve: {
                  project: ProjectSummaryResolve,
                  crewUnits: CrewUnitsResolve
                }
              },
              {
                path: 'user',
                children: [
                  {
                    path: '',
                    component: MyCrewUnitsListComponent,
                    resolve: {
                      project: ProjectSummaryResolve,
                      crewUnits: UserCrewUnitsResolve
                    }
                  },
                  {
                    path: 'nav/:navType',
                    component: CrewUnitsNavListComponent,
                    resolve: {
                      project: ProjectSummaryResolve,
                      crewUnits: UserCrewUnitsResolve
                    }
                  }
                ]
              },
              {
                path: 'nav/:navType',
                component: CrewUnitsNavListComponent,
                resolve: {
                  project: ProjectSummaryResolve,
                  crewUnits: CrewUnitsResolve
                }
              }
            ]
          },
          {
            path: 'unitlists',
            canActivate: [CanReadGeneralProjectPermissionGuard],
            children: [
              {
                path: ':crewUnitId',
                component: CrewLandingComponent,
                resolve: {
                  project: ProjectSummaryResolve,
                  crewUnit: CrewUnitSummaryResolve,
                  departments: CrewDepartmentsResolve
                }
              }
            ]
          },
          {
            path: 'scriptuploads',
            canActivate: [CanEditGeneralProjectPermissionGuard],
            children: [
              {
                path: '',
                component: ScriptUploadComponent,
                resolve: {
                  project: ProjectSummaryResolve
                }
              },
              {
                path: ':scriptUploadId',
                component: ScriptUploadLandingComponent,
                resolve: {
                  project: ProjectSummaryResolve,
                  scriptUpload: ScriptUploadResolve
                }
              }
            ],
          },
          {
            path: 'scripttext',
            canActivate: [CanReadGeneralProjectPermissionGuard],
            children: [
              {
                path: '',
                component: ScriptTextLandingComponent,
                resolve: {
                  project: ProjectSummaryResolve,
                  sceneTexts: ScriptTextResolve
                }
              },
              {
                path: 'user',
                component: ScriptTextUserComponent,
                resolve: {
                  project: ProjectSummaryResolve,
                  sceneTexts: ScriptTextUserResolve
                }
              },
              {
                path: ':callsheetId/callsheet',
                component: ScriptTextCallsheetComponent,
                resolve: {
                  project: ProjectSummaryResolve,
                  callsheet: CallsheetSummaryResolve,
                  sceneTexts: ScriptTextCallsheetResolve
                }
              }
            ],
          },
        ],
      },
    ],
  },
  {
    path: 'profile',
    canActivate: [AuthGuard],
    children: [
      {
        path: '',
        component: UserProfileLandingComponent,
        resolve: {
          userProfile: UserProfileResolve
        }
      }
    ]
  },
  { path: '**',    component: NoContentComponent },
];
