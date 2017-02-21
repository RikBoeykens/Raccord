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
import { LocationsListComponent } from './projects';
import { LocationLandingComponent } from './projects';
import { IntExtListComponent } from './projects';
import { IntExtLandingComponent } from './projects';
import { DayNightListComponent } from './projects';
import { ScenePropertiesLandingComponent } from './projects';

import { ProjectResolve } from './projects';
import { ProjectSummaryResolve } from './projects';
import { ProjectsResolve } from './projects';
import { SceneResolve } from './projects';
import { ScenesResolve } from './projects';
import { LocationResolve } from './projects';
import { LocationsResolve } from './projects';
import { IntExtResolve } from './projects';
import { IntExtsResolve } from './projects';
import { DayNightResolve } from './projects';
import { DayNightsResolve } from './projects';

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
                  scene: SceneResolve
                }
              }
            ]
          },
          {
            path: 'locations',
            children:[
              {
                path: '',
                component: LocationsListComponent,
                resolve:{
                  project: ProjectSummaryResolve,
                  locations: LocationsResolve
                },
              },
              {
                path: ':locationId',
                component: LocationLandingComponent,
                resolve:{
                  project: ProjectSummaryResolve,
                  location: LocationResolve
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
          }
        ],
      },
    ],
  },
  { path: '**',    component: NoContentComponent },
];
