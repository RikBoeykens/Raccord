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
import {
  SearchComponent,
  SearchResultComponent,
  SearchEntitiesCollectionComponent,
  SearchEntityComponent
} from './search/component';
import {
  AddProjectComponent,
  EditProjectComponent,
  ProjectLandingComponent,
  ProjectsListComponent,
  ProjectAvatarComponent,
  ScenesListComponent,
  EditScenesListComponent,
  EditSceneComponent,
  SceneLandingComponent,
  SceneImagesComponent,
  SceneCharactersComponent,
  SceneBreakdownItemsComponent,
  SceneShootingDaysComponent,
  SceneSlatesComponent,
  SceneTimingsComponent,
  SceneSummaryComponent,
  FilterScenesComponent,
  ChooseSceneDialog,
  ScriptLocationsListComponent,
  EditScriptLocationsListComponent,
  EditScriptLocationComponent,
  ScriptLocationLandingComponent,
  ScriptLocationImagesComponent,
  ScriptLocationSetsComponent,
  SearchScriptLocationsCollectionComponent,
  SearchScriptLocationComponent,
  IntExtListComponent,
  EditIntExtListComponent,
  EditIntExtComponent,
  IntExtLandingComponent,
  SearchIntExtComponent,
  SearchIntExtsCollectionComponent,
  DayNightListComponent,
  EditDayNightListComponent,
  EditDayNightComponent,
  DayNightLandingComponent,
  SearchDayNightComponent,
  SearchDayNightsCollectionComponent,
  MyCrewUnitsListComponent
} from './projects';
import { ImagesListComponent } from './projects';
import { EditImageComponent } from './projects';
import { ImageLandingComponent } from './projects';
import { UploadImageComponent } from './projects';
import { ShowImageComponent } from './projects';
import {
  CharactersListComponent,
  EditCharactersListComponent,
  EditCharacterComponent,
  CharacterLandingComponent,
  CharacterImagesComponent,
  CharacterScenesComponent,
  CharacterScheduleComponent,
  SearchCharacterComponent,
  CharacterSummaryComponent,
  SearchCharactersCollectionComponent,
  CharacterCastMemberComponent,
  BreakdownsListComponent,
  BreakdownLandingComponent,
  BreakdownSettingsComponent,
  EditBreakdownComponent,
  EditBreakdownTypeDialogComponent,
  BreakdownTypeLandingComponent,
  BreakdownItemLandingComponent,
  EditBreakdownItemComponent,
  SearchBreakdownItemComponent,
  BreakdownItemImagesComponent,
  BreakdownItemScenesComponent,
  SearchBreakdownCollectionComponent,
  EditScheduleComponent,
  ScheduleLandingComponent,
  ScheduleSceneLandingComponent,
  LocationsListComponent,
  EditLocationsListComponent,
  EditLocationComponent,
  LocationLandingComponent,
  LocationLocationSetsComponent,
  LocationScheduleComponent,
  EditLocationSetComponent,
  LocationSetLandingComponent,
  LocationSetScheduleComponent,
  SearchLocationComponent,
  SearchLocationsCollectionComponent,
  CallsheetsListComponent,
  CallsheetComponent,
  CallsheetWizardStep1Component,
  CallsheetWizardStep2Component,
  CallsheetWizardStep3Component,
  CallsheetWizardStep4Component,
  ScriptTextCallsheetComponent,
  SlatesListComponent,
  SlateLandingComponent,
  SlateImagesComponent,
  ChooseShootingDayDialog,
  ChooseShootingDayCrewUnitDialogComponent,
  ChartLandingComponent,
  ShootingDayReportsListComponent,
  ShootingDayReportLandingComponent,
  ShootingDaySceneListItem,
  EditShootingDaySceneDialog,
  CrewLandingComponent,
  EditCrewMemberDialog,
  CrewUnitsListComponent,
  CrewUnitsNavListComponent,
  EditCrewUnitDialogComponent,
  ChooseCrewUnitDialogComponent,
  ScriptUploadComponent,
  ScriptUploadLandingComponent,
  ScriptTextLandingComponent,
  ScriptTextUserComponent,
  ScriptTextComponent,
  SceneHeaderComponent,
  SceneActionComponent,
  SceneDialogueComponent,
  EditCommentComponent,
  ShowCommentComponent,
  CommentContainerComponent,
  CastMemberCharactersComponent,
  CastMemberLandingComponent,
  CastMemberScenesComponent,
  CastMembersListComponent,
  EditCastMemberDialogComponent,
  EditCastMembersListComponent
} from './projects';
import { ScenePropertiesLandingComponent } from './projects';
import {
  SelectEntityComponent,
  PlaceholderImageComponent
} from './shared';
import { LoginComponent } from './security';
import {
  AdminSearchProjectComponent,
  AdminProjectsListComponent,
  AdminAddProjectComponent,
  AdminProjectLandingComponent,
  AdminProjectSettingsComponent,
  AdminUsersListComponent,
  AdminAddUserComponent,
  AdminUserLandingComponent,
  AdminProjectUserLandingComponent,
  AdminEditCrewMemberDialog,
  AdminAddCrewMemberDialogComponent,
  AdminAddCastDialogComponent,
  AdminChooseProjectUserDialogComponent,
  AdminCrewUnitLandingComponent,
  AdminCrewUnitsListComponent
} from './admin';
import{
  RaccordChartComponent
} from './charts';
import {
  UserProfileLandingComponent,
  EditUserProfileDialog,
  ShowProfileImageComponent,
  UserAvatarComponent
} from './profile';

