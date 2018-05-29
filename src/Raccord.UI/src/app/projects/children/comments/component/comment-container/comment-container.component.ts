import { Component, Input, Output, EventEmitter, OnChanges, OnInit } from '@angular/core';
import { Comment } from '../../model/comment.model';
import { CommentHttpService } from '../../service/comment-http.service';
import { LoadingService } from '../../../../../loading/service/loading.service';
import { DialogService } from '../../../../../shared/service/dialog.service';
import { AccountHelpers } from '../../../../../account/helpers/account.helper';
import { LoadingWrapperService } from '../../../../../shared/service/loading-wrapper.service';
import { ParentCommentType } from '../../../../../shared/enums/parent-comment-type.enum';

@Component({
    selector: 'comment-container',
    templateUrl: 'comment-container.component.html'
})
export class CommentContainerComponent implements OnInit{

    @Input() public comments: Comment[];
    @Input() public projectId: number;
    @Input() public parentId: number;
    @Input() public parentType: ParentCommentType;

    constructor(
      private _commentHttpService: CommentHttpService,
      private _loadingWrapperService: LoadingWrapperService,
      private _loadingService: LoadingService,
      private _dialogService: DialogService
    ) {
    }

    public ngOnInit() {
        this.getComments();
    }

    public getComments() {
        this._loadingWrapperService.Load(
            this._commentHttpService.getAll(this.projectId, this.parentId, this.parentType),
            (data) => this.comments = data
        );
    }

    public onCommentSubmit(id: number) {
        this.getComments();
    }

    public onRemovedComment() {
        this.getComments();
    }
}