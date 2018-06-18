import {
  LoadingService
} from './loading';
import {
  CalendarHttpService
} from './calendar';
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
  AuthService,
  AuthGuard,
  LoginService,
  AccountHttpService,
  ImageHttpService,
  ProjectHttpService,
  ShortPagedProjectsResolve,
  PagedProjectsResolve,
  UserProfileHttpService,
  LoadingWrapperService,
  DialogService
];
