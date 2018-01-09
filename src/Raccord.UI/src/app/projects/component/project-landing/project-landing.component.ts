import { Component } from '@angular/core';
import { Router, ActivatedRoute } from '@angular/router';
import { FullProject } from '../../model/full-project.model';
import { CommentHttpService } from '../../children/comments/service/comment-http.service';

@Component({
    templateUrl: 'project-landing.component.html',
})
export class ProjectLandingComponent {

    project: FullProject;

    constructor(
        private _commentHttpService: CommentHttpService,
        private route: ActivatedRoute,
        private router: Router
    ){
    }

    ngOnInit() {
        this.route.data.subscribe((data: { project: FullProject }) => {
            this.project = data.project;
        });
    }

    getComments() {
        this._commentHttpService.getAll(this.project.id, null).then((comments)=> this.project.comments = comments);
    }

    onCommentSubmit(id: number) {
        this.getComments();
    }

    onRemovedComment() {
        this.getComments();
    }
}