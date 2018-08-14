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
  BreakdownItemHttpService,
  BreakdownHttpService,
  SelectedBreakdownResolve,
  ProjectCalendarHttpService,
  CharacterCallHttpService,
  CallsheetHttpService,
  CallsheetResolve,
  CallsheetSummaryResolve,
  ProjectCallsheetsResolve,
  CastDashboardHttpService,
  CastDashboardResolve,
  CastMemberHttpService,
  CastMemberResolve,
  CastMembersResolve,
  CrewUnitHttpService,
  CrewUnitSummaryResolve,
  CommentHttpService,
  LocationSetHttpService,
  LocationSetResolve,
  SceneLocationSetsResolve,
  LocationHttpService,
  LocationResolve,
  LocationsResolve,
  LocationDashboardHttpService,
  LocationDashboardResolve,
  ScheduleDayHttpService,
  ScheduleDaysResolve,
  SchedulesHttpService,
  SchedulesResolve,
  SchedulingDashboardHttpService,
  SchedulingDashboardResolve,
  CharacterHttpService,
  CharacterResolve,
  CharactersResolve,
  SceneHttpService,
  ScenesResolve,
  SceneResolve,
  ScriptLocationHttpService,
  ScriptLocationResolve,
  ScriptLocationsResolve,
  ScriptTextResolve,
  ScriptTextCallsheetResolve,
  ScriptTextUserResolve,
  ScriptTextHttpService,
  ScriptDashboardHttpService,
  ScriptDashboardResolve
} from './projects';
import {
  SearchEngineHttpService
} from './search';
import {
  AuthService,
  AuthGuard,
  LoginService,
  LoggedInGuard
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
  BreakdownItemHttpService,
  BreakdownHttpService,
  SelectedBreakdownResolve,
  ProjectCalendarHttpService,
  CharacterCallHttpService,
  CallsheetHttpService,
  CallsheetResolve,
  CallsheetSummaryResolve,
  ProjectCallsheetsResolve,
  CastDashboardHttpService,
  CastDashboardResolve,
  CastMemberHttpService,
  CastMemberResolve,
  CastMembersResolve,
  CrewUnitHttpService,
  CrewUnitSummaryResolve,
  CommentHttpService,
  LocationSetHttpService,
  LocationSetResolve,
  SceneLocationSetsResolve,
  LocationHttpService,
  LocationResolve,
  LocationsResolve,
  LocationDashboardHttpService,
  LocationDashboardResolve,
  ScheduleDayHttpService,
  ScheduleDaysResolve,
  SchedulesHttpService,
  SchedulesResolve,
  SchedulingDashboardHttpService,
  SchedulingDashboardResolve,
  CharacterHttpService,
  CharacterResolve,
  CharactersResolve,
  SceneHttpService,
  ScenesResolve,
  SceneResolve,
  ScriptLocationHttpService,
  ScriptLocationResolve,
  ScriptLocationsResolve,
  ScriptTextResolve,
  ScriptTextCallsheetResolve,
  ScriptTextUserResolve,
  ScriptTextHttpService,
  ScriptDashboardHttpService,
  ScriptDashboardResolve,
  SearchEngineHttpService,
  AuthService,
  AuthGuard,
  LoginService,
  LoggedInGuard,
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
