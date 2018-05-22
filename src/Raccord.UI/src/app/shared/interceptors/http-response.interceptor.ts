import { Injectable } from '@angular/core';
import { HttpInterceptor, HttpHandler, HttpRequest, HttpEvent, HttpResponse }
  from '@angular/common/http';
  import { Router } from '@angular/router';
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
    private _loadingService: LoadingService,
    private _router: Router
  ) {}

  public intercept(
    req: HttpRequest<any>,
    next: HttpHandler
  ): Observable<HttpEvent<any>> {
    return next.handle(req).catch((err: any) => {
      this._loadingService.endAllLoading();
      if (err.status && err.status === 401) {
        this._authService.logout();
        this._dialogService.error('Please try logging in again');
        this._router.navigate(['login']);
      }else {
        this._router.navigate(['error']);
      }
      return Observable.throw(err);
    });
  }
}
