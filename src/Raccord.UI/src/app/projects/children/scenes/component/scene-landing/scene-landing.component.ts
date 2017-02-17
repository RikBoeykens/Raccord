import { Component } from '@angular/core';
import { Router, ActivatedRoute } from '@angular/router';
import { SceneHttpService } from '../../service/scene-http.service';
import { FullScene } from '../../model/full-scene.model';
import { ProjectSummary } from '../../../../model/project-summary.model';

@Component({
    templateUrl: 'scene-landing.component.html',
})
export class SceneLandingComponent {

    scene: FullScene;
    project: ProjectSummary;

    constructor(
        private _sceneHttpService: SceneHttpService,
        private _route: ActivatedRoute,
        private _router: Router
    ){
    }

    ngOnInit() {
        this._route.data.subscribe((data: { scene: FullScene, project: ProjectSummary }) => {
            this.scene = data.scene;
            this.project = data.project;
        });
    }
}