import { Component, Input, Output, EventEmitter, OnChanges } from '@angular/core';
import { Comment } from '../../model/comment.model';
import { PostComment } from '../../model/post-comment.model';
import { OnInit } from '@angular/core/src/metadata/lifecycle_hooks';
import { CommentHttpService } from '../../service/comment-http.service';
import { LoadingService } from '../../../../../loading/service/loading.service';
import { DialogService } from '../../../../../shared/service/dialog.service';

@Component({
    selector: 'edit-comment',
    templateUrl: 'edit-comment.component.html'
})
export class EditCommentComponent implements OnInit{

    @Output() submittedComment = new EventEmitter();
    @Input() comment: Comment;
    @Input() projectId?: number;
    @Input() commentId?: number;
    postComment: PostComment;

    constructor(
      private _commentHttpService: CommentHttpService,
      private _loadingService: LoadingService,
      private _dialogService: DialogService
    ){
    }

    ngOnInit() {
        this.setNewPostComment();
    }

    setNewPostComment() {
        this.postComment = new PostComment({
            id: this.comment != null ? this.comment.id : 0,
            text: this.comment != null ? this.comment.text : '',
            projectID: this.projectId,
            commentID: this.commentId
          });
    }

    doCommentSubmit(){
      let loadingId = this._loadingService.startLoading();

      this._commentHttpService.post(this.postComment).then(data=>{
          if(typeof(data)=='string'){
              this._dialogService.error(data);
          }else{
              this.setNewPostComment();
              this.submittedComment.emit(data);
          }
      }).catch()
      .then(()=>
          this._loadingService.endLoading(loadingId)
      );
    }
}