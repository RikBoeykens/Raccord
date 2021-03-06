import { Base64Image } from '..';

export class ImageHelpers {

  public static getExtension(fileName: string) {
    return fileName.split('.').pop();
  }

  public static getBase64Url(image: Base64Image): string {
    return `data:image/${this.getExtension(image.fileName)};base64,${image.content}`;
  }
}
