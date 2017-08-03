import { Component } from '@angular/core';
import { Router, ActivatedRoute } from '@angular/router';
import { AdminProjectHttpService } from '../../service/admin-project-http.service';
import { FullProject } from '../../../../projects';
import { CrewUserUser } from "../../../crew/model/crew-user-user.model";
import { AdminCrewHttpService } from "../../../crew/service/admin-crew-http.service";

@Component({
    templateUrl: 'admin-project-landing.component.html',
})
export class AdminProjectLandingComponent {

    project: FullProject;
    crew: CrewUserUser[] = [];

    constructor(
        private _projectHttpService: AdminProjectHttpService,
        private _crewHttpService: AdminCrewHttpService,
        private route: ActivatedRoute,
        private router: Router
    ){
    }

    ngOnInit() {
        this.route.data.subscribe((data: { project: FullProject, crew: CrewUserUser[] }) => {
            this.project = data.project;
            this.crew = data.crew;
        });
    }
}