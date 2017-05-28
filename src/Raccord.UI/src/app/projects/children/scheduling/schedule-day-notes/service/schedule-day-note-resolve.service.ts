import { Injectable }             from '@angular/core';
import { Router, Resolve, ActivatedRouteSnapshot } from '@angular/router';
import { ScheduleDayNoteHttpService } from './schedule-day-note-http.service';
import { FullScheduleDayNote } from '../model/full-schedule-day-note.model';
@Injectable()
export class ScheduleDayNoteResolve implements Resolve<FullScheduleDayNote> {

  constructor(
      private scheduleDayNoteHttpService: ScheduleDayNoteHttpService, 
      private router: Router
  ) {}

  resolve(route: ActivatedRouteSnapshot) {
    let scheduleDayNoteId = route.params['scheduleDayNoteId'];

    return this.scheduleDayNoteHttpService.get(scheduleDayNoteId).then(note => {
        if (note) {
            return note;
        } else { // id not found
            let projectId = route.params['projectId'];
            this.router.navigate(['/projects', projectId]);
            return false;
        }
    });
  }
}