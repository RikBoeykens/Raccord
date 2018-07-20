import { Input, Component } from '@angular/core';

@Component({
  selector: 'phone-link',
  templateUrl: 'phone-link.component.html'
})
export class PhoneLinkComponent {
  @Input() public telephone: string;
}
