import {
  AdminProjectRoleHttpService,
  AdminProjectRolesResolve,
  AdminProjectUserInvitationHttpService,
  AdminProjectUserHttpService,
  AdminProjectHttpService,
  AdminProjectResolve,
  AdminProjectsResolve,
  AdminSearchEngineService,
  AdminUserInvitationHttpService,
  AdminUserHttpService,
  AdminDashboardHttpService,
  AdminDashboardResolve,
  AdminGuard
} from './admin';
import {
  LoadingService
} from './loading';
import {
  SidenavService
} from './navigation';
import {
  CalendarHttpService
} from './calendar';
import {
  ProjectCalendarHttpService
} from './projects';
import {
  AuthService,
  AuthGuard,
  LoginService
} from './security';
import {
  AccountHttpService
} from './shared/children/account';
import {
  ImageHttpService
} from './shared/children/images/service/image-http.service';
import {
  ShortPagedProjectsResolve,
  PagedProjectsResolve,
  CurrentProjectService,
  CurrentProjectResolve,
  ResetCurrentProjectResolve,
  ProjectHttpService
} from './shared/children/projects';
import {
  UserProfileHttpService
} from './shared/children/users';
import {
  LoadingWrapperService,
  DialogService
} from './shared';

export const SERVICES = [
  AdminProjectRoleHttpService,
  AdminProjectRolesResolve,
  AdminProjectUserInvitationHttpService,
  AdminProjectUserHttpService,
  AdminProjectHttpService,
  AdminProjectResolve,
  AdminProjectsResolve,
  AdminSearchEngineService,
  AdminUserInvitationHttpService,
  AdminUserHttpService,
  AdminDashboardHttpService,
  AdminDashboardResolve,
  AdminGuard,
  LoadingService,
  SidenavService,
  CalendarHttpService,
  ProjectCalendarHttpService,
  AuthService,
  AuthGuard,
  LoginService,
  AccountHttpService,
  ImageHttpService,
  CurrentProjectService,
  CurrentProjectResolve,
  ResetCurrentProjectResolve,
  ProjectHttpService,
  ShortPagedProjectsResolve,
  PagedProjectsResolve,
  UserProfileHttpService,
  LoadingWrapperService,
  DialogService
];
