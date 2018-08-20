import { Injectable } from '@angular/core';
import { Router, Resolve, ActivatedRouteSnapshot } from '@angular/router';
import { SlateHttpService } from './slate-http.service';
import { FullSlate } from '../model/full-slate.model';

@Injectable()
export class SlateResolve implements Resolve<FullSlate> {

  constructor(
      private slateHttpService: SlateHttpService
  ) {}

  public resolve(route: ActivatedRouteSnapshot) {
    const slateId = route.params['slateId'];

    return this.slateHttpService.get(slateId).then((data: FullSlate) => data);
  }
}
