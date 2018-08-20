import { Component, Input, Output, EventEmitter, OnInit } from '@angular/core';
import { ParentCommentType, LoadingWrapperService } from '../../../../../shared';
import { Comment, PostComment } from '../../../..';
import { CommentHttpService } from '../../service/comment-http.service';

@Component({
    selector: 'edit-comment',
    templateUrl: 'edit-comment.component.html'
})
export class EditCommentComponent implements OnInit {

    @Output() public submittedComment = new EventEmitter();
    @Input() public comment: Comment;
    @Input() public projectId: number;
    @Input() public parentId: number;
    @Input() public parentType: ParentCommentType;
    public postComment: PostComment;

    constructor(
      private _commentHttpService: CommentHttpService,
      private _loadingWrapperService: LoadingWrapperService
    ) {
    }

    public ngOnInit() {
        this.setNewPostComment();
    }

    public setNewPostComment() {
        this.postComment = new PostComment({
            id: this.comment != null ? this.comment.id : 0,
            text: this.comment != null ? this.comment.text : '',
            parentID: this.parentId,
            parentType: this.parentType
          });
    }

    public doCommentSubmit() {
        this._loadingWrapperService.Load(
            this._commentHttpService.post(this.projectId, this.postComment),
            (data) => {
                this.setNewPostComment();
                this.submittedComment.emit(data);
            }
        );
    }
}
