import { Routes } from '@angular/router';
import { DashboardComponent } from './dashboard';
import { NoContentComponent } from './no-content';
import { SearchComponent } from './search/component';
import { AddProjectComponent } from './projects';
import { EditProjectComponent } from './projects';
import { ProjectLandingComponent } from './projects';
import { ProjectsListComponent } from './projects';
import { ScenesListComponent } from './projects';
import { SceneLandingComponent } from './projects';
import { 
  ScriptLocationsListComponent,
  ScriptLocationLandingComponent
 } from './projects';
import { IntExtListComponent } from './projects';
import { IntExtLandingComponent } from './projects';
import { DayNightListComponent } from './projects';
import { DayNightLandingComponent } from './projects';
import { ImagesListComponent } from './projects';
import { ImageLandingComponent } from './projects';
import { CharactersListComponent } from './projects';
import { CharacterLandingComponent } from './projects';
import { BreakdownLandingComponent } from './projects';
import { BreakdownTypeSettingsComponent } from './projects';
import { BreakdownTypeLandingComponent } from './projects';
import { BreakdownItemLandingComponent } from './projects';
import { 
  ScheduleLandingComponent,
  ScheduleSceneLandingComponent,
  LocationsListComponent,
  LocationLandingComponent,
  LocationSetLandingComponent,
  CallsheetsListComponent,
  NewCallsheetComponent,
  CallsheetComponent,
  CallsheetWizardStep1Component,
  CallsheetWizardStep2Component,
  CallsheetWizardStep3Component,
  CallsheetWizardStep4Component,
} from './projects';
import { ScenePropertiesLandingComponent } from './projects';
import { LoginComponent } from "./security";
import { 
  AdminProjectsListComponent,
  AdminAddProjectComponent,
  AdminProjectLandingComponent,
  AdminProjectSettingsComponent
} from "./admin";

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
import { BreakdownTypeResolve } from './projects';
import { BreakdownTypesResolve } from './projects';
import { BreakdownItemResolve } from './projects';
import { BreakdownItemsResolve } from './projects';
import { 
  ScheduleDaysResolve,
  ScheduleSceneResolve,
  LocationsResolve,
  LocationResolve,
  LocationSetResolve,
  SceneLocationSetsResolve,
  AvailableShootingDaysResolve,
  CallsheetsResolve,
  CallsheetResolve,
  CallsheetSummaryResolve,
  CallsheetSceneLocationsResolve,
  CallsheetSceneCharactersResolve,
  CallsheetCharactersCharactersResolve
} from './projects';
import { 
  AdminProjectsResolve,
  AdminProjectResolve,
  AdminGuard,
  AdminUsersResolve,
  AdminUserResolve
} from "./admin";

import { CanDeactivateGuard } from './shared/service/can-deactivate-guard.service';
import { AuthGuard } from "./security";

