import { Injectable, Inject } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { IGameStatistics } from '../interfaces/IGameStatistics';

@Injectable()
export class WebService {
  private _baseUrl: string;
  private _GamesWonByPlayerUrl: string;

  public constructor(private _http: HttpClient,
    @Inject('BASE_URL') baseUrl: string) {
    this._baseUrl = baseUrl;
  }

  public callUrl(url: string) {
    return this._http.get(url);
  }

  public getIGameStatistics(playerName: string) {
    let url = this.encodeAddress(this._baseUrl + 'api/Matches/GamesWonByPlayer', '?name=' + playerName);
    return this._http.get<IGameStatistics[]>(url);
  }

  public createMatch(body: any) {
    const headers = new HttpHeaders().set("Content-type", "application/json");
    let url = this._baseUrl + 'api/Matches/CreateMatch';

    return this._http.post(url, body, { headers });
  }

  public encodeAddress(url: string, params: string): string {
    return url + encodeURI(params);
  }
}
