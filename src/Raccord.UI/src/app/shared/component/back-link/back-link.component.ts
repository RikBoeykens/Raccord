import { Component, Input } from '@angular/core';

@Component({
  selector: 'back-link',
  templateUrl: 'back-link.component.html'
})
export class BackLinkComponent {
  @Input() public override: string;
}
