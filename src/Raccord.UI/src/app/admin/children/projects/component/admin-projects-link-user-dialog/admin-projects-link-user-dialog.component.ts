import { Component, Inject } from '@angular/core';
import { MatDialogRef, MAT_DIALOG_DATA } from '@angular/material';
import { ProjectRole, User } from '../../../../../shared/children/users';
import { AdminSearchEngineService } from '../../../search/service/admin-search-engine.service';
import { LoadingWrapperService } from '../../../../../shared/service/loading-wrapper.service';
import {
  SearchRequest,
  SearchTypeResult,
  SearchResult
} from '../../../../../shared/children/search';
import { EntityType } from '../../../../../shared';

@Component({
  templateUrl: 'admin-projects-link-user-dialog.component.html',
})

export class AdminProjectsLinkUserDialogComponent {
  public selectedUser: SearchResult = new SearchResult();
  public searchText: string;
  public chosenRoleId: number;
  public availableRoles: ProjectRole[];
  public filteredUsers: SearchResult[] = [];

  constructor(
    private _adminSearchEngineService: AdminSearchEngineService,
    private _loadingWrapperService: LoadingWrapperService,
    private _dialogRef: MatDialogRef<AdminProjectsLinkUserDialogComponent>,
    @Inject(MAT_DIALOG_DATA) private data: {
      projectRoles: ProjectRole[]
    }
  ) {
    this.availableRoles = data.projectRoles;
  }

  public searchUsers() {
    if (this.searchText && this.searchText !== '') {
      this._loadingWrapperService.Load(
        this._adminSearchEngineService.search(new SearchRequest({
          searchText: this.searchText,
          projectId: 0,
          includeTypes: [EntityType.user],
          excludeTypes: [],
          excludeTypeIDs: []
        })),
        (data: SearchTypeResult[]) => {
          if (data && data.length && data[0].results) {
            this.filteredUsers = data[0].results;
          }
        }
      );
    } else {
      this.resetResults();
    }
  }

  public submit() {
    this._dialogRef.close({userId: this.selectedUser.id, roleId: this.chosenRoleId});
  }

  public onSelectionChanged(event$) {
    this.selectedUser = event$.option.value;
  }

  public clearSearch(value) {
    this.searchText = '';
    return '';
  }

  public removeSelectedUser() {
    this.selectedUser = new SearchResult();
  }

  private resetResults() {
    this.filteredUsers = [];
  }
}
