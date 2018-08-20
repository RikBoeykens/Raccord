import { Component, Input, Output, EventEmitter, OnInit } from '@angular/core';
import { Comment } from '../../../..';
import { LoadingWrapperService, ParentCommentType } from '../../../../../shared';
import { AccountHelpers } from '../../../../../shared/children/account';
import { CommentHttpService } from '../../service/comment-http.service';

@Component({
    selector: 'show-comment',
    templateUrl: 'show-comment.component.html'
})
export class ShowCommentComponent {

    @Output() public removedComment = new EventEmitter();
    @Input() public comment: Comment;
    @Input() public projectId: number;
    public showAddComment: boolean = false;
    public showEditComment: boolean = false;

    constructor(
      private _commentHttpService: CommentHttpService,
      private _loadingWrapperService: LoadingWrapperService
    ) {
    }

    public getComment() {
        this._loadingWrapperService.Load(
            this._commentHttpService.get(this.projectId, this.comment.id),
            (data) => this.comment = data
        );
    }

    public getChildComments() {
        this._loadingWrapperService.Load(
            this._commentHttpService.getAll(
                this.projectId,
                this.comment.id,
                ParentCommentType.comment
            ),
            (data) => this.comment.comments = data
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

    public canEdit() {
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
