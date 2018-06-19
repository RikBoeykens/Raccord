import {
  LoadingService
} from './loading';
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
  LoadingService,
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
