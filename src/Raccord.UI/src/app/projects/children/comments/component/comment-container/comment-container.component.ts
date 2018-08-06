import { Component, Input, Output, EventEmitter, OnChanges, OnInit } from '@angular/core';
import { ParentCommentType, LoadingWrapperService } from '../../../../../shared';
import { CommentHttpService } from '../../service/comment-http.service';

@Component({
    selector: 'comment-container',
    templateUrl: 'comment-container.component.html'
})
export class CommentContainerComponent implements OnInit {

    @Input() public comments: Comment[];
    @Input() public projectId: number;
    @Input() public parentId: number;
    @Input() public parentType: ParentCommentType;

    constructor(
      private _commentHttpService: CommentHttpService,
      private _loadingWrapperService: LoadingWrapperService
    ) {
    }

    public ngOnInit() {
        // this.getComments();
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
