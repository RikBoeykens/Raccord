import { Component } from '@angular/core';
import { Router } from '@angular/router';
import { AdminUserHttpService } from '../../service/admin-user-http.service';
import { CreateUser } from '../../model/create-user.model';
import { LoadingService } from '../../../../loading/service/loading.service';
import { CanComponentDeactivate } from '../../../../shared/interface/can-component-deactivate.interface';
import { DialogService } from '../../../../shared/service/dialog.service';

@Component({
    templateUrl: 'admin-add-user.component.html'
})
export class AdminAddUserComponent implements CanComponentDeactivate {

    viewUser: CreateUser;
    user: CreateUser;

    constructor(
        private _userHttpService: AdminUserHttpService,
        private _loadingService: LoadingService,
        private _dialogService: DialogService,
        private _router: Router
    ){
        this.viewUser = new CreateUser();
    }

    addUser() {

        let loadingId = this._loadingService.startLoading();

        this.user = this.viewUser;

        this._userHttpService.add(this.user).then(data=>{
            this._router.navigate(['/admin/users', data]);
        }).catch()
        .then(()=>
            this._loadingService.endLoading(loadingId)
        );
    }

    canDeactivate(){
        if(!this.viewUser.email.length && !this.viewUser.password.length)
            return true;

        return this._dialogService.confirm('All data will be lost by navigating away');
    }
}