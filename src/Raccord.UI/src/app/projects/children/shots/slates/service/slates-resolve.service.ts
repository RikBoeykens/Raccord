import { Injectable } from '@angular/core';
import { Resolve, ActivatedRouteSnapshot } from '@angular/router';
import { SlateHttpService } from './slate-http.service';
import { SlateSummary } from '../model/slate-summary.model';
@Injectable()
export class SlatesResolve implements Resolve<SlateSummary[]> {

  constructor(
    private slateHttpService: SlateHttpService
  ) {}

    public resolve(route: ActivatedRouteSnapshot) {
        const projectId = route.params['projectId'];
        return this.slateHttpService.getAll(projectId).then((data: SlateSummary[]) => data);
    }
}
