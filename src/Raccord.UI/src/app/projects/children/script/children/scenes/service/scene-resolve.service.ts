import { Injectable } from '@angular/core';
import { Router, Resolve, ActivatedRouteSnapshot } from '@angular/router';
import { SceneHttpService } from './scene-http.service';
import { FullScene } from '../model/full-scene.model';
@Injectable()
export class SceneResolve implements Resolve<FullScene> {

    constructor(
        private _sceneHttpService: SceneHttpService
    ) {}

    public resolve(route: ActivatedRouteSnapshot) {
        const id = route.params['sceneId'];

        return this._sceneHttpService.get(id).then((data: FullScene) => data);
    }
}
