import { NgModule }     from '@angular/core';
import { RouterModule } from '@angular/router';

import { DashboardComponent } from './dashboard/dashboard.component';

import { ProjectsListComponent } from './projects/component/projects-list/projects-list.component';
import { AddProjectComponent } from './projects/component/add-project/add-project.component';
import { EditProjectComponent } from './projects/component/edit-project/edit-project.component';
import { ProjectLandingComponent } from './projects/component/project-landing/project-landing.component';

import { ProjectsResolve }        from './projects/service/projects-resolve.service';
import { ProjectResolve }        from './projects/service/project-resolve.service';
import { ProjectSummaryResolve }        from './projects/service/project-summary-resolve.service';


import { ScenesListComponent } from './projects/children/scenes/component/scenes-list/scenes-list.component';

import { ScenesResolve }        from './projects/children/scenes/service/scenes-resolve.service';
import { SceneResolve }        from './projects/children/scenes/service/scene-resolve.service';

import { CanDeactivateGuard } from './shared/service/can-deactivate-guard.service';


@NgModule({
  imports: [
    RouterModule.forRoot([
      {
        path: '',
        redirectTo: '/dashboard',
        pathMatch: 'full'
      },
      {
        path: 'dashboard',
        component: DashboardComponent,
      },
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
                component: ScenesListComponent,
                resolve:{
                  project: ProjectSummaryResolve,
                  scenes: ScenesResolve
                }
              }
            ],
          },
        ],
      }
    ])
  ],
  exports: [
    RouterModule
  ]
})
export class AppRoutingModule {}