import { Component, Input } from '@angular/core';
import { Image } from '../../model/image.model';
import { ImageUrlHelpers } from '../../helpers/image-url.helpers';

@Component({
    selector: 'show-image',
    templateUrl: 'show-image.component.html'
})
export class ShowImageComponent{

    @Input() image: Image;

    constructor(
    ){
    }

    getImageUrl(image: Image): string{
        return ImageUrlHelpers.getUrl(image);
    }
}