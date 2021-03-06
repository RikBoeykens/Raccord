import { Component, OnInit, Input } from '@angular/core';
import { DomSanitizer } from '@angular/platform-browser';
import { Image } from '../..';
import { Base64Image, ImageHelpers } from '../../../..';
import { ImageHttpService } from '../../service/image-http.service';
import { ColourHelpers } from '../../../../helpers/colour.helpers';

@Component({
    selector: 'show-image',
    templateUrl: 'show-image.component.html'
})
export class ShowImageComponent implements OnInit {

    @Input() public image: Image;
    @Input() public cardImage;
    @Input() public listAvatar;
    @Input() public cardAvatar;
    @Input() public headerAvatar;

    public base64Image: Base64Image = new Base64Image();
    public loadingImage: boolean = true;

    constructor(
        private _imageHttpService: ImageHttpService,
        private _sanitizer: DomSanitizer
    ) {
    }

    public ngOnInit() {
        this._imageHttpService.getBase64(this.image.id).then((data) => {
            this.loadingImage = false;
            if (data.hasContent) {
                this.base64Image = data;
            }
        });
    }

    public getImageUrl() {
        return this._sanitizer.bypassSecurityTrustUrl(ImageHelpers.getBase64Url(this.base64Image));
    }

    public getBgColour() {
        return ColourHelpers.getColour(this.image.title);
    }
}
