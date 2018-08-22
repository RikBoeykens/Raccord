import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { FormsModule } from '@angular/forms';
import { HttpModule } from '@angular/http';
import { HttpClientModule } from '@angular/common/http';
import { RouterModule, PreloadAllModules } from '@angular/router';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';

/*
 * Platform and Environment providers/directives/pipes
 */
import { environment } from 'environments/environment';
import { ROUTES } from './app.routes';
// App is our top level component
import { AppComponent } from './app.component';
import { COMPONENTS } from './app.module.components';
import { DIALOGS } from './app.module.components';
import { SERVICES } from './app.module.services';
import { INTERCEPTORS } from './app.module.interceptors';
import { PIPES } from './app.module.pipes';

// external modules
import { DragulaModule } from 'ng2-dragula';
import { CalendarModule } from 'angular-calendar';
import { AngularMaterialModule } from './shared/modules/angular-material';
import { FlexLayoutModule } from '@angular/flex-layout';
import { Ng2HighchartsModule } from 'ng2-highcharts';
import { AgmCoreModule } from '@agm/core';

import '../styles/styles.scss';
import '../styles/headings.css';

/**
 * `AppModule` is the main entry point into Angular2's bootstraping process
 */
@NgModule({
  bootstrap: [ AppComponent ],
  declarations: [
    COMPONENTS,
    DIALOGS,
    PIPES
  ],
  entryComponents: [
    DIALOGS
  ],
  /**
   * Import Angular's modules.
   */
  imports: [
    BrowserModule,
    BrowserAnimationsModule,
    FormsModule,
    HttpModule,
    HttpClientModule,
    DragulaModule,
    AngularMaterialModule,
    FlexLayoutModule,
    Ng2HighchartsModule,
    AgmCoreModule.forRoot({
      apiKey: 'AIzaSyAHVRCUkTtP9FDacHfHoEJDeWQu0sRA7-U'
    }),
    CalendarModule.forRoot(),
    RouterModule.forRoot(ROUTES, {
      useHash: Boolean(history.pushState) === false,
      preloadingStrategy: PreloadAllModules
    })
  ],
  /**
   * Expose our Services and Providers into Angular's dependency injection.
   */
  providers: [
    environment.ENV_PROVIDERS,
    SERVICES,
    INTERCEPTORS
  ]
})
export class AppModule {}
