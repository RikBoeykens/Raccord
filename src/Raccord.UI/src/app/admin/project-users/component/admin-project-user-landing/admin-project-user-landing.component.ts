import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { MdDialog } from '@angular/material';
import { FullProjectUser } from '../../model/full-project-user.model';
import { AdminProjectUserHttpService } from '../../service/admin-project-user-http.service';
import { AdminProjectUserCrewHttpService }
    from '../../service/admin-project-user-crew-http.service';
import { LoadingService } from '../../../../loading/service/loading.service';
import { DialogService } from '../../../../shared/service/dialog.service';
import { CrewMemberSummary }
    from '../../../../projects/children/crew/crew-members/model/crew-member-summary.model';
import { CrewMember }
    from '../../../../projects/children/crew/crew-members/model/crew-member.model';
import { CrewMemberHttpService }
    from '../../../../projects/children/crew/crew-members/service/crew-member-http.service';
import { AdminEditCrewMemberDialog }
    from '../admin-edit-crew-member-dialog/admin-edit-crew-member-dialog.component';
import { AdminAddCastDialogComponent }
    from '../admin-add-cast-dialog/admin-add-cast-dialog.component';
import { ProjectRole } from '../../../project-roles/model/project-role.model';
import { ProjectUser } from '../../model/project-user.model';
import { LoadingWrapperService } from '../../../../shared/service/loading-wrapper.service';
import { Character } from '../../../../projects/children/characters/model/character.model';
import { AdminProjectUserCastHttpService } from
    '../../service/admin-project-user-cast-http.service';
import { CharacterSummary } from
    '../../../../projects/children/characters/model/character-summary.model';

@Component({
  templateUrl: 'admin-project-user-landing.component.html',
})
export class AdminProjectUserLandingComponent implements OnInit  {

  public projectUser: FullProjectUser;
  public projectRoles: ProjectRole[];
  public availableCharacters: CharacterSummary[];

  constructor(
      private _projectUserHttpService: AdminProjectUserHttpService,
      private _projectUserCastHttpService: AdminProjectUserCastHttpService,
      private _projectUserCrewHttpService: AdminProjectUserCrewHttpService,
      private _crewMemberHttpService: CrewMemberHttpService,
      private _loadingWrapperService: LoadingWrapperService,
      private _loadingService: LoadingService,
      private _dialogService: DialogService,
      private route: ActivatedRoute,
      private _dialog: MdDialog
  ) {
  }

  public ngOnInit() {
      this.route.data.subscribe((data: {
          projectUser: FullProjectUser,
          projectRoles: ProjectRole[],
          characters: CharacterSummary[]
        }) => {
          this.projectUser = data.projectUser;
          this.projectRoles = data.projectRoles;
          this.availableCharacters = data.characters;
      });
  }

  public getProjectUser() {
    let loadingId = this._loadingService.startLoading();

    this._projectUserHttpService.get(this.projectUser.id).then((data) => {
        if (typeof(data) === 'string') {
            this._dialogService.error(data);
        }else {
            this.projectUser = data;
        }
    }).catch()
    .then(() =>
        this._loadingService.endLoading(loadingId)
    );
  }

  public updateProjectUser() {
    let loadingId = this._loadingService.startLoading();
    let toUpdate = new ProjectUser({
        id: this.projectUser.id,
        projectID: this.projectUser.project.id,
        userID: this.projectUser.user.id,
        roleID: this.projectUser.projectRole !== null ?
                    this.projectUser.projectRole.id !== 0 ?
                        this.projectUser.projectRole.id : null : null
    });

    this._projectUserHttpService.post(toUpdate).then((data) => {
        if (typeof(data) === 'string') {
            this._dialogService.error(data);
        }
    }).catch()
    .then(() =>
        this._loadingService.endLoading(loadingId)
    );
  }

  public removeCastLink(character: Character) {
    this._loadingWrapperService.Load(
        this._projectUserCastHttpService.removeLink(this.projectUser.id, character.id),
        () => this.getProjectUser()
    );
  }

  public removeCrewMemberLink(crewMember: CrewMember) {
    let loadingId = this._loadingService.startLoading();

    this._projectUserCrewHttpService.removeLink(this.projectUser.id, crewMember.id).then((data) => {
        if (typeof(data) === 'string') {
            this._dialogService.error(data);
        }else {
            this.getProjectUser();
            this._crewMemberHttpService.delete(crewMember.id).then((errorData) => {
                if (typeof(errorData) === 'string') {
                    this._dialogService.error(data);
                }
            });
        }
    }).catch()
    .then(() =>
        this._loadingService.endLoading(loadingId)
    );
  }

  public showAddCast() {
      let crewMemberDialog = this._dialog.open(AdminAddCastDialogComponent, {data:
          {
              characters: this.availableCharacters
                            .filter((character: CharacterSummary) => character.user.id)
          }});
      crewMemberDialog.afterClosed().subscribe((returnedCharacter: CharacterSummary) => {
          if (returnedCharacter) {
              this.addCastLink(returnedCharacter);
          }
      });
  }

    public editCrewMember(crewMember: CrewMember) {
        let crewMemberDialog = this._dialog.open(AdminEditCrewMemberDialog, {data:
            {
                crewMember
            }});
        crewMemberDialog.afterClosed().subscribe((returnedCrewMember: CrewMember) => {
            if (returnedCrewMember) {
                this.postCrewMember(returnedCrewMember);
            }
        });
    }

    private addCastLink(character: Character) {
        this._loadingWrapperService.Load(
            this._projectUserCastHttpService.addLink(this.projectUser.id, character.id),
            () => this.getProjectUser()
        );
    }

    private postCrewMember(crewMember: CrewMember) {
        let loadingId = this._loadingService.startLoading();
        this._crewMemberHttpService.post(crewMember).then((data) => {
            if (typeof(data) === 'string') {
                this._dialogService.error(data);
            }else {
                this.getProjectUser();
            }
        }).catch()
        .then(() =>
            this._loadingService.endLoading(loadingId)
        );
    }
}
