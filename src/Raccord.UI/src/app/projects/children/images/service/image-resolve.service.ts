import { Injectable }             from '@angular/core';
import { Router, Resolve, ActivatedRouteSnapshot } from '@angular/router';
import { ImageHttpService } from './image-http.service';
import { FullImage } from '../model/full-image.model';
@Injectable()
export class ImageResolve implements Resolve<FullImage> {

  constructor(
      private _imageHttpService: ImageHttpService, 
      private router: Router
  ) {}

  resolve(route: ActivatedRouteSnapshot) {
    let imageID = route.params['imageId'];

    return this._imageHttpService.get(imageID).then(image => {
        if (image) {
            return image;
        } else { // id not found
            let projectId = route.params['projectId'];
            this.router.navigate(['/projects', projectId]);
            return false;
        }
    });
  }
}