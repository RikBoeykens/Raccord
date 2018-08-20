import { UserProject } from '../..';
import { Input, Component } from '@angular/core';

@Component({
  selector: 'project-card',
  templateUrl: 'project-card.component.html'
})
export class ProjectCardComponent {
  @Input() public project: UserProject;
}
