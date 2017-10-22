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
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';

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
import { SceneBreakdownItemsComponent } from './projects';
import { 
  SceneShootingDaysComponent,
  SceneSlatesComponent,
  SceneTimingsComponent,
  ChooseSceneDialog
} from './projects';
import { ScriptLocationsListComponent } from './projects';
import { EditScriptLocationComponent } from './projects';
import { ScriptLocationLandingComponent } from './projects';
import { 
  ScriptLocationImagesComponent,
  ScriptLocationSetsComponent 
} from './projects';
import { SearchScriptLocationComponent } from './projects';
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
import { 
  CharactersListComponent,
  EditCharacterComponent,
  CharacterLandingComponent,
  CharacterImagesComponent,
  CharacterScenesComponent,
  CharacterScheduleComponent,
  SearchCharacterComponent 
} from './projects';
import { BreakdownLandingComponent } from './projects';
import { BreakdownTypeSettingsComponent } from './projects';
import { EditBreakdownTypeComponent } from './projects';
import { BreakdownTypeLandingComponent } from './projects';
import { BreakdownItemLandingComponent } from './projects';
import { EditBreakdownItemComponent } from './projects';
import { SearchBreakdownItemComponent } from './projects';
import { BreakdownItemImagesComponent } from './projects';
import { BreakdownItemScenesComponent } from './projects';
import { 
  ScheduleLandingComponent,
  ScheduleSceneLandingComponent,
  LocationsListComponent,
  EditLocationComponent,
  LocationLandingComponent,
  LocationLocationSetsComponent,
  LocationScheduleComponent,
  EditLocationSetComponent,
  LocationSetLandingComponent,
  LocationSetScheduleComponent,
  CallsheetsListComponent,
  NewCallsheetComponent,
  CallsheetComponent,
  CallsheetWizardStep1Component,
  CallsheetWizardStep2Component,
  CallsheetWizardStep3Component,
  CallsheetWizardStep4Component,
  SlatesListComponent,
  SlateLandingComponent,
  SlateImagesComponent,
  ChooseShootingDayDialog,
  ChartLandingComponent,
  ShootingDayReportsListComponent,
  ShootingDayReportLandingComponent,
  ShootingDaySceneListItem,
  EditShootingDaySceneDialog,
  CrewLandingComponent,
  EditCrewMemberDialog
} from './projects';
import { ScenePropertiesLandingComponent } from './projects';
import { SelectEntityComponent } from './shared';
import { LoginComponent } from "./security";
import { 
  AdminSearchProjectComponent,
  AdminProjectsListComponent,
  AdminAddProjectComponent,
  AdminProjectLandingComponent,
  AdminProjectSettingsComponent,
  AdminUsersListComponent,
  AdminAddUserComponent,
  AdminUserLandingComponent
} from "./admin";
import{
  RaccordChartComponent
} from "./charts";

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
  SceneBreakdownItemsComponent,
  SceneShootingDaysComponent,
  SceneSlatesComponent,
  SceneTimingsComponent,
  ScriptLocationsListComponent,
  EditScriptLocationComponent,
  ScriptLocationLandingComponent,
  ScriptLocationImagesComponent,
  ScriptLocationSetsComponent,
  SearchScriptLocationComponent,
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
  CharacterScheduleComponent,
  SearchCharacterComponent,
  BreakdownLandingComponent,
  BreakdownTypeSettingsComponent,
  EditBreakdownTypeComponent,
  BreakdownTypeLandingComponent,
  BreakdownItemLandingComponent,
  EditBreakdownItemComponent,
  SearchBreakdownItemComponent,
  BreakdownItemImagesComponent,
  BreakdownItemScenesComponent,
  ScheduleLandingComponent,
  ScheduleSceneLandingComponent,
  LocationsListComponent,
  EditLocationComponent,
  LocationLandingComponent,
  LocationLocationSetsComponent,
  LocationScheduleComponent,
  EditLocationSetComponent,
  LocationSetLandingComponent,
  LocationSetScheduleComponent,
  CallsheetsListComponent,
  NewCallsheetComponent,
  CallsheetComponent,
  CallsheetWizardStep1Component,
  CallsheetWizardStep2Component,
  CallsheetWizardStep3Component,
  CallsheetWizardStep4Component,
  SlatesListComponent,
  SlateLandingComponent,
  SlateImagesComponent,
  ChartLandingComponent,
  ShootingDayReportsListComponent,
  ShootingDayReportLandingComponent,
  ShootingDaySceneListItem,
  CrewLandingComponent,
  ScenePropertiesLandingComponent,
  SelectEntityComponent,
  LoginComponent,
  AdminSearchProjectComponent,
  AdminProjectsListComponent,
  AdminAddProjectComponent,
  AdminProjectLandingComponent,
  AdminProjectSettingsComponent,
  AdminUsersListComponent,
  AdminAddUserComponent,
  AdminUserLandingComponent,
  RaccordChartComponent,
];

