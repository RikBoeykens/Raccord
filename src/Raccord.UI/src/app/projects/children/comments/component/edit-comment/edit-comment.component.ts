import { Component, Input, Output, EventEmitter, OnChanges } from '@angular/core';
import { Comment } from '../../model/comment.model';
import { PostComment } from '../../model/post-comment.model';
import { OnInit } from '@angular/core/src/metadata/lifecycle_hooks';
import { CommentHttpService } from '../../service/comment-http.service';
import { DialogService } from '../../../../../shared/service/dialog.service';
import { ParentCommentType } from '../../../../../shared/enums/parent-comment-type.enum';
import { LoadingWrapperService } from '../../../../../shared/service/loading-wrapper.service';

@Component({
    selector: 'edit-comment',
    templateUrl: 'edit-comment.component.html'
})
export class EditCommentComponent implements OnInit{

    @Output() public submittedComment = new EventEmitter();
    @Input() public comment: Comment;
    @Input() public projectId: number;
    @Input() public parentId: number;
    @Input() public parentType: ParentCommentType;
    public postComment: PostComment;

    constructor(
      private _commentHttpService: CommentHttpService,
      private _loadingWrapperService: LoadingWrapperService,
      private _dialogService: DialogService
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
