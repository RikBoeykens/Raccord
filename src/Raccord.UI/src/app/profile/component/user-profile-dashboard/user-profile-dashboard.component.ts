import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { MatDialog } from '@angular/material';
import {
  UserProfile,
  UserProfileHttpService,
  UserProfileSummary
} from '../../../shared/children/users';
import { LoadingWrapperService, AddImageDialogComponent, DialogService } from '../../../shared';
import {
  EditUserProfileDialogComponent
} from '../edit-user-profile-dialog/edit-user-profile-dialog.component';
import { AccountHelpers } from '../../../shared/children/account';

@Component({
  templateUrl: 'user-profile-dashboard.component.html',
})
export class UserProfileDashboardComponent implements OnInit {
  public userProfile: UserProfile;

  constructor(
    private _route: ActivatedRoute,
    private _userProfileHttpService: UserProfileHttpService,
    private _loadingWrapperService: LoadingWrapperService,
    private _dialogService: DialogService,
    private _dialog: MatDialog
  ) {
  }

  public ngOnInit() {
    this._route.data.subscribe((data: {
      userProfile: UserProfile
    }) => {
      this.userProfile = data.userProfile;
    });
  }

  public getFullName() {
    return `${this.userProfile.firstName} ${this.userProfile.lastName}`;
  }

  public showEditUserProfile() {
    const editProfileDialog = this._dialog.open(EditUserProfileDialogComponent, {data:
    {
        userProfile: new UserProfile(this.userProfile)
    }});
    editProfileDialog.afterClosed().subscribe((returnedInfo: {userProfile: UserProfile}) => {
      if (returnedInfo) {
          this.postUserProfile(returnedInfo.userProfile);
      }
    });
  }

  public showEditProfileImage() {
    const editImageDialog = this._dialog.open(AddImageDialogComponent);
    editImageDialog.afterClosed().subscribe((returnedInfo: {files: File[]}) => {
      if (returnedInfo) {
          this.postImage(returnedInfo.files);
      }
    });
  }

  public showConfirmRemoveImage() {
    this._dialogService.confirm(
      `Are you sure you want to remove the profile image?`,
      () => this.removeProfileImage()
    );
  }

  private postUserProfile(userProfile: UserProfile) {
    this._loadingWrapperService.Load(
      this._userProfileHttpService.post(userProfile),
      () => {
        this.userProfile = userProfile;
        this.updateUser();
      }
    );
  }

  private postImage(files: File[]) {
    this._loadingWrapperService.Load(
      this._userProfileHttpService.uploadImage(files),
      () => {
        this.userProfile.hasImage = true;
        this.updateUser();
      }
    );
  }

  private removeProfileImage() {
    this._loadingWrapperService.Load(
      this._userProfileHttpService.removeImage(),
      () => {
        this.userProfile.hasImage = false;
        this.updateUser();
      }
    );
  }

  private getUserProfile() {
    this._loadingWrapperService.Load(
      this._userProfileHttpService.get(),
      (userProfile: UserProfile) => this.userProfile = userProfile
    );
  }

  private updateUser() {
    AccountHelpers.setUser(new UserProfileSummary({
      id: this.userProfile.id,
      firstName: this.userProfile.firstName,
      lastName: this.userProfile.lastName,
      hasImage: this.userProfile.hasImage
    }));
  }
}
