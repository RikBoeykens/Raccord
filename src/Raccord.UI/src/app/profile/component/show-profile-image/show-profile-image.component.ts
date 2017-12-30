import { Component, Input } from '@angular/core';
import { OnInit } from '@angular/core/src/metadata/lifecycle_hooks';
import { DomSanitizer } from '@angular/platform-browser';
import { UserProfileHttpService } from '../../service/user-profile-http.service';
import { ImageHelpers } from '../../../shared/helpers/image.helpers';
import { Base64Image } from '../../../shared/model/base-64-image.model';
import { UserProfileSummary } from '../../model/user-profile-summary.model';

@Component({
    selector: 'show-profile-image',
    templateUrl: 'show-profile-image.component.html'
})
export class ShowProfileImageComponent implements OnInit{

    @Input() user: UserProfileSummary;
    @Input() cardImage;
    @Input() listAvatar;

    base64Image: Base64Image = new Base64Image();
    loadingImage: boolean = true;

    constructor(
      private _userProfileHttpService: UserProfileHttpService,
      private _sanitizer: DomSanitizer
    ){
    }

    ngOnInit(){
      this._userProfileHttpService.getBase64(this.user.id).then(data => {
        this.loadingImage = false;
        if (data.hasContent){
            this.base64Image = data;
        }
      });
    }

    getImageUrl(){
        return this._sanitizer.bypassSecurityTrustUrl(ImageHelpers.getBase64Url(this.base64Image));
    }
}