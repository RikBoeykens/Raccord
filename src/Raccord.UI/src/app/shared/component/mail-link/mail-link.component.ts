import { Input, Component } from '@angular/core';

@Component({
  selector: 'mail-link',
  templateUrl: 'mail-link.component.html'
})
export class MailLinkComponent {
  @Input() public email: string;
}
