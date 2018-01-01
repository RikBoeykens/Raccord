import { Component, OnInit } from '@angular/core';
import { Router, ActivatedRoute } from '@angular/router';
import { AdminUserHttpService } from '../../service/admin-user-http.service';
import { UserSummary } from '../../model/user-summary.model';
import { LoadingService } from '../../../../loading/service/loading.service';
import { DialogService } from '../../../../shared/service/dialog.service';
import { Image } from '../../children/images/model/image.model';

@Component({
    templateUrl: 'admin-users-list.component.html',
})
export class AdminUsersListComponent implements OnInit {

    users: UserSummary[] = [];

    constructor(
        private _adminUserHttpService: AdminUserHttpService,
        private _loadingService: LoadingService,
        private _dialogService: DialogService,
        private _route: ActivatedRoute,
        private _router: Router
    ) {
    }

    ngOnInit() {
        this._route.data.subscribe((data: { users: UserSummary[] }) => {
            this.users = data.users;
        });
    }

    getProjects(){
        
        let loadingId = this._loadingService.startLoading();

        this._adminUserHttpService.getAll().then(data => {
            this.users = data;
            this._loadingService.endLoading(loadingId);
        });
    }

    remove(user: UserSummary){

        if(this._dialogService.confirm(`Are you sure you want to remove ${user.email}`)){

            let loadingId = this._loadingService.startLoading();

            this._adminUserHttpService.delete(user.id).then(data=>{
                if(typeof(data)== 'string'){
                    this._dialogService.error(data);
                }else{
                    this._dialogService.success('The user was successfully removed');
                    this.getProjects();
                }
            }).catch()
            .then(()=> this._loadingService.endLoading(loadingId));
        }

    }

    public getFullName(user: UserSummary) {
        return `${user.firstName} ${user.lastName}`;
    }
}