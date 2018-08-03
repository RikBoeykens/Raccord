import { Injectable } from '@angular/core';
import { Router, Resolve, ActivatedRouteSnapshot } from '@angular/router';
import { BreakdownHttpService } from './breakdown-http.service';
import { SelectedBreakdown } from '../model/selected-breakdown.model';
@Injectable()
export class SelectedBreakdownResolve implements Resolve<SelectedBreakdown> {

  constructor(
      private breakdownHttpService: BreakdownHttpService
  ) {}

  public resolve(route: ActivatedRouteSnapshot) {
    const id = route.params['projectId'];

    return this.breakdownHttpService.getSelected(id).then((data: SelectedBreakdown) => data);
  }
}
