import { Injectable } from '@angular/core';
import { Resolve, ActivatedRouteSnapshot } from '@angular/router';
import { ChartInfo } from '..';
import { ChartHttpService } from './chart-http.service';
@Injectable()
export class ProjectChartsResolve implements Resolve<ChartInfo[]> {

  constructor(
    private chartHttpService: ChartHttpService
  ) {}

    public resolve(route: ActivatedRouteSnapshot) {
        const projectId = route.params['projectId'];
        return this.chartHttpService.getForProject(projectId).then((data: ChartInfo[]) => data);
    }
}
