import { Component, Input } from '@angular/core';
import { IGameMove } from '../../interfaces/IGameMove';
import { IGameStatistics } from '../../interfaces/IGameStatistics';
import { MatchService } from '../../services/match.service';

@Component({
  selector: 'app-round-three',
  templateUrl: './round-three.component.html'
})
export class RoundThreeComponent {
  @Input('PlayerOneData') namePlayerOne: string;
  @Input('PlayerTwoData') namePlayerTwo: string;
  public movePlayerOne: string;
  public movePlayerTwo: string;
  public matchMoves: IGameMove[];
  public matchResults: IGameStatistics[];
  public isRoundThree: boolean = true;
  public isRoundPlayerOne: boolean = true;
  public isRoundPlayerTwo: boolean = false;
  public isRoundEnd: boolean = false;
 

  public constructor(private _matchService: MatchService) {
    this.getMoves();
    this.UpdateMovePlayerOne(0);
    this.UpdateMovePlayerTwo(0);
    this.matchResults = this._matchService.fillMatchResults();
  }

  public getMoves() {
    this.matchMoves = this._matchService.getMoves();
  }

  public onPlayerOneMoveChange(MoveValue: number) {
    if (MoveValue > 0) {
      this.UpdateMovePlayerOne(MoveValue);
    }
  }

  private UpdateMovePlayerOne(MoveID: number) {
    var x: number = 0;

    if (MoveID > 0) {
      x = MoveID - 1;
    }

    this.movePlayerOne = this.matchMoves[x].name;
  }

  private UpdateMovePlayerTwo(MoveID: number) {
    var x: number = 0;

    if (MoveID > 0) {
      x = MoveID - 1;
    }

    this.movePlayerTwo = this.matchMoves[x].name;
  }

  public onPlayerTwoMoveChange(MoveValue: number) {
    if (MoveValue > 0) {
      this.UpdateMovePlayerTwo(MoveValue);
    }
  }

  public onPlayPlayerOne() {
    this.isRoundPlayerOne = false;
    this.isRoundPlayerTwo = true;
  }

  public onPlay() {
    var result = this._matchService.getWinnerPlayer(this.movePlayerOne, this.movePlayerTwo);

    switch (result) {
    case "PlayerOne":
        this._matchService.winnerRoundThree = this.namePlayerOne;
      break;
    case "PlayerTwo":
        this._matchService.winnerRoundThree = this.namePlayerTwo;
      break;
    }

    this.isRoundEnd = true;
    this.isRoundThree = false;

    var winner = this._matchService.getWinner();

    if (winner !== this.namePlayerOne) {
      this._matchService.loser = this.namePlayerOne;
    } else {
      this._matchService.loser = this.namePlayerTwo;
    }
  }
}
