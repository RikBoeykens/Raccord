import { NgModule } from '@angular/core';
import { HttpModule } from '@angular/http';
import { FormsModule } from '@angular/forms';
import { BrowserModule } from '@angular/platform-browser';

// Components
import { AppComponent } from './app.component';
import { AppRoutingModule }     from './app-routing.module';

import { NavbarComponent } from './navbar/main/navbar.component';
import { NavbarSearchComponent } from './navbar/navbar-search/navbar-search.component';
import { NavbarSearchResultComponent } from './navbar/navbar-search-result/navbar-search-result.component';

import { LoadingComponent } from './loading/component/loading.component';

import { DashboardComponent }     from './dashboard/dashboard.component';

import { ProjectsListComponent }     from './projects/component/projects-list/projects-list.component';
import { AddProjectComponent }     from './projects/component/add-project/add-project.component';
import { EditProjectComponent }     from './projects/component/edit-project/edit-project.component';
import { ProjectLandingComponent } from './projects/component/project-landing/project-landing.component';
import { ProjectHttpService }        from './projects/service/project-http.service';
import { ProjectsResolve }        from './projects/service/projects-resolve.service';
import { ProjectResolve }        from './projects/service/project-resolve.service';
import { ProjectSummaryResolve }        from './projects/service/project-summary-resolve.service';

import { ScenesListComponent } from './projects/children/scenes/component/scenes-list/scenes-list.component';
import { EditSceneComponent } from './projects/children/scenes/component/edit-scene/edit-scene.component';
import { SceneHttpService }        from './projects/children/scenes/service/scene-http.service';
import { ScenesResolve }        from './projects/children/scenes/service/scenes-resolve.service';
import { SceneResolve }        from './projects/children/scenes/service/scene-resolve.service';

import { SearchIntExtComponent } from './projects/children/scene-properties/component/search-int-ext.component';
import { IntExtHttpService }        from './projects/children/scene-properties/service/int-ext-http.service';

import { SearchDayNightComponent } from './projects/children/scene-properties/component/search-day-night.component';
import { DayNightHttpService }        from './projects/children/scene-properties/service/day-night-http.service';

import { SearchLocationComponent } from './projects/children/locations/component/search-location.component';
import { LocationHttpService }        from './projects/children/locations/service/location-http.service';

// Services
import { SearchEngineService }  from './search-engine/service/search-engine.service';
import { LoadingService } from './loading/service/loading.service';
import { CanDeactivateGuard } from './shared/service/can-deactivate-guard.service';
import { DialogService } from './shared/service/dialog.service';

// Directives
import { HighlightDirective } from './shared/directives/highlight.directive';
import { FocusDirective } from './shared/directives/focus.directive';

// Vendor
import {ToastModule} from 'ng2-toastr/ng2-toastr';

@NgModule({
    imports: [
        BrowserModule,
        FormsModule,
        HttpModule,
        AppRoutingModule,
        ToastModule
    ],
    declarations: [
        AppComponent,
        NavbarComponent,
        NavbarSearchComponent,
        NavbarSearchResultComponent,
        LoadingComponent,
        DashboardComponent,
        ProjectsListComponent,
        AddProjectComponent,
        EditProjectComponent,
        ProjectLandingComponent,
        ScenesListComponent,
        EditSceneComponent,
        SearchIntExtComponent,
        SearchDayNightComponent,
        SearchLocationComponent,
        HighlightDirective,
        FocusDirective
    ],
    providers: [
        ProjectHttpService,
        ProjectsResolve,
        ProjectResolve,
        ProjectSummaryResolve,
        SceneHttpService,
        ScenesResolve,
        SceneResolve,
        IntExtHttpService,
        DayNightHttpService,
        LocationHttpService,
        SearchEngineService,
        LoadingService,
        CanDeactivateGuard,
        DialogService
    ],
    bootstrap: [AppComponent]
})
export class AppModule { }