import {
  AdminCastMemberHttpService,
  AdminCrewDepartmentHttpService,
  AdminCrewUnitHttpService,
  AdminProjectRoleHttpService,
  AdminProjectRolesResolve,
  AdminProjectUserInvitationCastHttpService,
  AdminCrewUnitInvitationMemberCrewMembersHttpService,
  AdminCrewUnitInvitationMemberHttpService,
  AdminProjectUserInvitationHttpService,
  AdminProjectUserInvitationResolve,
  AdminProjectUserCastHttpService,
  AdminCrewUnitMemberCrewMembersHttpService,
  AdminCrewUnitMemberHttpService,
  AdminProjectUserHttpService,
  AdminProjectUserResolve,
  AdminProjectHttpService,
  AdminProjectResolve,
  AdminProjectsResolve,
  AdminSearchEngineService,
  AdminUserInvitationHttpService,
  AdminUserHttpService,
  AdminUserResolve,
  AdminUsersResolve,
  AdminDashboardHttpService,
  AdminDashboardResolve,
  AdminExampleHttpService,
  AdminGuard,
  AdminUserInvitationsResolve,
  AdminUserInvitationResolve
} from './admin';
import {
  InvitationHttpService,
  InvitationResolve
} from './invitations';
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
  ProjectCalendarHttpService,
  CharacterCallHttpService,
  CallsheetHttpService,
  CallsheetResolve
} from './projects';
import {
  SearchEngineHttpService
} from './search';
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
  UserProfileHttpService,
  UserProfileResolve
} from './shared/children/users';
import {
  LoadingWrapperService,
  DialogService
} from './shared';

export const SERVICES = [
  AdminCastMemberHttpService,
  AdminCrewDepartmentHttpService,
  AdminCrewUnitHttpService,
  AdminProjectRoleHttpService,
  AdminProjectRolesResolve,
  AdminProjectUserInvitationCastHttpService,
  AdminCrewUnitInvitationMemberCrewMembersHttpService,
  AdminCrewUnitInvitationMemberHttpService,
  AdminProjectUserInvitationHttpService,
  AdminProjectUserInvitationResolve,
  AdminProjectUserHttpService,
  AdminProjectUserCastHttpService,
  AdminCrewUnitMemberCrewMembersHttpService,
  AdminCrewUnitMemberHttpService,
  AdminProjectUserResolve,
  AdminProjectHttpService,
  AdminProjectResolve,
  AdminProjectsResolve,
  AdminSearchEngineService,
  AdminUserInvitationHttpService,
  AdminUserInvitationsResolve,
  AdminUserInvitationResolve,
  AdminUserHttpService,
  AdminUserResolve,
  AdminUsersResolve,
  AdminDashboardHttpService,
  AdminDashboardResolve,
  AdminExampleHttpService,
  AdminGuard,
  InvitationHttpService,
  InvitationResolve,
  LoadingService,
  SidenavService,
  CalendarHttpService,
  ProjectCalendarHttpService,
  CharacterCallHttpService,
  CallsheetHttpService,
  CallsheetResolve,
  SearchEngineHttpService,
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
  UserProfileResolve,
  LoadingWrapperService,
  DialogService
];
