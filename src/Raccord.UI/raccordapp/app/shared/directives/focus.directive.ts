import { Directive, ElementRef } from "@angular/core";

@Directive({
  selector: '[raccord-focus]'
})
export class FocusDirective {
    constructor(private elementRef: ElementRef) {}
    ngAfterViewInit() {
      // set focus when element first appears
      this.setFocus();
    }
    setFocus() {
      this.elementRef.nativeElement.focus();
    }
}