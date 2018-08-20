import { Component, Input } from '@angular/core';
import { CrewUnitSummary } from '../../../../../../../shared/children/crew';

@Component({
    selector: 'crew-unit-avatar',
    templateUrl: 'crew-unit-avatar.component.html'
})
export class CrewUnitAvatarComponent {

    @Input() public crewUnit: CrewUnitSummary;
    @Input() public cardImage;
    @Input() public listAvatar;
    @Input() public cardAvatar;
    @Input() public headerAvatar;
}
