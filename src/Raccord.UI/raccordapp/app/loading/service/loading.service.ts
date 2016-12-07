import { Injectable } from '@angular/core';
import { Subject }    from 'rxjs/Subject';
@Injectable()
export class LoadingService {

  private toggleLoadingSource = new Subject<boolean>();
  private loadingIds: string[] = [];

  toggleLoading$ = this.toggleLoadingSource.asObservable();

  startLoading(): string{
    let id = this.generateId();
    this.loadingIds.push(id);
    this.toggleLoadingSource.next(true);
    return id;
  }

  endLoading(id: string){
    this.loadingIds.splice(this.loadingIds.indexOf(id));
    if(!this.loadingIds.length)
      this.toggleLoadingSource.next(false);
  }

  private generateId(): string{
    return Math.round(Math.random()*1000).toString();
  }
}