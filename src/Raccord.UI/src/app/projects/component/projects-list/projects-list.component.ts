import { Component, OnInit } from '@angular/core';
import { PagedData, PageRequest } from '../../../shared/children/paging';
import { UserProject } from '../../../shared/children/projects';
import { ProjectHttpService } from '../../../shared/children/projects/service/project-http.service';
import { ActivatedRoute } from '@angular/router';
import { LoadingWrapperService } from '../../../shared/service/loading-wrapper.service';
import { RouteSettings } from '../../../shared';

@Component({
  selector: 'projects-list',
  templateUrl: 'projects-list.component.html'
})
export class ProjectsListComponent implements OnInit {
  public pagedProjects: PagedData<UserProject>;

  constructor(
      private _route: ActivatedRoute,
      private _projectHttpService: ProjectHttpService,
      private _loadingWrapperService: LoadingWrapperService
  ) {}

  public ngOnInit() {
      this._route.data.subscribe((data: { projects: PagedData<UserProject>}) => {
          this.pagedProjects = data.projects;
      });
  }

  public getMoreProjects() {
    this._loadingWrapperService.Load(
      this._projectHttpService.getPaged(new PageRequest({
        page: this.pagedProjects.pageInfo.page + 1,
        pageSize: this.pagedProjects.pageInfo.pageSize,
        full: false
      })),
      (data: PagedData<UserProject>) => {
        this.pagedProjects.pageInfo = data.pageInfo;
        this.pagedProjects.data.push.apply(this.pagedProjects.data, data.data);
      }
    );
  }

  public getProjectLink(project: UserProject) {
    return `/${RouteSettings.PROJECTS}/${project.id}`;
  }
}
