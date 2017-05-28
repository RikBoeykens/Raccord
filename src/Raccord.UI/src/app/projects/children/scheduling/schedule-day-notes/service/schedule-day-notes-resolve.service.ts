import { Injectable }             from '@angular/core';
import { Router, Resolve, ActivatedRouteSnapshot } from '@angular/router';
import { ScheduleDayNoteHttpService } from './schedule-day-note-http.service';
import { ScheduleDayNoteSummary } from '../model/schedule-day-note-summary.model';
@Injectable()
export class ScheduleDayNotesResolve implements Resolve<ScheduleDayNoteSummary[]> {

  constructor(
    private scheduleDayNoteHttpService: ScheduleDayNoteHttpService, 
    private router: Router
  ) {}

    resolve(route: ActivatedRouteSnapshot) {
        let scheduleDayId = route.params['scheduleDayId'];
        return this.scheduleDayNoteHttpService.getAll(scheduleDayId).then(data => {
            return data;
        });
    }
}