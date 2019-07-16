import { Component, Input } from '@angular/core';
import { IGameMove } from '../../interfaces/IGameMove';
import { MatchService } from '../../services/match.service';

@Component({
  selector: 'app-round-one',
  templateUrl: './round-one.component.html'
})
export class RoundOneComponent {
  @Input('PlayerOneData') namePlayerOne: string;
  @Input('PlayerTwoData') namePlayerTwo: string;
  public movePlayerOne: string;
  public movePlayerTwo: string;
  public winnerRoundOne: string;
  public matchMoves: IGameMove[];
  public isRoundOne: boolean = true;
  public isRoundPlayerOne: boolean = true;
  public isRoundPlayerTwo: boolean = false;
  public isRoundTwo: boolean = false;

  public constructor(private _matchService: MatchService) {
    this.getMoves();
    this.UpdateMovePlayerOne(0);
    this.UpdateMovePlayerTwo(0);
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
        this._matchService.winnerRoundOne = this.namePlayerOne;
        break;
      case "PlayerTwo":
        this._matchService.winnerRoundOne = this.namePlayerTwo;
        break;
    }

    this.isRoundOne = false;
    this.isRoundTwo = true;
  }
}
