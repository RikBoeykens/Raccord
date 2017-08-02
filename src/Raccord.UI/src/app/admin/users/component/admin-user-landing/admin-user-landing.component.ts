import { Component } from '@angular/core';
import { Router, ActivatedRoute } from '@angular/router';
import { AdminUserHttpService } from '../../service/admin-user-http.service';
import { FullUser } from '../../model/full-user.model';

@Component({
    templateUrl: 'admin-user-landing.component.html',
})
export class AdminUserLandingComponent {

    user: FullUser;

    constructor(
        private _projectHttpService: AdminUserHttpService,
        private route: ActivatedRoute,
        private router: Router
    ){
    }

    ngOnInit() {
        this.route.data.subscribe((data: { user: FullUser }) => {
            this.user = data.user;
        });
    }
}