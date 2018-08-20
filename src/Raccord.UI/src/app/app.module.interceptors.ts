import { HTTP_INTERCEPTORS } from '@angular/common/http';
import { TokenInterceptor } from './security';

export const INTERCEPTORS = [
  {
    provide: HTTP_INTERCEPTORS,
    useClass: TokenInterceptor,
    multi: true
  }
];
