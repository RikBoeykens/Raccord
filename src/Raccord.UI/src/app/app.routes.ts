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
  LocationsListComponent
} from './projects';
import { ScenePropertiesLandingComponent } from './projects';

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
  LocationResolve
} from './projects';

import { CanDeactivateGuard } from './shared/service/can-deactivate-guard.service';

export const ROUTES: Routes = [
  { path: '',      component: DashboardComponent },
  { path: 'dashboard',  component: DashboardComponent },
  { path: 'search',  component: SearchComponent },
  {
    path: 'projects',
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
                  characters: SceneCharactersResolve
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
              }
            ]
          }
        ],
      },
    ],
  },
  { path: '**',    component: NoContentComponent },
];
