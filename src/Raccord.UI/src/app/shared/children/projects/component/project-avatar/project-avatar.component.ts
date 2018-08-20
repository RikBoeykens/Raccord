import { Component, Input } from '@angular/core';
import { ProjectSummary } from '../../model/project-summary.model';

@Component({
    selector: 'project-avatar',
    templateUrl: 'project-avatar.component.html'
})
export class ProjectAvatarComponent {

    @Input() public project: ProjectSummary;
    @Input() public cardImage;
    @Input() public listAvatar;
    @Input() public cardAvatar;
    @Input() public headerAvatar;
}
