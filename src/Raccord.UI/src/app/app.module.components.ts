import { AppComponent } from './app.component';
import {
  AdminChooseCastMemberDialogComponent,
  AdminChooseCharactersDialogComponent,
  AdminAddCrewUnitMemberCrewMemberDialogComponent,
  AdminChooseCrewUnitDialogComponent,
  AdminEditProjectRoleDialogComponent,
  AdminProjectUserInvitationCastMemberComponent,
  AdminProjectUserInvitationCrewComponent,
  AdminProjectUserInvitationDashboardComponent,
  AdminProjectUserCastMemberComponent,
  AdminProjectUserCrewComponent,
  AdminProjectUserDashboardComponent,
  AdminProjectProjectInvitationsTableComponent,
  AdminProjectProjectUserInvitationsComponent,
  AdminProjectsAddUserInvitationDialogComponent,
  AdminProjectsLinkUserInvitationDialogComponent,
  AdminProjectProjectUsersComponent,
  AdminProjectProjectUsersTableComponent,
  AdminProjectsAddUserDialogComponent,
  AdminProjectsLinkUserDialogComponent,
  AdminAddProjectAndRoleDialogComponent,
  AdminChooseProjectAndRoleDialogComponent,
  AdminEditProjectDialogComponent,
  AdminProjectDashboardComponent,
  AdminProjectsListComponent,
  AdminProjectsTableComponent,
  AdminUserInvitationProjectUserInvitationsComponent,
  AdminUserInvitationProjectUserInvitationsTableComponent,
  AdminUserInvitationCardComponent,
  AdminUserInvitationDashboardComponent,
  AdminUserInvitationsListComponent,
  AdminUserInvitationsTableComponent,
  AdminUserProjectUsersComponent,
  AdminUserProjectUsersTableComponent,
  AdminAddUserDialogComponent,
  AdminUserCardComponent,
  AdminUserDashboardComponent,
  AdminUsersListComponent,
  AdminUsersTableComponent,
  AdminLandingComponent,
  AdminSearchEntityComponent,
  AdminAddUserInvitationDialogComponent
} from './admin';
import {
  CalendarComponent,
  CalendarHeaderComponent
} from './calendar';
import {
  DashboardComponent,
  DashboardCalendarComponent
} from './dashboard';
import {
  CreateUserFromInvitationComponent
} from './invitations';
import { LoadingComponent } from './loading';
import {
  RaccordToolbarComponent,
  RaccordSidenavComponent
} from './navigation';
import { NoContentComponent } from './no-content';
import {
  EditUserProfileDialogComponent,
  UserProfileDashboardComponent
} from './profile';
import {
  BreakdownItemAvatarComponent,
  BreakdownItemCardComponent,
  BreakdownItemLandingComponent,
  SearchBreakdownItemCollectionComponent,
  SearchBreakdownItemComponent,
  BreakdownTypeAvatarComponent,
  BreakdownTypeCardComponent,
  BreakdownTypeLandingComponent,
  BreakdownAvatarComponent,
  BreakdownCardComponent,
  BreakdownLandingComponent,
  BreakdownsListComponent,
  ProjectCalendarComponent,
  CallsheetBreakdownsTableComponent,
  CallsheetCharactersTableComponent,
  CallsheetLocationCardComponent,
  CallsheetLocationsMapComponent,
  CallsheetScenesTableComponent,
  CallsheetComponent,
  CallsheetAvatarComponent,
  CallsheetCardComponent,
  CallsheetCrewUnitCardComponent,
  CallsheetSidesComponent,
  CallsheetsListComponent,
  CastMemberLandingComponent,
  CastMembersListComponent,
  CastDashboardComponent,
  CommentContainerComponent,
  EditCommentComponent,
  ShowCommentComponent,
  CrewMembersTableComponent,
  CrewUnitAvatarComponent,
  CrewUnitCardComponent,
  CrewUnitDashboardComponent,
  UnitListLandingComponent,
  CrewDashboardComponent,
  LocationSetLandingComponent,
  LocationSetLandingMapComponent,
  LocationAvatarComponent,
  LocationCardComponent,
  LocationLandingComponent,
  LocationLocationSetsMapComponent,
  LocationLocationSetsTableComponent,
  LocationsListComponent,
  LocationsListMapComponent,
  LocationDashboardComponent,
  ScheduleScenesTableComponent,
  ScheduleCardComponent,
  ScheduleCrewUnitCardComponent,
  ScheduleLandingComponent,
  SchedulesListComponent,
  ShootingDayScenesTableComponent,
  ShootingDayAvatarComponent,
  ShootingDayCardComponent,
  ShootingDayCrewUnitCardComponent,
  ShootingDayInfoComponent,
  ShootingDayInfoTableComponent,
  ShootingDayInfoScenesComponent,
  ShootingDayInfoScenesTableComponent,
  ShootingDayLandingComponent,
  ShootingDaysListComponent,
  SchedulingDashboardComponent,
  CharacterCastMemberComponent,
  CharacterLandingComponent,
  CharactersListComponent,
  CharactersTableComponent,
  SceneBreakdownTableComponent,
  SceneCharactersTableComponent,
  FilterScenesComponent,
  SceneLandingComponent,
  ScenesListComponent,
  ScenesTableComponent,
  ScriptLocationLocationSetsComponent,
  ScriptLocationLocationSetsMapComponent,
  ScriptLocationLocationSetsTableComponent,
  ScriptLocationLandingComponent,
  ScriptLocationsListComponent,
  SceneActionComponent,
  SceneDialogueComponent,
  SceneHeaderComponent,
  ScriptTextComponent,
  ScriptTextLandingComponent,
  ScriptTextUserComponent,
  ScriptDashboardComponent,
  SlateAvatarComponent,
  SlateCardComponent,
  SlateLandingComponent,
  SlatesListComponent,
  SlatesTableComponent,
  TakesTableComponent,
  ProjectsListComponent,
  ProjectDashboardComponent
} from './projects';
import {
  SearchDashboardComponent,
  SearchEntitiesCollectionComponent,
  SearchEntityComponent
} from './search';
import {
  LoginComponent
} from './security';
import {
  CastMemberAvatarComponent,
  CastMemberCardComponent
} from './shared/children/cast';
import {
  CharacterAvatarComponent,
  CharacterCardComponent,
  CharacterSummaryComponent
} from './shared/children/characters';
import {
  CrewMemberAvatarComponent
} from './shared/children/crew';
import {
  ShowImageComponent
} from './shared/children/images/component/show-image/show-image.component';
import {
  ProjectAvatarComponent,
  ProjectCardComponent
} from './shared/children/projects';
import {
  SceneAvatarComponent,
  SceneCardComponent,
  SceneSummaryComponent
} from './shared/children/scenes';
import {
  ScriptLocationAvatarComponent,
  ScriptLocationCardComponent
} from './shared/children/script-locations';
import {
  ShowProfileImageComponent,
  UserAvatarComponent
} from './shared/children/users';
import {
  WeatherInfoComponent
} from './shared/children/weather';
import {
  AddImageDialogComponent,
  BackLinkComponent,
  ConfirmDialogComponent,
  ErrorComponent,
  GenericAvatarComponent,
  GenericCardComponent,
  MailLinkComponent,
  MoreActionComponent,
  PhoneLinkComponent,
  PlaceholderImageComponent
} from './shared';

