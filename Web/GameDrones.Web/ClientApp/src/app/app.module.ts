import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { HttpClientModule } from '@angular/common/http';

import { AppRoutingModule } from './app-routing.module';
import { GridModule } from '@syncfusion/ej2-angular-grids'
import { PageService } from '@syncfusion/ej2-angular-grids';
import { AppComponent } from './app.component';
import { NavMenuComponent } from './nav-menu/nav-menu.component';
import { HomeComponent } from './home/home.component';
import { HomeStatisticsComponent } from './fetch-statistics/home-statistics.component';
import { MatchStatisticsComponent } from './fetch-statistics/fetch-statistics.component';
import { RoundOneComponent } from './rounds/round-one.component';
import { RoundTwoComponent } from './rounds/round-two.component';
import { RoundThreeComponent } from './rounds/round-three.component';
import { RoundEndComponent } from './rounds/round-end.component';
import { MatchService } from '../services/match.service';

@NgModule({
  declarations: [
    AppComponent,
    NavMenuComponent,
    HomeComponent,
    HomeStatisticsComponent,
    MatchStatisticsComponent,
    RoundOneComponent,
    RoundTwoComponent,
    RoundThreeComponent,
    RoundEndComponent
  ],
  imports: [
    BrowserModule.withServerTransition({ appId: 'ng-cli-universal' }),
    HttpClientModule,
    FormsModule,
    AppRoutingModule,
    GridModule
  ],
  providers: [MatchService, PageService],
  bootstrap: [AppComponent]
})
export class AppModule { }
