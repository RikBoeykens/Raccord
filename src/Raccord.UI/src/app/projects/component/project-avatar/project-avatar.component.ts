import { Component, Input } from '@angular/core';
import { ProjectSummary } from '../../model/project-summary.model';

@Component({
    selector: 'project-avatar',
    templateUrl: 'project-avatar.component.html'
})
export class ProjectAvatarComponent{

    @Input() project: ProjectSummary;
    @Input() cardImage;
    @Input() listAvatar;
    @Input() cardAvatar;
}