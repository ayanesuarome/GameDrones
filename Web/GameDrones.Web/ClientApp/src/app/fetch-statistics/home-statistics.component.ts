import { Component, Inject } from '@angular/core';
import { Title } from '@angular/platform-browser';
import { HttpClient } from '@angular/common/http';

@Component({
  selector: 'app-home-statistics',
  templateUrl: './home-statistics.component.html',
  providers: [Title]
})
export class HomeStatisticsComponent {
  public playerName: string;
  private baseUrl: string;

  public constructor( private _titleService: Title,
                      @Inject('BASE_URL') baseUrl: string) {
    this._titleService.setTitle("GameDrones | Statistics");
    this.baseUrl = baseUrl;
  }

  public onPlayerStatistics() {
    location.assign(this.baseUrl + '/fetch-statistics/' + this.playerName);
  }
}
