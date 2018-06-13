import { Injectable } from '@angular/core';
import { Subject } from 'rxjs/Subject';
@Injectable()
export class LoadingService {

  public toggleLoadingSource = new Subject<boolean>();
  public toggleLoading$ = this.toggleLoadingSource.asObservable();
  private isLoading: number = 0;

  public startLoading() {
    this.isLoading++;
    this.toggleLoadingSource.next(true);
  }

  public endLoading() {
    this.isLoading--;
    if (this.isLoading <= 0) {
      this.isLoading = 0;
      this.toggleLoadingSource.next(false);
    }
  }

  public endAllLoading() {
    this.isLoading = 0;
    this.toggleLoadingSource.next(false);
  }
}
