import { Component, Input, Output, EventEmitter, OnChanges, OnInit } from '@angular/core';
import { Comment } from '../../model/comment.model';
import { CommentHttpService } from '../../service/comment-http.service';
import { LoadingService } from '../../../../../loading/service/loading.service';
import { DialogService } from '../../../../../shared/service/dialog.service';
import { AccountHelpers } from '../../../../../account/helpers/account.helper';
import { LoadingWrapperService } from '../../../../../shared/service/loading-wrapper.service';
import { ParentCommentType } from '../../../../../shared/enums/parent-comment-type.enum';

@Component({
    selector: 'show-comment',
    templateUrl: 'show-comment.component.html'
})
export class ShowCommentComponent implements OnInit{

    @Output() public removedComment = new EventEmitter();
    @Input() public comment: Comment;
    @Input() public projectId: number;
    public childComments: Comment[] = [];
    public showAddComment: boolean = false;
    public showEditComment: boolean = false;

    constructor(
      private _commentHttpService: CommentHttpService,
      private _loadingWrapperService: LoadingWrapperService,
      private _loadingService: LoadingService,
      private _dialogService: DialogService
    ) {
    }

    public ngOnInit() {
        this.getChildComments();
    }

    public getComment() {
        this._loadingWrapperService.Load(
            this._commentHttpService.get(this.projectId, this.comment.id),
            (data) => this.comment = data
        );
    }

    public getChildComments() {
        this._loadingWrapperService.Load(
            this._commentHttpService.getAll(this.projectId, this.comment.id, ParentCommentType.comment),
            (data) => this.childComments = data
        );
    }

    public getFullName() {
        return `${this.comment.user.firstName} ${this.comment.user.lastName}`;
    }

    public toggleEditComment(value: boolean) {
        this.showEditComment = value;
    }

    public commentEdited(id: number) {
        this.getComment();
        this.toggleEditComment(false);
    }

    public toggleAddComment(value: boolean) {
        this.showAddComment = value;
    }

    public commentAdded(id: number) {
        this.toggleAddComment(false);
        this.getChildComments();
    }

    public canEdit(){
        return this.comment.user.id === AccountHelpers.getUserId();
    }

    public removeComment() {
        this._loadingWrapperService.Load(
            this._commentHttpService.delete(this.projectId, this.comment.id),
            () => this.removedComment.emit()
        );
    }

    public onRemovedChildComment() {
        this.getChildComments();
    }

    public getCommentType() {
        return ParentCommentType.comment;
    }
}
