import { Injectable } from '@angular/core';
import { HttpInterceptor, HttpHandler, HttpRequest, HttpEvent, HttpResponse }
  from '@angular/common/http';

import { Observable } from 'rxjs/Observable';
import 'rxjs/add/operator/do';
import { AuthService } from '../../security';
import { DialogService } from '../service/dialog.service';
import { LoadingService } from '../../loading/service/loading.service';
import { JSONP_ERR_WRONG_RESPONSE_TYPE } from '@angular/common/http/src/jsonp';
import { JsonResponse } from '../model/json-response.model';

@Injectable()
export class HttpReponseInterceptor implements HttpInterceptor {
  constructor(
    private _authService: AuthService,
    private _dialogService: DialogService,
    private _loadingService: LoadingService
  ) {}

  public intercept(
    req: HttpRequest<any>,
    next: HttpHandler
  ): Observable<HttpEvent<any>> {
    return next.handle(req).do((evt) => {
      if (evt instanceof HttpResponse) {
        if (evt.status === 401) {
          this._authService.logout();
          this._loadingService.endAllLoading();
          this._dialogService.error('Please try logging in again');
        } else if (evt.status >= 400) {
          evt = evt.clone({body: new JsonResponse({
            ok: false,
            message: 'Something went wrong while accessing the back end.',
            data: null
          })});
        }
      }
    });
  }
}
