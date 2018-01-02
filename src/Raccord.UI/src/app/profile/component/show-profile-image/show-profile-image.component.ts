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
    @Input() userId: string;
    @Input() fullName: string;
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
        let id = this.noUserDefined() ? this.userId : this.user.id;
        this._userProfileHttpService.getBase64(id).then(data => {
            this.loadingImage = false;
            if (data.hasContent){
                this.base64Image = data;
            }
        });
    }

    getImageUrl(){
        return this._sanitizer.bypassSecurityTrustUrl(ImageHelpers.getBase64Url(this.base64Image));
    }

    getTitle(): string{
        if (!this.noUserDefined()) {
            return `${this.user.firstName} ${this.user.lastName}`;
        }
        return this.fullName;
    }

    private noUserDefined(): boolean {
        return this.user === null || typeof this.user === 'undefined';
    }
}