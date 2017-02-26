import { Injectable }             from '@angular/core';
import { Router, Resolve, ActivatedRouteSnapshot } from '@angular/router';
import { ImageHttpService } from './image-http.service';
import { ImageSummary } from '../model/image-summary.model';
@Injectable()
export class ImagesResolve implements Resolve<ImageSummary[]> {

  constructor(
    private _imageHttpService: ImageHttpService, 
    private router: Router
  ) {}

    resolve(route: ActivatedRouteSnapshot) {
        let projectId = route.params['projectId'];
        return this._imageHttpService.getAll(projectId).then(data => {
            return data;
        });
    }
}