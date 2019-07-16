import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { HomeComponent } from './home/home.component';
import { HomeStatisticsComponent } from './fetch-statistics/home-statistics.component';
import { MatchStatisticsComponent } from './fetch-statistics/fetch-statistics.component';

const routes: Routes = [
  { path: '', component: HomeComponent, pathMatch: 'full' },
  { path: 'home-statistics', component: HomeStatisticsComponent },
  { path: 'fetch-statistics/:name', component: MatchStatisticsComponent }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
