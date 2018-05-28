import { Component, Input, Output, EventEmitter, OnChanges, OnInit } from '@angular/core';
import { Comment } from '../../model/comment.model';
import { CommentHttpService } from '../../service/comment-http.service';
import { LoadingService } from '../../../../../loading/service/loading.service';
import { DialogService } from '../../../../../shared/service/dialog.service';
import { AccountHelpers } from '../../../../../account/helpers/account.helper';
import { LoadingWrapperService } from '../../../../../shared/service/loading-wrapper.service';

@Component({
    selector: 'comment-container',
    templateUrl: 'comment-container.component.html'
})
export class CommentContainerComponent implements OnInit{

    @Input() comments: Comment[];
    @Input() projectId: number;
    @Input() parentProjectId?: number;

    constructor(
      private _commentHttpService: CommentHttpService,
      private _loadingWrapperService: LoadingWrapperService,
      private _loadingService: LoadingService,
      private _dialogService: DialogService
    ){
    }

    ngOnInit() {
        this.getComments();
    }

    getComments() {
        this._loadingWrapperService.Load(
            this._commentHttpService.getAll(this.projectId, this.parentProjectId, null),
            (data) => this.comments = data
        );
    }

    onCommentSubmit(id: number) {
        this.getComments();
    }

    onRemovedComment() {
        this.getComments();
    }
}