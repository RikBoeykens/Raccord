import { AppComponent } from './app.component';
import {
  AdminEditProjectDialogComponent,
  AdminProjectDashboardComponent,
  AdminProjectProjectInvitationsTableComponent,
  AdminProjectProjectUsersTableComponent,
  AdminProjectsAddUserDialogComponent,
  AdminProjectsListComponent,
  AdminProjectsTableComponent,
  AdminLandingComponent
} from './admin';
import {
  CalendarComponent,
  CalendarHeaderComponent
} from './calendar';
import {
  DashboardComponent,
  DashboardCalendarComponent
} from './dashboard';
import { LoadingComponent } from './loading';
import {
  RaccordToolbarComponent,
  RaccordSidenavComponent
} from './navigation';
import { NoContentComponent } from './no-content';
import {
  ProjectCalendarComponent,
  ProjectsListComponent,
  ProjectDashboardComponent
} from './projects';
import { LoginComponent } from './security';
import {
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
  ShowProfileImageComponent,
  UserAvatarComponent
} from './shared/children/users';
import {
  BackLinkComponent,
  ConfirmDialogComponent,
  ErrorComponent,
  MoreActionComponent,
  PlaceholderImageComponent
} from './shared';

export const COMPONENTS = [
  AppComponent,
  AdminProjectDashboardComponent,
  AdminProjectProjectInvitationsTableComponent,
  AdminProjectProjectUsersTableComponent,
  AdminProjectsListComponent,
  AdminProjectsTableComponent,
  AdminLandingComponent,
  CalendarComponent,
  CalendarHeaderComponent,
  DashboardComponent,
  DashboardCalendarComponent,
  LoadingComponent,
  RaccordToolbarComponent,
  RaccordSidenavComponent,
  NoContentComponent,
  ProjectCalendarComponent,
  ProjectsListComponent,
  ProjectDashboardComponent,
  LoginComponent,
  CharacterSummaryComponent,
  ShowImageComponent,
  ProjectAvatarComponent,
  ProjectCardComponent,
  ShowProfileImageComponent,
  UserAvatarComponent,
  BackLinkComponent,
  ErrorComponent,
  MoreActionComponent,
  PlaceholderImageComponent
];

export const DIALOGS = [
  AdminEditProjectDialogComponent,
  AdminProjectsAddUserDialogComponent,
  ConfirmDialogComponent
];