const COMPONENTS = [
  AppComponent,
  NoContentComponent,
  DashboardComponent,
  LoadingComponent,
  NavbarComponent,
  SearchComponent,
  SearchResultComponent,
  SearchEntitiesCollectionComponent,
  SearchEntityComponent,
  AddProjectComponent,
  EditProjectComponent,
  ProjectLandingComponent,
  ProjectsListComponent,
  ProjectAvatarComponent,
  ScenesListComponent,
  EditScenesListComponent,
  EditSceneComponent,
  SceneLandingComponent,
  SceneImagesComponent,
  SceneCharactersComponent,
  SceneBreakdownItemsComponent,
  SceneShootingDaysComponent,
  SceneSlatesComponent,
  SceneTimingsComponent,
  SceneSummaryComponent,
  FilterScenesComponent,
  ScriptLocationsListComponent,
  EditScriptLocationsListComponent,
  EditScriptLocationComponent,
  ScriptLocationLandingComponent,
  ScriptLocationImagesComponent,
  ScriptLocationSetsComponent,
  SearchScriptLocationComponent,
  SearchScriptLocationsCollectionComponent,
  IntExtListComponent,
  EditIntExtListComponent,
  EditIntExtComponent,
  IntExtLandingComponent,
  SearchIntExtComponent,
  SearchIntExtsCollectionComponent,
  SearchDayNightComponent,
  DayNightListComponent,
  EditDayNightListComponent,
  EditDayNightComponent,
  DayNightLandingComponent,
  SearchDayNightsCollectionComponent,
  ImagesListComponent,
  ImageLandingComponent,
  EditImageComponent,
  UploadImageComponent,
  ShowImageComponent,
  CharactersListComponent,
  EditCharactersListComponent,
  EditCharacterComponent,
  CharacterLandingComponent,
  CharacterImagesComponent,
  CharacterScenesComponent,
  CharacterScheduleComponent,
  SearchCharacterComponent,
  CharacterSummaryComponent,
  SearchCharactersCollectionComponent,
  CharacterCastMemberComponent,
  BreakdownsListComponent,
  BreakdownLandingComponent,
  BreakdownSettingsComponent,
  EditBreakdownComponent,
  BreakdownTypeLandingComponent,
  BreakdownItemLandingComponent,
  EditBreakdownItemComponent,
  SearchBreakdownItemComponent,
  BreakdownItemImagesComponent,
  BreakdownItemScenesComponent,
  SearchBreakdownCollectionComponent,
  EditScheduleComponent,
  ScheduleLandingComponent,
  ScheduleSceneLandingComponent,
  LocationsListComponent,
  EditLocationsListComponent,
  EditLocationComponent,
  LocationLandingComponent,
  LocationLocationSetsComponent,
  LocationScheduleComponent,
  EditLocationSetComponent,
  LocationSetLandingComponent,
  LocationSetScheduleComponent,
  SearchLocationComponent,
  SearchLocationsCollectionComponent,
  CallsheetsListComponent,
  CallsheetComponent,
  CallsheetWizardStep1Component,
  CallsheetWizardStep2Component,
  CallsheetWizardStep3Component,
  CallsheetWizardStep4Component,
  ScriptTextCallsheetComponent,
  SlatesListComponent,
  SlateLandingComponent,
  SlateImagesComponent,
  ChartLandingComponent,
  ShootingDayReportsListComponent,
  ShootingDayReportLandingComponent,
  ShootingDaySceneListItem,
  CrewLandingComponent,
  CrewUnitsListComponent,
  MyCrewUnitsListComponent,
  CrewUnitsNavListComponent,
  ScriptUploadComponent,
  ScriptUploadLandingComponent,
  ScriptTextLandingComponent,
  ScriptTextUserComponent,
  ScriptTextComponent,
  SceneHeaderComponent,
  SceneActionComponent,
  SceneDialogueComponent,
  EditCommentComponent,
  ShowCommentComponent,
  CommentContainerComponent,
  CastMemberCharactersComponent,
  CastMemberLandingComponent,
  CastMemberScenesComponent,
  CastMembersListComponent,
  EditCastMembersListComponent,
  ScenePropertiesLandingComponent,
  SelectEntityComponent,
  PlaceholderImageComponent,
  LoginComponent,
  AdminSearchProjectComponent,
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
  RaccordChartComponent,
  UserProfileLandingComponent,
  ShowProfileImageComponent,
  UserAvatarComponent
];

