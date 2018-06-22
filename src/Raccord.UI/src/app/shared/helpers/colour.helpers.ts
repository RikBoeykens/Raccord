export class ColourHelpers {

  public static getColour(text: string) {
    const colourValue = this.getColourValue(text);
    let colourIndex = (colourValue % this.availableColours.length) - 1;
    colourIndex = colourIndex < 0
                  ||
                  colourIndex > (this.availableColours.length - 1)
                  ? 0 : colourIndex;
    return this.availableColours[colourIndex];
  }

  public static getColourValue(text: string): number {
    let value = 0;
    for (const letter of text) {
      value += letter.charCodeAt(0);
    }
    return value !== 0 ? value : 1;
  }

  private static availableColours: string[] =
    [
      '#F44336', '#E91E63', '#9C27B0', '#673AB7', '#3F51B5', '#1E88E5', '#0288D1', '#0097A7',
      '#009688', '#43A047', '#558B2F', '#827717', '#F57F17', '#FF6F00', '#E65100', '#F4511E'
    ];
}