export const ROUTES: Routes = [
  { path: '',      component: DashboardComponent, canActivate: [AuthGuard] },
  { path: 'dashboard',  component: DashboardComponent, canActivate: [AuthGuard] },
  { path: 'login',  component: LoginComponent },
  { path: 'search',  component: SearchComponent, canActivate: [AuthGuard] },
  { 
    path: 'admin',
    canActivate: [AdminGuard],
    children:[
      {
        path: 'projects',
        children:[
          {
            path: '',
            component: AdminProjectsListComponent,
            resolve:{
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
            children:[
              {
                path: '',
                component: AdminProjectLandingComponent,
                resolve:{
                  project: AdminProjectResolve
                }               
              },
              {
                path: 'settings',
                component: AdminProjectSettingsComponent,
                resolve:{
                  project: AdminProjectResolve
                },
                canDeactivate: [CanDeactivateGuard],
              },
            ]
          }
        ]
      }
    ]
  },
  {
    path: 'projects',
    canActivate: [AuthGuard],
    children:[
      {
        path:'',
        component: ProjectsListComponent,
        resolve:{
          projects: ProjectsResolve
        }
      },
      {
        path: 'add',
        component: AddProjectComponent,
        canDeactivate: [CanDeactivateGuard],
      },
      {
        path: ':projectId',
        children:[
          {
            path: 'edit',
            component: EditProjectComponent,
            resolve:{
              project: ProjectSummaryResolve
            },
            canDeactivate: [CanDeactivateGuard],
          },
          {
            path: '',
            component: ProjectLandingComponent,
            resolve:{
              project: ProjectResolve
            }               
          },
          {
            path: 'scenes',
            children:[
              {
                path: '',
                component: ScenesListComponent,
                resolve:{
                  project: ProjectSummaryResolve,
                  scenes: ScenesResolve
                },
              },
              {
                path: ':sceneId',
                component: SceneLandingComponent,
                resolve:{
                  project: ProjectSummaryResolve,
                  scene: SceneResolve,
                  breakdownTypes: BreakdownTypesResolve
                }
              }
            ]
          },
          {
            path: 'scriptlocations',
            children:[
              {
                path: '',
                component: ScriptLocationsListComponent,
                resolve:{
                  project: ProjectSummaryResolve,
                  scriptLocations: ScriptLocationsResolve
                },
              },
              {
                path: ':scriptLocationId',
                component: ScriptLocationLandingComponent,
                resolve:{
                  project: ProjectSummaryResolve,
                  scriptLocation: ScriptLocationResolve
                },
              }
            ]
          },
          {
            path: 'sceneproperties',
            component: ScenePropertiesLandingComponent,
            resolve:{
              project: ProjectSummaryResolve,
            }
          },
          {
            path: 'daynights',
            children:[
              {
                path: '',
                component: DayNightListComponent,
                resolve:{
                  project: ProjectSummaryResolve,
                  dayNights: DayNightsResolve
                },
              },
              {
                path: ':dayNightId',
                component: DayNightLandingComponent,
                resolve:{
                  project: ProjectSummaryResolve,
                  dayNight: DayNightResolve
                },
              }
            ]
          },
          {
            path: 'intexts',
            children:[
              {
                path: '',
                component: IntExtListComponent,
                resolve:{
                  project: ProjectSummaryResolve,
                  intExts: IntExtsResolve
                },
              },
              {
                path: ':intExtId',
                component: IntExtLandingComponent,
                resolve:{
                  project: ProjectSummaryResolve,
                  intExt: IntExtResolve
                },
              }
            ]
          },
          {
            path: 'images',
            children:[
              {
                path: '',
                component: ImagesListComponent,
                resolve:{
                  project: ProjectSummaryResolve,
                  images: ImagesResolve
                },
              },
              {
                path: ':imageId',
                component: ImageLandingComponent,
                resolve:{
                  project: ProjectSummaryResolve,
                  image: ImageResolve
                },
              }
            ]
          },
          {
            path: 'characters',
            children:[
              {
                path: '',
                component: CharactersListComponent,
                resolve:{
                  project: ProjectSummaryResolve,
                  characters: CharactersResolve
                },
              },
              {
                path: ':characterId',
                component: CharacterLandingComponent,
                resolve:{
                  project: ProjectSummaryResolve,
                  character: CharacterResolve
                },
              }
            ]
          },
          {
            path: 'breakdown',
            children:[
              {
                path: '',
                component: BreakdownLandingComponent,
                resolve:{
                  project: ProjectSummaryResolve,
                  breakdownTypes: BreakdownTypesResolve
                },
              },
              {
                path: 'settings',
                component: BreakdownTypeSettingsComponent,
                resolve:{
                  project: ProjectSummaryResolve,
                  breakdownTypes: BreakdownTypesResolve
                },
              },
              {
                path: 'types/:breakdownTypeId',
                children:[
                  {
                    path: '',
                    component: BreakdownTypeLandingComponent,
                    resolve:{
                      project: ProjectSummaryResolve,
                      breakdownType: BreakdownTypeResolve
                    }
                  }
                ]
              },
              {
                path: 'items/:breakdownItemId',
                children:[
                  {
                    path: '',
                    component: BreakdownItemLandingComponent,
                    resolve:{
                      project: ProjectSummaryResolve,
                      breakdownItem: BreakdownItemResolve
                    }
                  }
                ]
              }
            ]
          },
          {
            path: 'scheduling',
            children:[
              {
                path: '',
                component: ScheduleLandingComponent,
                resolve:{
                  project: ProjectSummaryResolve,
                  scheduleDays: ScheduleDaysResolve,
                }
              },
              {
                path: ':sceneId/scene/:scheduleSceneId',
                component: ScheduleSceneLandingComponent,
                resolve:{
                  project: ProjectSummaryResolve,
                  scheduleScene: ScheduleSceneResolve,
                  characters: SceneCharactersResolve,
                  locationSets: SceneLocationSetsResolve
                }
              },
            ]
          },
          {
            path: "locations",
            children:[
              {
                path: "",
                component: LocationsListComponent,
                resolve:{
                  project: ProjectSummaryResolve,
                  locations: LocationsResolve
                }
              },
              {
                path: ":locationId",
                component: LocationLandingComponent,
                resolve:{
                  project: ProjectSummaryResolve,
                  location: LocationResolve
                }
              }
            ]
          },
          {
            path: "locationsets",
            children:[
              {
                path: ":locationSetId",
                component: LocationSetLandingComponent,
                resolve:{
                  project: ProjectSummaryResolve,
                  locationSet: LocationSetResolve
                }
              }
            ]
          },
          {
            path: "callsheets",
            children:[
              {
                path: "",
                component: CallsheetsListComponent,
                resolve:{
                  project: ProjectSummaryResolve,
                  callsheets:  CallsheetsResolve
                }
              },
              {
                path: "new",
                component: NewCallsheetComponent,
                resolve:{
                  project: ProjectSummaryResolve,
                  availableDays: AvailableShootingDaysResolve
                }
              },
              {
                path: ":callsheetId",
                component: CallsheetComponent,
                resolve:{
                  project: ProjectSummaryResolve,
                  callsheet: CallsheetResolve
                }
              },
              {
                path: ":callsheetId/wizard",
                children:[
                  {
                    path: "1",                
                    component: CallsheetWizardStep1Component,
                    resolve:{
                      project: ProjectSummaryResolve,
                      callsheet: CallsheetResolve
                    }
                  },
                  {
                    path: "2",                
                    component: CallsheetWizardStep2Component,
                    resolve:{
                      project: ProjectSummaryResolve,
                      callsheet: CallsheetSummaryResolve,
                      scenes: CallsheetSceneLocationsResolve
                    }
                  },
                  {
                    path: "3",                
                    component: CallsheetWizardStep3Component,
                    resolve:{
                      project: ProjectSummaryResolve,
                      callsheet: CallsheetSummaryResolve,
                      scenes: CallsheetSceneCharactersResolve
                    }
                  },
                  {
                    path: "4",                
                    component: CallsheetWizardStep4Component,
                    resolve:{
                      project: ProjectSummaryResolve,
                      callsheet: CallsheetSummaryResolve,
                      characters: CallsheetCharactersCharactersResolve
                    }
                  }
                ]

              }
            ]
          }
        ],
      },
    ],
  },
  { path: '**',    component: NoContentComponent },
];
