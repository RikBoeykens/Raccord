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
  SearchBreakdownItemCollectionComponent,
  SearchBreakdownItemComponent,
  ProjectCalendarComponent,
  CallsheetBreakdownsTableComponent,
  CallsheetCharactersTableComponent,
  CallsheetLocationCardComponent,
  CallsheetLocationsMapComponent,
  CallsheetScenesTableComponent,
  CallsheetComponent,
  CallsheetSidesComponent,
  CommentContainerComponent,
  EditCommentComponent,
  ShowCommentComponent,
  SceneCharactersTableComponent,
  FilterScenesComponent,
  SceneLandingComponent,
  ScenesListComponent,
  ScenesTableComponent,
  SceneActionComponent,
  SceneDialogueComponent,
  SceneHeaderComponent,
  ScriptTextComponent,
  ScriptTextLandingComponent,
  ScriptTextUserComponent,
  ScriptDashboardComponent,
  ProjectsListComponent,
  ProjectDashboardComponent,
  BreakdownItemAvatarComponent,
  SceneBreakdownTableComponent
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
  CharacterAvatarComponent,
  CharacterCardComponent,
  CharacterSummaryComponent
} from './shared/children/characters';
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
  SearchBreakdownItemCollectionComponent,
  SearchBreakdownItemComponent,
  ProjectCalendarComponent,
  CallsheetBreakdownsTableComponent,
  CallsheetCharactersTableComponent,
  CallsheetLocationCardComponent,
  CallsheetLocationsMapComponent,
  CallsheetScenesTableComponent,
  CallsheetComponent,
  CallsheetSidesComponent,
  CommentContainerComponent,
  EditCommentComponent,
  ShowCommentComponent,
  SceneBreakdownTableComponent,
  SceneCharactersTableComponent,
  FilterScenesComponent,
  SceneLandingComponent,
  ScenesListComponent,
  ScenesTableComponent,
  SceneActionComponent,
  SceneDialogueComponent,
  SceneHeaderComponent,
  ScriptTextComponent,
  ScriptTextLandingComponent,
  ScriptTextUserComponent,
  ScriptDashboardComponent,
  ProjectsListComponent,
  ProjectDashboardComponent,
  SearchDashboardComponent,
  SearchEntitiesCollectionComponent,
  SearchEntityComponent,
  LoginComponent,
  CharacterCardComponent,
  CharacterAvatarComponent,
  CharacterSummaryComponent,
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