const ENTRY_COMPONENTS = [
  ChooseSceneDialog,
  ChooseShootingDayDialog,
  EditShootingDaySceneDialog,
  EditCrewMemberDialog
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
import { 
  SceneResolve,
  ScenesResolve,
  SceneCharactersResolve 
} from './projects';
import { ScriptLocationHttpService } from './projects';
import { ImageScriptLocationHttpService } from './projects';
import { ScriptLocationResolve } from './projects';
import { ScriptLocationsResolve } from './projects';
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
import { ScheduleDayHttpService } from './projects';
import { ScheduleDayResolve } from './projects';
import { ScheduleDaysResolve } from './projects';
import { ScheduleDayNoteHttpService } from './projects';
import { ScheduleDayNoteResolve } from './projects';
import { ScheduleDayNotesResolve } from './projects';
import { 
  ScheduleSceneHttpService,
  ScheduleSceneResolve,
  ScheduleCharacterHttpService,
  LocationHttpService,
  LocationResolve,
  LocationsResolve,
  LocationSetHttpService,
  LocationSetResolve,
  SceneLocationSetsResolve,
  ShootingDayHttpService,
  AvailableCallsheetShootingDaysResolve,
  AvailableCompletionShootingDaysResolve,
  CompletedShootingDaysResolve,
  ShootingDaysResolve,
  ShootingDayResolve,
  ShootingDaySceneHttpService,
  CallsheetHttpService,
  CallsheetsResolve,
  CallsheetResolve,
  CallsheetSummaryResolve,
  CallsheetSceneHttpService,
  CallsheetSceneLocationsResolve,
  CallsheetSceneCharactersResolve,
  CallsheetSceneCharacterHttpService,
  CallsheetCharacterHttpService,
  CallsheetCharactersCharactersResolve,
  CharacterCallHttpService,
  SlateHttpService,
  SlateResolve,
  SlatesResolve,
  ImageSlateHttpService,
  TakeHttpService,
  TakeResolve,
  TakesResolve,
  CrewDepartmentHttpService,
  CrewDepartmentsResolve,
  CrewMemberHttpService,
  CrewMemberResolve,
  CrewMembersResolve
} from './projects';

import {
  AuthService,
  AuthGuard
} from "./security";

import {
  AccountHttpService
} from "./account";

import {
  AdminProjectHttpService,
  AdminProjectsResolve,
  AdminProjectResolve,
  AdminGuard,
  AdminUserHttpService,
  AdminUsersResolve,
  AdminUserResolve,
  AdminProjectUserHttpService,
  AdminProjectUsersResolve,
  AdminUserProjectsResolve,
  AdminSearchEngineService
} from "./admin";

import {
  ChartHttpService,
  ProjectChartsResolve
} from "./charts";

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
  SceneCharactersResolve,
  ScriptLocationHttpService,
  ImageScriptLocationHttpService,
  ScriptLocationResolve,
  ScriptLocationsResolve,
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
  BreakdownItemsResolve,
  ScheduleDayHttpService,
  ScheduleDayResolve,
  ScheduleDaysResolve,
  ScheduleDayNoteHttpService,
  ScheduleDayNoteResolve,
  ScheduleDayNotesResolve,
  ScheduleSceneHttpService,
  ScheduleSceneResolve,
  ScheduleCharacterHttpService,
  LocationHttpService,
  LocationsResolve,
  LocationResolve,
  LocationSetHttpService,
  LocationSetResolve,
  SceneLocationSetsResolve,
  AuthService,
  AuthGuard,
  AccountHttpService,
  ShootingDayHttpService,
  AvailableCallsheetShootingDaysResolve,
  AvailableCompletionShootingDaysResolve,
  CompletedShootingDaysResolve,
  ShootingDaysResolve,
  ShootingDayResolve,
  ShootingDaySceneHttpService,
  CallsheetHttpService,
  CallsheetsResolve,
  CallsheetResolve,
  CallsheetSummaryResolve,
  CallsheetSceneHttpService,
  CallsheetSceneLocationsResolve,
  CallsheetSceneCharactersResolve,
  CallsheetSceneCharacterHttpService,
  CallsheetCharacterHttpService,
  CallsheetCharactersCharactersResolve,
  CharacterCallHttpService,
  SlateHttpService,
  SlateResolve,
  SlatesResolve,
  ImageSlateHttpService,
  TakeHttpService,
  TakeResolve,
  TakesResolve,
  AdminProjectHttpService,
  AdminProjectsResolve,
  AdminProjectResolve,
  AdminGuard,
  AdminUserHttpService,
  AdminUsersResolve,
  AdminUserResolve,
  AdminProjectUserHttpService,
  AdminProjectUsersResolve,
  AdminUserProjectsResolve,
  AdminSearchEngineService,
  ChartHttpService,
  ProjectChartsResolve,
  CrewDepartmentHttpService,
  CrewDepartmentsResolve,
  CrewMemberHttpService,
  CrewMemberResolve,
  CrewMembersResolve
];

