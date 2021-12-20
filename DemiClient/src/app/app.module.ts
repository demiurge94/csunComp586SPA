import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { HttpClientModule, HTTP_INTERCEPTORS } from '@angular/common/http';
import { RouterModule } from '@angular/router';

import { AppComponent } from './app.component';
import { NavMenuComponent } from './nav-menu/nav-menu.component';
import { HomeComponent } from './home/home.component';
import { CounterComponent } from './counter/counter.component';
import { FetchDataComponent } from './fetch-data/fetch-data.component';
import { LoginComponent } from './login/login.component';
import { MatTableModule} from '@angular/material/table'; 
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { AuthService } from './login/auth.service';
import { AuthInterceptor } from './services/auth.interceptor';
import { ArtistModalComponent } from './modals/modal/artist-modal.component';
import { NgbModule } from '@ng-bootstrap/ng-bootstrap';
import { MdbAccordionModule } from 'mdb-angular-ui-kit/accordion';
import { MdbCarouselModule } from 'mdb-angular-ui-kit/carousel';
import { MdbCheckboxModule } from 'mdb-angular-ui-kit/checkbox';
import { MdbCollapseModule } from 'mdb-angular-ui-kit/collapse';
import { MdbDropdownModule } from 'mdb-angular-ui-kit/dropdown';
import { MdbFormsModule } from 'mdb-angular-ui-kit/forms';
import { MdbModalModule } from 'mdb-angular-ui-kit/modal';
import { MdbPopoverModule } from 'mdb-angular-ui-kit/popover';
import { MdbRadioModule } from 'mdb-angular-ui-kit/radio';
import { MdbRangeModule } from 'mdb-angular-ui-kit/range';
import { MdbRippleModule } from 'mdb-angular-ui-kit/ripple';
import { MdbScrollspyModule } from 'mdb-angular-ui-kit/scrollspy';
import { MdbTabsModule } from 'mdb-angular-ui-kit/tabs';
import { MdbTooltipModule } from 'mdb-angular-ui-kit/tooltip';
import { MdbValidationModule } from 'mdb-angular-ui-kit/validation';
import { RegisterComponent } from './register/register/register.component';
import { ArtistViewComponent } from './artist/artist-view/artist-view.component';
import { ArtistDetailModalComponent } from './artist-detail-modal/artist-detail-modal.component';
@NgModule({
  declarations: [
    AppComponent,
    NavMenuComponent,
    HomeComponent,
    CounterComponent,
    FetchDataComponent,
    LoginComponent,
    ArtistModalComponent,
    RegisterComponent,
    ArtistViewComponent,
    ArtistDetailModalComponent
  ],
  imports: [
    BrowserModule.withServerTransition({ appId: 'ng-cli-universal' }),
    HttpClientModule,
    FormsModule,

    BrowserAnimationsModule,
    MatTableModule,
    ReactiveFormsModule,
   // ApiAuthorizationModule,
    RouterModule.forRoot([
      { path: '', component: HomeComponent, pathMatch: 'full' },
      { path: 'counter', component: CounterComponent },
      { path: 'fetch-data', component: FetchDataComponent},
      { path: 'Login', component: LoginComponent},
      { path: 'register', component: RegisterComponent },
      { path: 'artist' , component: ArtistViewComponent}
    ]),
   NgbModule,
   MdbAccordionModule,
   MdbCarouselModule,
   MdbCheckboxModule,
   MdbCollapseModule,
   MdbDropdownModule,
   MdbFormsModule,
   MdbModalModule,
   MdbPopoverModule,
   MdbRadioModule,
   MdbRangeModule,
   MdbRippleModule,
   MdbScrollspyModule,
   MdbTabsModule,
   MdbTooltipModule,
   MdbValidationModule
  ],
  providers: [
    AuthService,
    {
      provide: HTTP_INTERCEPTORS,
      useClass: AuthInterceptor,
      multi: true
    }
  ],
  
  bootstrap: [AppComponent]
})
export class AppModule { }
