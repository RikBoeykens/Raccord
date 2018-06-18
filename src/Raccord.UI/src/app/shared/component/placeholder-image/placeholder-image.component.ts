import { Component, Input, OnInit, OnChanges } from '@angular/core';

@Component({
    selector: 'placeholder-image',
    templateUrl: 'placeholder-image.component.html'
})
export class PlaceholderImageComponent implements OnInit, OnChanges {
    @Input() public value: string;
    @Input() public cardImage;
    @Input() public listAvatar;
    @Input() public cardAvatar;
    public text: string;
    public bgColour: string;
    private availableColours: string[] =
      [
        '#F44336', '#E91E63', '#9C27B0', '#673AB7', '#3F51B5', '#1E88E5', '#0288D1', '#0097A7',
        '#009688', '#43A047', '#558B2F', '#827717', '#F57F17', '#FF6F00', '#E65100', '#F4511E'
      ];

    public ngOnInit() {
      this.updateValue();
    }

    public ngOnChanges() {
      this.updateValue();
    }

    private updateValue() {
      this.text = this.getPlaceholderText();
      this.setColours();
    }

    private getPlaceholderText(): string {
      if (!this.value) {
        return '';
      }
      const nameArray = this.value.split(' ');
      if (nameArray.length === 0) {
        return '';
      } else if (nameArray.length === 1) {
        return this.getInitial(nameArray[0]);
      } else {
        return `${this.getInitial(nameArray[0])}${this.getInitial(nameArray[1])}`;
      }
    }

    private getInitial(value: string): string {
      return value.substr(0, 1).toUpperCase();
    }

    private setColours() {
      const colourValue = this.getColourValue();
      let colourIndex = (colourValue % this.availableColours.length) - 1;
      colourIndex = colourIndex < 0
                    ||
                    colourIndex > (this.availableColours.length - 1)
                    ? 0 : colourIndex;
      this.bgColour = this.availableColours[colourIndex];
    }

    private getColourValue(): number {
      let value = 0;
      for (const letter of this.text) {
        value += letter.charCodeAt(0);
      }
      return value !== 0 ? value : 1;
    }
}
