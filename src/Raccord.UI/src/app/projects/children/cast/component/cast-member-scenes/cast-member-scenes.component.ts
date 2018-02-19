import { Component, Input } from '@angular/core';
import { SceneSummary } from '../../../scenes/model/scene-summary.model';

@Component({
    selector: 'cast-member-scenes',
    templateUrl: 'cast-member-scenes.component.html'
})
export class CastMemberScenesComponent {

    @Input() public projectId: number;
    @Input() public scenes: SceneSummary[];

}
