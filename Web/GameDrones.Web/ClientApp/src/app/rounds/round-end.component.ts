import { Component } from '@angular/core';
import { MatchService } from '../../services/match.service';
import { WebService } from '../../services/webService';

@Component({
  selector: 'app-round-end',
  templateUrl: './round-end.component.html',
  styleUrls: ['./round-end.component.css'],
  providers: [WebService]
})
export class RoundEndComponent {
  public isRoundEnd: boolean = true;
  public winner: string;
  public loser: string;

  public constructor( private _matchService: MatchService,
                      private _web: WebService) {
    this.winner = this._matchService.winner;
    this.loser = this._matchService.loser;

    var match = {
      "WinnerName": this.winner,
      "LoserName": this.loser
    };

    this._web.createMatch(match).subscribe(
      () => alert("New match added successfully!"),
      error => console.log(error)
    );
  }
}
