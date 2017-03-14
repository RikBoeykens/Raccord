import { BrowserModule } from '@angular/platform-browser';
import { FormsModule } from '@angular/forms';
import { HttpModule } from '@angular/http';
import {
  NgModule,
  ApplicationRef
} from '@angular/core';
import {
  removeNgStyles,
  createNewHosts,
  createInputTransfer
} from '@angularclass/hmr';
import {
  RouterModule,
  PreloadAllModules
} from '@angular/router';

/*
 * Platform and Environment providers/directives/pipes
 */
import { ENV_PROVIDERS } from './environment';
import { ROUTES } from './app.routes';

// App is our top level component
import { AppComponent } from './app.component';
import { NoContentComponent } from './no-content';

import { DashboardComponent } from './dashboard';
import { LoadingComponent } from './loading/component';
import { NavbarComponent } from './navbar';
import { SearchComponent } from './search/component';
import { SearchResultComponent } from './search/component';
import { AddProjectComponent } from './projects';
import { EditProjectComponent } from './projects';
import { ProjectLandingComponent } from './projects';
import { ProjectsListComponent } from './projects';
import { ScenesListComponent } from './projects';
import { EditSceneComponent } from './projects';
import { SceneLandingComponent } from './projects';
import { SceneImagesComponent } from './projects';
import { SceneCharactersComponent } from './projects';
import { LocationsListComponent } from './projects';
import { EditLocationComponent } from './projects';
import { LocationLandingComponent } from './projects';
import { LocationImagesComponent } from './projects';
import { SearchLocationComponent } from './projects';
import { IntExtListComponent } from './projects';
import { EditIntExtComponent } from './projects';
import { IntExtLandingComponent } from './projects';
import { SearchIntExtComponent } from './projects';
import { DayNightListComponent } from './projects';
import { EditDayNightComponent } from './projects';
import { DayNightLandingComponent } from './projects';
import { SearchDayNightComponent } from './projects';
import { ImagesListComponent } from './projects';
import { EditImageComponent } from './projects';
import { ImageLandingComponent } from './projects';
import { UploadImageComponent } from './projects';
import { ShowImageComponent } from './projects';
import { CharactersListComponent } from './projects';
import { EditCharacterComponent } from './projects';
import { CharacterLandingComponent } from './projects';
import { CharacterImagesComponent } from './projects';
import { CharacterScenesComponent } from './projects';
import { SearchCharacterComponent } from './projects';
import { BreakdownLandingComponent } from './projects';
import { BreakdownTypeSettingsComponent } from './projects';
import { EditBreakdownTypeComponent } from './projects';
import { BreakdownTypeLandingComponent } from './projects';
import { BreakdownItemLandingComponent } from './projects';
import { EditBreakdownItemComponent } from './projects';
import { BreakdownItemImagesComponent } from './projects';
import { ScenePropertiesLandingComponent } from './projects';
import { SelectEntityComponent } from './shared';

const COMPONENTS =[
  AppComponent,
  NoContentComponent,
  DashboardComponent,
  LoadingComponent,
  NavbarComponent,
  SearchComponent,
  SearchResultComponent,
  AddProjectComponent,
  EditProjectComponent,
  ProjectLandingComponent,
  ProjectsListComponent,
  ScenesListComponent,
  EditSceneComponent,
  SceneLandingComponent,
  SceneImagesComponent,
  SceneCharactersComponent,
  LocationsListComponent,
  EditLocationComponent,
  LocationLandingComponent,
  LocationImagesComponent,
  SearchLocationComponent,
  IntExtListComponent,
  EditIntExtComponent,
  IntExtLandingComponent,
  SearchIntExtComponent,
  SearchDayNightComponent,
  DayNightListComponent,
  EditDayNightComponent,
  DayNightLandingComponent,
  ImagesListComponent,
  ImageLandingComponent,
  EditImageComponent,
  UploadImageComponent,
  ShowImageComponent,
  CharactersListComponent,
  EditCharacterComponent,
  CharacterLandingComponent,
  CharacterImagesComponent,
  CharacterScenesComponent,
  SearchCharacterComponent,
  BreakdownLandingComponent,
  BreakdownTypeSettingsComponent,
  EditBreakdownTypeComponent,
  BreakdownTypeLandingComponent,
  BreakdownItemLandingComponent,
  EditBreakdownItemComponent,
  BreakdownItemImagesComponent,
  ScenePropertiesLandingComponent,
  SelectEntityComponent
];

