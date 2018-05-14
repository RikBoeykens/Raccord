import {
  Directive, ElementRef, AfterViewChecked, 
  Input, HostListener
} from '@angular/core';

@Directive({
  selector: '[matchHeight]'
})
export class MatchHeightDirective implements AfterViewChecked {
  // class name to match height
  @Input() public  matchHeight: string;

  constructor(private el: ElementRef) {
  }

  public ngAfterViewChecked() {
    this.doMatchHeight(this.el.nativeElement, this.matchHeight);
  }

  public doMatchHeight(toMatchElement: HTMLElement, sourceClass: string) {
    if (!toMatchElement) {
      return;
    }
    let sourceElement = toMatchElement.parentElement.getElementsByClassName(sourceClass)[0];
    if (!sourceElement) {
      return;
    }
    toMatchElement.style.height = `${sourceElement.getBoundingClientRect().height}px`;
  }
}
