import { Component } from '@angular/core';

@Component({
    selector: 'raccord-navbar',
    templateUrl: 'navbar.component.html',
})
export class NavbarComponent {
    showSearchBar: boolean = false;
    
    constructor(
    ){
    }

    toggleSearchBar(value: boolean){
        this.showSearchBar = value;
    }

    doShowSearchBar(){
        this.toggleSearchBar(true);
    }
}