// Services
import { LoadingService } from './loading/service/loading.service';
import { CanDeactivateGuard } from './shared/service/can-deactivate-guard.service';
import { DialogService } from './shared/service/dialog.service';
import { SearchEngineService } from './search/service/search-engine.service';
import { ProjectHttpService } from './projects';
import { ProjectResolve } from './projects';
import { ProjectSummaryResolve } from './projects';
import { ProjectsResolve } from './projects';
import { SceneHttpService } from './projects';
import { ImageSceneHttpService } from './projects';
import { CharacterSceneHttpService } from './projects';
import { SceneResolve } from './projects';
import { ScenesResolve } from './projects';
import { LocationHttpService } from './projects';
import { ImageLocationHttpService } from './projects';
import { LocationResolve } from './projects';
import { LocationsResolve } from './projects';
import { IntExtHttpService } from './projects';
import { IntExtResolve } from './projects';
import { IntExtsResolve } from './projects';
import { DayNightHttpService } from './projects';
import { DayNightResolve } from './projects';
import { DayNightsResolve } from './projects';
import { ImageHttpService } from './projects';
import { ImageResolve } from './projects';
import { ImagesResolve } from './projects';
import { CharacterHttpService } from './projects';
import { ImageCharacterHttpService } from './projects';
import { CharacterResolve } from './projects';
import { CharactersResolve } from './projects';
import { BreakdownTypeHttpService } from './projects';
import { BreakdownTypeResolve } from './projects';
import { BreakdownTypesResolve } from './projects';
import { BreakdownItemHttpService } from './projects';
import { ImageBreakdownItemHttpService } from './projects';
import { BreakdownItemSceneHttpService } from './projects';
import { BreakdownItemResolve } from './projects';
import { BreakdownItemsResolve } from './projects';

const APP_PROVIDERS = [
  LoadingService,
  CanDeactivateGuard,
  DialogService,
  SearchEngineService,
  ProjectHttpService,
  ProjectResolve,
  ProjectSummaryResolve,
  ProjectsResolve,
  SceneHttpService,
  ImageSceneHttpService,
  CharacterSceneHttpService,
  SceneResolve,
  ScenesResolve,
  LocationHttpService,
  ImageLocationHttpService,
  LocationResolve,
  LocationsResolve,
  IntExtHttpService,
  IntExtResolve,
  IntExtsResolve,
  DayNightHttpService,
  DayNightResolve,
  DayNightsResolve,
  ImageHttpService,
  ImageResolve,
  ImagesResolve,
  CharacterHttpService,
  ImageCharacterHttpService,
  CharacterResolve,
  CharactersResolve,
  BreakdownTypeHttpService,
  BreakdownTypeResolve,
  BreakdownTypesResolve,
  BreakdownItemHttpService,
  ImageBreakdownItemHttpService,
  BreakdownItemSceneHttpService,
  BreakdownItemResolve,
  BreakdownItemsResolve
];

// Directives
import { HighlightDirective } from './shared/directives/highlight.directive';
import { FocusDirective } from './shared/directives/focus.directive';

const DIRECTIVES =[
  HighlightDirective,
  FocusDirective
];

// Pipes
import { PageLengthPipe } from './shared/pipes/page-length.pipe';

const PIPES = [
    PageLengthPipe
];

// external modules
import { DragulaModule } from 'ng2-dragula';
import { MaterialModule } from '@angular/material';
import { FlexLayoutModule } from '@angular/flex-layout';

import '../styles/styles.scss';
import '../styles/headings.css';



/**
 * `AppModule` is the main entry point into Angular2's bootstraping process
 */
@NgModule({
  bootstrap: [ AppComponent ],
  declarations: [
    COMPONENTS,
    DIRECTIVES,
    PIPES
  ],
  imports: [ // import Angular's modules
    BrowserModule,
    FormsModule,
    HttpModule,
    DragulaModule,
    MaterialModule.forRoot(),
    FlexLayoutModule.forRoot(),
    RouterModule.forRoot(ROUTES, { preloadingStrategy: PreloadAllModules })
  ],
  providers: [ // expose our Services and Providers into Angular's dependency injection
    ENV_PROVIDERS,
    APP_PROVIDERS
  ]
})
export class AppModule {}
