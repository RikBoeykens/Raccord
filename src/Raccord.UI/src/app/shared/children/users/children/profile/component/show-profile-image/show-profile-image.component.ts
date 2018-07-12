import { Component, Input } from '@angular/core';
import { OnInit } from '@angular/core/src/metadata/lifecycle_hooks';
import { DomSanitizer } from '@angular/platform-browser';
import { Base64Image, ImageHelpers } from '../../../../../..';
import { UserProfileHttpService } from '../../service/user-profile-http.service';
import { UserProfileSummary } from '../../../..';

@Component({
    selector: 'show-profile-image',
    templateUrl: 'show-profile-image.component.html'
})
export class ShowProfileImageComponent implements OnInit {

    @Input() public user: UserProfileSummary;
    @Input() public userId: string;
    @Input() public fullName: string;
    @Input() public cardImage;
    @Input() public listAvatar;
    @Input() public cardAvatar;
    @Input() public headerAvatar;

    public base64Image: Base64Image = new Base64Image();
    public loadingImage: boolean = true;

    constructor(
      private _userProfileHttpService: UserProfileHttpService,
      private _sanitizer: DomSanitizer
    ) {
    }

    public ngOnInit() {
        const id = this.noUserDefined() ? this.userId : this.user.id;
        this._userProfileHttpService.getBase64(id).then((data: Base64Image) => {
            this.loadingImage = false;
            if (data.hasContent) {
                this.base64Image = data;
            }
        });
    }

    public getImageUrl() {
        return this._sanitizer.bypassSecurityTrustUrl(ImageHelpers.getBase64Url(this.base64Image));
    }

    public getTitle(): string {
        if (!this.noUserDefined()) {
            return `${this.user.firstName} ${this.user.lastName}`;
        }
        return this.fullName;
    }

    private noUserDefined(): boolean {
        return this.user === null || typeof this.user === 'undefined';
    }
}