// Directives
import { HighlightDirective } from './shared/directives/highlight.directive';
import { FocusDirective } from './shared/directives/focus.directive';

const DIRECTIVES = [
  HighlightDirective,
  FocusDirective
];

// Pipes
import { PageLengthPipe } from './shared/pipes/page-length.pipe';
import { TimespanPipe } from './shared/pipes/timespan.pipe';

const PIPES = [
    PageLengthPipe,
    TimespanPipe
];

// external modules
import { DragulaModule } from 'ng2-dragula';
import { MaterialModule } from '@angular/material';
import { FlexLayoutModule } from '@angular/flex-layout';
import { Ng2HighchartsModule } from 'ng2-highcharts';
import { AgmCoreModule } from '@agm/core';

import '../styles/styles.scss';
import '../styles/headings.css';



/**
 * `AppModule` is the main entry point into Angular2's bootstraping process
 */
@NgModule({
  bootstrap: [ AppComponent ],
  declarations: [
    COMPONENTS,
    ENTRY_COMPONENTS,
    DIRECTIVES,
    PIPES
  ],
  entryComponents:[
    ENTRY_COMPONENTS
  ],
  imports: [ // import Angular's modules
    BrowserModule,
    BrowserAnimationsModule,
    FormsModule,
    HttpModule,
    DragulaModule,
    MaterialModule,
    FlexLayoutModule,
    Ng2HighchartsModule,
    AgmCoreModule.forRoot({
      apiKey: 'AIzaSyAHVRCUkTtP9FDacHfHoEJDeWQu0sRA7-U'
    }),
    RouterModule.forRoot(ROUTES, { preloadingStrategy: PreloadAllModules })
  ],
  providers: [ // expose our Services and Providers into Angular's dependency injection
    ENV_PROVIDERS,
    APP_PROVIDERS
  ]
})
export class AppModule {}
