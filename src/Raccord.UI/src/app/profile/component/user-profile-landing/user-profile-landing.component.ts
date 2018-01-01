import { Component } from '@angular/core';
import { Router, ActivatedRoute } from '@angular/router';
import { UserProfile } from '../../model/user-profile.model';
import { UserProfileHttpService } from '../../service/user-profile-http.service';
import { MdDialog } from '@angular/material';
import { EditUserProfileDialog } from '../edit-user-profile-dialog/edit-user-profile-dialog.component';
import { LoadingService } from '../../../loading/service/loading.service';
import { DialogService } from '../../../shared/service/dialog.service';
import { AccountHelpers } from '../../../account/helpers/account.helper';

@Component({
    templateUrl: 'user-profile-landing.component.html',
})
export class UserProfileLandingComponent {

  userProfile: UserProfile;

  constructor(
      private _userProfileHttpService: UserProfileHttpService,
      private _loadingService: LoadingService,
      private _dialogService: DialogService,
      private route: ActivatedRoute,
      private router: Router,
      private _dialog: MdDialog
  ){
  }

  ngOnInit() {
      this.route.data.subscribe((data: { userProfile: UserProfile }) => {
          this.userProfile = data.userProfile;
      });
  }

  public updateProfile() {
    let editUserProfile = new UserProfile(this.userProfile);
    let userProfileDialog = this._dialog.open(EditUserProfileDialog, {data:
    {
      userProfile: editUserProfile
    }});
    userProfileDialog.afterClosed().subscribe((userProfile: UserProfile) => {
      if (userProfile) {
          this.postUserProfile(userProfile);
      }
    });
  }

  uploadImage(fileInput: any){
    let loadingId = this._loadingService.startLoading();

    let files = <Array<File>>fileInput.target.files;
    this.userProfile.hasImage = false;

    this._userProfileHttpService.uploadImage(files).then(data=>{
        if (typeof(data) === 'string') {
            this._dialogService.error(data);
        }else {
            this.userProfile.hasImage = true;
            fileInput.target.value = "";
        }
    }).catch()
    .then(()=>
        this._loadingService.endLoading(loadingId)
    );
  }

  removeImage() {
    let loadingId = this._loadingService.startLoading();
    this._userProfileHttpService.removeImage().then((data) => {
        if (typeof(data) === 'string') {
            this._dialogService.error(data);
        }else{
          this.userProfile.hasImage = false;
        }
    }).catch()
    .then(() =>
        this._loadingService.endLoading(loadingId)
    );
  }

  private postUserProfile(userProfile: UserProfile) {
      let loadingId = this._loadingService.startLoading();
      this._userProfileHttpService.post(userProfile).then((data) => {
          if (typeof(data) === 'string') {
              this._dialogService.error(data);
          }else{
            this.userProfile = data;
            AccountHelpers.setName(this.userProfile.firstName, this.userProfile.lastName);
          }
      }).catch()
      .then(() =>
          this._loadingService.endLoading(loadingId)
      );
  }
}