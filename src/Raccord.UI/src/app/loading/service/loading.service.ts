import { Injectable } from '@angular/core';
import { Subject }    from 'rxjs/Subject';
@Injectable()
export class LoadingService {

  public toggleLoadingSource = new Subject<boolean>();
  public toggleLoading$ = this.toggleLoadingSource.asObservable();
  private loadingIds: string[] = [];

  public startLoading(): string {
    let id = this.generateId();
    this.loadingIds.push(id);
    this.toggleLoadingSource.next(true);
    return id;
  }

  public endLoading(id: string) {
    this.loadingIds.splice(this.loadingIds.indexOf(id));
    if (!this.loadingIds.length) {
      this.toggleLoadingSource.next(false);
    }
  }

  public endAllLoading() {
    this.loadingIds = [];
    this.toggleLoadingSource.next(false);
  }

  private generateId(): string {
    return Math.round(Math.random() * 1000).toString();
  }
}
