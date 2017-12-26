import { Image } from '../model/image.model';
import { AppSettings } from '../../../../app.settings';

export class ImageExtensionHelpers {

    public static getExtension(image: Image) {
        return image.fileName.split('.').pop();
    }
}