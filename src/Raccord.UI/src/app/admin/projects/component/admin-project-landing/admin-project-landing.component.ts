import { Component } from '@angular/core';
import { Router, ActivatedRoute } from '@angular/router';
import { AdminProjectHttpService } from '../../service/admin-project-http.service';
import { FullProject } from '../../../../projects';

@Component({
    templateUrl: 'admin-project-landing.component.html',
})
export class AdminProjectLandingComponent {

    project: FullProject;

    constructor(
        private _projectHttpService: AdminProjectHttpService,
        private route: ActivatedRoute,
        private router: Router
    ){
    }

    ngOnInit() {
        this.route.data.subscribe((data: { project: FullProject }) => {
            this.project = data.project;
        });
    }
}