export const COMPONENTS = [
  AppComponent,
  AdminProjectUserInvitationCastMemberComponent,
  AdminProjectUserInvitationCrewComponent,
  AdminProjectUserInvitationDashboardComponent,
  AdminProjectUserCastMemberComponent,
  AdminProjectUserCrewComponent,
  AdminProjectUserDashboardComponent,
  AdminProjectProjectInvitationsTableComponent,
  AdminProjectProjectUserInvitationsComponent,
  AdminProjectProjectUsersComponent,
  AdminProjectProjectUsersTableComponent,
  AdminProjectDashboardComponent,
  AdminProjectsListComponent,
  AdminProjectsTableComponent,
  AdminUserInvitationProjectUserInvitationsComponent,
  AdminUserInvitationProjectUserInvitationsTableComponent,
  AdminAddUserInvitationDialogComponent,
  AdminUserInvitationCardComponent,
  AdminUserInvitationDashboardComponent,
  AdminUserInvitationsListComponent,
  AdminUserInvitationsTableComponent,
  AdminUserProjectUsersComponent,
  AdminUserProjectUsersTableComponent,
  AdminUserCardComponent,
  AdminUserDashboardComponent,
  AdminUsersListComponent,
  AdminUsersTableComponent,
  AdminLandingComponent,
  AdminSearchEntityComponent,
  CalendarComponent,
  CalendarHeaderComponent,
  DashboardComponent,
  DashboardCalendarComponent,
  CreateUserFromInvitationComponent,
  LoadingComponent,
  RaccordToolbarComponent,
  RaccordSidenavComponent,
  NoContentComponent,
  UserProfileDashboardComponent,
  BreakdownItemAvatarComponent,
  BreakdownItemCardComponent,
  BreakdownItemLandingComponent,
  SearchBreakdownItemCollectionComponent,
  SearchBreakdownItemComponent,
  BreakdownTypeAvatarComponent,
  BreakdownTypeCardComponent,
  BreakdownTypeLandingComponent,
  BreakdownAvatarComponent,
  BreakdownCardComponent,
  BreakdownLandingComponent,
  BreakdownsListComponent,
  ProjectCalendarComponent,
  CallsheetBreakdownsTableComponent,
  CallsheetCharactersTableComponent,
  CallsheetLocationCardComponent,
  CallsheetLocationsMapComponent,
  CallsheetScenesTableComponent,
  CallsheetComponent,
  CallsheetAvatarComponent,
  CallsheetCardComponent,
  CallsheetCrewUnitCardComponent,
  CallsheetSidesComponent,
  CallsheetsListComponent,
  CastMemberLandingComponent,
  CastMembersListComponent,
  CastDashboardComponent,
  CommentContainerComponent,
  EditCommentComponent,
  ShowCommentComponent,
  CrewMembersTableComponent,
  CrewUnitAvatarComponent,
  CrewUnitCardComponent,
  CrewUnitDashboardComponent,
  CrewDashboardComponent,
  UnitListLandingComponent,
  LocationSetLandingComponent,
  LocationSetLandingMapComponent,
  LocationAvatarComponent,
  LocationCardComponent,
  LocationLandingComponent,
  LocationLocationSetsMapComponent,
  LocationLocationSetsTableComponent,
  LocationsListComponent,
  LocationsListMapComponent,
  LocationDashboardComponent,
  ScheduleScenesTableComponent,
  ScheduleCardComponent,
  ScheduleCrewUnitCardComponent,
  ScheduleLandingComponent,
  SchedulesListComponent,
  ShootingDayScenesTableComponent,
  ShootingDayAvatarComponent,
  ShootingDayCardComponent,
  ShootingDayCrewUnitCardComponent,
  ShootingDayInfoComponent,
  ShootingDayInfoTableComponent,
  ShootingDayInfoScenesComponent,
  ShootingDayInfoScenesTableComponent,
  ShootingDayLandingComponent,
  ShootingDaysListComponent,
  SchedulingDashboardComponent,
  CharacterCastMemberComponent,
  CharacterLandingComponent,
  CharactersListComponent,
  CharactersTableComponent,
  SceneBreakdownTableComponent,
  SceneCharactersTableComponent,
  FilterScenesComponent,
  SceneLandingComponent,
  ScenesListComponent,
  ScenesTableComponent,
  ScriptLocationLocationSetsComponent,
  ScriptLocationLocationSetsMapComponent,
  ScriptLocationLocationSetsTableComponent,
  ScriptLocationLandingComponent,
  ScriptLocationsListComponent,
  SceneActionComponent,
  SceneDialogueComponent,
  SceneHeaderComponent,
  ScriptTextComponent,
  ScriptTextLandingComponent,
  ScriptTextUserComponent,
  ScriptDashboardComponent,
  SlateAvatarComponent,
  SlateCardComponent,
  SlateLandingComponent,
  SlatesListComponent,
  SlatesTableComponent,
  TakesTableComponent,
  ProjectsListComponent,
  ProjectDashboardComponent,
  SearchDashboardComponent,
  SearchEntitiesCollectionComponent,
  SearchEntityComponent,
  LoginComponent,
  CharacterCardComponent,
  CastMemberCardComponent,
  CastMemberAvatarComponent,
  CharacterAvatarComponent,
  CharacterSummaryComponent,
  CrewMemberAvatarComponent,
  ShowImageComponent,
  ProjectAvatarComponent,
  ProjectCardComponent,
  SceneAvatarComponent,
  SceneCardComponent,
  SceneSummaryComponent,
  ScriptLocationAvatarComponent,
  ScriptLocationCardComponent,
  ShowProfileImageComponent,
  UserAvatarComponent,
  WeatherInfoComponent,
  BackLinkComponent,
  ErrorComponent,
  GenericAvatarComponent,
  GenericCardComponent,
  MailLinkComponent,
  MoreActionComponent,
  PhoneLinkComponent,
  PlaceholderImageComponent
];

export const DIALOGS = [
  AdminChooseCastMemberDialogComponent,
  AdminChooseCharactersDialogComponent,
  AdminAddCrewUnitMemberCrewMemberDialogComponent,
  AdminChooseCrewUnitDialogComponent,
  AdminEditProjectRoleDialogComponent,
  AdminProjectsAddUserInvitationDialogComponent,
  AdminProjectsLinkUserInvitationDialogComponent,
  AdminProjectsAddUserDialogComponent,
  AdminProjectsLinkUserDialogComponent,
  AdminAddProjectAndRoleDialogComponent,
  AdminChooseProjectAndRoleDialogComponent,
  AdminEditProjectDialogComponent,
  AdminAddUserInvitationDialogComponent,
  AdminAddUserDialogComponent,
  EditUserProfileDialogComponent,
  AddImageDialogComponent,
  ConfirmDialogComponent
];