const ENTRY_COMPONENTS = [
  ChooseSceneDialog,
  ChooseShootingDayDialog,
  ChooseShootingDayCrewUnitDialogComponent,
  EditShootingDaySceneDialog,
  EditCrewMemberDialog,
  EditCrewUnitDialogComponent,
  ChooseCrewUnitDialogComponent,
  EditUserProfileDialog,
  AdminEditCrewMemberDialog,
  AdminAddCrewMemberDialogComponent,
  AdminAddCastDialogComponent,
  AdminChooseProjectUserDialogComponent,
  EditBreakdownTypeDialogComponent,
  EditCastMemberDialogComponent
];

// Services
import { LoadingService } from './loading/service/loading.service';
import { CanDeactivateGuard } from './shared/service/can-deactivate-guard.service';
import { DialogService } from './shared/service/dialog.service';
import {
  LoadingWrapperService
} from './shared';
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
import {
  BreakdownHttpService,
  BreakdownResolve,
  BreakdownsResolve,
  BreakdownSummaryResolve,
  SelectedBreakdownResolve,
  BreakdownTypeHttpService,
  BreakdownTypeResolve,
  BreakdownTypesResolve,
  BreakdownItemHttpService,
  ImageBreakdownItemHttpService,
  BreakdownItemSceneHttpService,
  BreakdownItemResolve,
  BreakdownItemsResolve
} from './projects';
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
  CrewMembersResolve,
  CrewUnitHttpService,
  CrewUnitResolve,
  CrewUnitSummaryResolve,
  CrewUnitsResolve,
  UserCrewUnitsResolve,
  ScriptUploadHttpService,
  ScriptUploadResolve,
  ScriptTextHttpService,
  ScriptTextResolve,
  ScriptTextCallsheetResolve,
  ScriptTextUserResolve,
  CommentHttpService,
  CastMemberHttpService,
  CastMemberResolve,
  CastMembersResolve
} from './projects';

import {
  AuthService,
  AuthGuard
} from './security';

import {
  AccountHttpService,
  CanEditGeneralProjectPermissionGuard,
  CanEditUsersProjectPermissionGuard,
  CanReadCallsheetProjectPermissionGuard,
  CanReadGeneralProjectPermissionGuard
} from './account';

import {
  AdminProjectHttpService,
  AdminProjectsResolve,
  AdminProjectResolve,
  AdminGuard,
  AdminUserHttpService,
  AdminUsersResolve,
  AdminUserResolve,
  AdminProjectUserHttpService,
  AdminUnitCrewMembersHttpService,
  AdminProjectUserCastHttpService,
  AdminProjectUsersResolve,
  AdminProjectUserResolve,
  AdminUserProjectsResolve,
  AdminSearchEngineService,
  AdminProjectRoleHttpService,
  AdminProjectRolesResolve,
  AdminCrewUnitHttpService,
  AdminCrewUnitMemberHttpService,
  AdminCrewUnitResolve
} from './admin';

import {
  ChartHttpService,
  ProjectChartsResolve
} from './charts';

import {
  UserProfileHttpService,
  UserProfileResolve
} from './profile';

const APP_PROVIDERS = [
  LoadingService,
  CanDeactivateGuard,
  DialogService,
  LoadingWrapperService,
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
  BreakdownHttpService,
  BreakdownsResolve,
  BreakdownResolve,
  BreakdownSummaryResolve,
  SelectedBreakdownResolve,
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
  CanEditGeneralProjectPermissionGuard,
  CanEditUsersProjectPermissionGuard,
  CanReadCallsheetProjectPermissionGuard,
  CanReadGeneralProjectPermissionGuard,
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
  CommentHttpService,
  AdminProjectHttpService,
  AdminProjectsResolve,
  AdminProjectResolve,
  AdminGuard,
  AdminUserHttpService,
  AdminUsersResolve,
  AdminUserResolve,
  AdminProjectUserHttpService,
  AdminUnitCrewMembersHttpService,
  AdminProjectUserCastHttpService,
  AdminProjectUsersResolve,
  AdminProjectUserResolve,
  AdminProjectRoleHttpService,
  AdminProjectRolesResolve,
  AdminUserProjectsResolve,
  AdminSearchEngineService,
  AdminCrewUnitHttpService,
  AdminCrewUnitMemberHttpService,
  AdminCrewUnitResolve,
  ChartHttpService,
  ProjectChartsResolve,
  CrewDepartmentHttpService,
  CrewDepartmentsResolve,
  CrewMemberHttpService,
  CrewMemberResolve,
  CrewMembersResolve,
  CrewUnitHttpService,
  CrewUnitResolve,
  CrewUnitSummaryResolve,
  CrewUnitsResolve,
  UserCrewUnitsResolve,
  ScriptUploadHttpService,
  ScriptUploadResolve,
  ScriptTextHttpService,
  ScriptTextResolve,
  ScriptTextCallsheetResolve,
  ScriptTextUserResolve,
  UserProfileHttpService,
  UserProfileResolve,
  CastMemberHttpService,
  CastMemberResolve,
  CastMembersResolve
];

// Directives
import { HighlightDirective } from './shared/directives/highlight.directive';
import { FocusDirective } from './shared/directives/focus.directive';
import { MatchHeightDirective } from './shared';

const DIRECTIVES = [
  HighlightDirective,
  FocusDirective,
  MatchHeightDirective
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
  entryComponents: [
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
