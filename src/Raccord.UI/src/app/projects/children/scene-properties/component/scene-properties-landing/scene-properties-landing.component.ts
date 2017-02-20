import { Component } from '@angular/core';
import { Router, ActivatedRoute } from '@angular/router';
import { ProjectHttpService } from '../../service/project-http.service';
import { ProjectSummary } from '../../../../model/project-summary.model';

@Component({
    templateUrl: 'scene-properties-landing.component.html',
})
export class ScenePropertiesLandingComponent {

    project: ProjectSummary;

    constructor(
        private route: ActivatedRoute,
        private router: Router
    ){
    }

    ngOnInit() {
        this.route.data.subscribe((data: { project: ProjectSummary }) => {
            this.project = data.project;
        });
    }
}