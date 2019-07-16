import { Component, Inject, OnInit } from '@angular/core';
import { Router, ActivatedRoute, ParamMap } from '@angular/router'
import { Title } from '@angular/platform-browser';
import { HttpClient } from '@angular/common/http';
import { DataManager, WebApiAdaptor, UrlAdaptor } from '@syncfusion/ej2-data';
import { PageSettingsModel } from '@syncfusion/ej2-angular-grids'
import { IGameStatistics } from '../../interfaces/IGameStatistics';
import { WebService } from '../../services/webService';

@Component({
  selector: 'app-statistics',
  templateUrl: './fetch-statistics.component.html',
  providers: [Title, WebService]
})
export class MatchStatisticsComponent implements OnInit{
  private _baseUrl: string;
  public statistics: IGameStatistics[];
  private playerName: string;
  public data: DataManager;
  public pageSettings: PageSettingsModel;

  public constructor( private _titleService: Title,
                      private _web: WebService,
                      private route: ActivatedRoute,
                      private router: Router,
                      http: HttpClient,
                      @Inject('BASE_URL') baseUrl: string) {
    this._titleService.setTitle("GameDrones | Statistics");
    this._baseUrl = baseUrl;

    let name = this.route.snapshot.paramMap.get('name');
    this.playerName = name;

    this._web.getIGameStatistics(name).subscribe(
      result => this.statistics = result,
      error => console.error(error)
    );
  }

  ngOnInit(): void {
    this.data = new DataManager({
      url: this._web.encodeAddress(this._baseUrl + 'api/Matches/GamesWonByPlayerSyncfusion', '?name=' + this.playerName),
      adaptor: new WebApiAdaptor
    });
    this.pageSettings = { pageSize: 5 };
  }
}
