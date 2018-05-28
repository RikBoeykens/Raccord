import { Component, Input, Output, EventEmitter, OnChanges, OnInit } from '@angular/core';
import { Comment } from '../../model/comment.model';
import { CommentHttpService } from '../../service/comment-http.service';
import { LoadingService } from '../../../../../loading/service/loading.service';
import { DialogService } from '../../../../../shared/service/dialog.service';
import { AccountHelpers } from '../../../../../account/helpers/account.helper';
import { LoadingWrapperService } from '../../../../../shared/service/loading-wrapper.service';

@Component({
    selector: 'show-comment',
    templateUrl: 'show-comment.component.html'
})
export class ShowCommentComponent implements OnInit{

    @Output() removedComment = new EventEmitter();
    @Input() comment: Comment;
    @Input() projectId: number;
    childComments: Comment[] = [];
    showAddComment: boolean = false;
    showEditComment: boolean = false;

    constructor(
      private _commentHttpService: CommentHttpService,
      private _loadingWrapperService: LoadingWrapperService,
      private _loadingService: LoadingService,
      private _dialogService: DialogService
    ){
    }

    ngOnInit() {
        this.getChildComments();
    }

    public getComment() {
        this._loadingWrapperService.Load(
            this._commentHttpService.get(this.projectId, this.comment.id),
            (data) => this.comment = data
        );
    }

    getChildComments() {
        this._loadingWrapperService.Load(
            this._commentHttpService.getAll(this.projectId, null, this.comment.id),
            (data) => this.childComments = data
        );
    }

    getFullName() {
        return `${this.comment.user.firstName} ${this.comment.user.lastName}`;
    }

    toggleEditComment(value: boolean) {
        this.showEditComment = value;
    }

    commentEdited(id: number) {
        this.getComment();
        this.toggleEditComment(false);
    }

    toggleAddComment(value: boolean) {
        this.showAddComment = value;
    }

    commentAdded(id: number) {
        this.toggleAddComment(false);
        this.getChildComments();
    }

    canEdit(){
        return this.comment.user.id === AccountHelpers.getUserId();
    }

    removeComment() {
        let loadingId = this._loadingService.startLoading();

        this._commentHttpService.delete(this.projectId, this.comment.id).then(data=>{
            if(typeof(data)=='string'){
                this._dialogService.error(data);
            }else{
                this.removedComment.emit();
            }
        }).catch()
        .then(()=>
            this._loadingService.endLoading(loadingId)
        );
    }

    onRemovedChildComment() {
        this.getChildComments();
    }
}