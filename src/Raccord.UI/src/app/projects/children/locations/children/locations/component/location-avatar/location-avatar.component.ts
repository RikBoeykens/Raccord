import { Component, Input } from '@angular/core';
import { LocationSummary } from '../../model/location-summary.model';

@Component({
    selector: 'location-avatar',
    templateUrl: 'location-avatar.component.html'
})
export class LocationAvatarComponent {

    @Input() public location: LocationSummary;
    @Input() public cardImage;
    @Input() public listAvatar;
    @Input() public cardAvatar;
    @Input() public headerAvatar;
}
