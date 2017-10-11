import { Injectable }             from '@angular/core';
import { Router, Resolve, ActivatedRouteSnapshot } from '@angular/router';
import { ChartInfo } from '../model/chart-info.model';
import { ChartHttpService } from './chart-http.service';
@Injectable()
export class ProjectChartsResolve implements Resolve<ChartInfo[]> {

  constructor(
    private chartHttpService: ChartHttpService, 
    private router: Router
  ) {}

    resolve(route: ActivatedRouteSnapshot) {
        let projectId = route.params['projectId'];
        return this.chartHttpService.getForProject(projectId).then(data => {
            return data;
        });
    }
}