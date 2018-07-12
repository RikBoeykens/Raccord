import { Input, Component } from '@angular/core';
import { Image } from '../../children/images/model/image.model';

@Component({
  selector: 'generic-card',
  templateUrl: 'generic-card.component.html'
})
export class GenericCardComponent {
  @Input() public image: Image;
  @Input() public title: string;
}
