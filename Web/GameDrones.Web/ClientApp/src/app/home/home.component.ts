import { Component } from '@angular/core';
import { IGameMove } from '../../interfaces/IGameMove';
import { MatchService } from '../../services/match.service';
import { RoundOneComponent } from '../rounds/round-one.component';


@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  providers: [MatchService]
})
export class HomeComponent {
  public namePlayerOne: string;
  public namePlayerTwo: string;
  public movePlayerOne: string;
  public movePlayerTwo: string;
  public matchMoves: IGameMove[];
  public isStartGame: boolean = true;
  public isRoundOne: boolean = false;

  public constructor(private _matchService: MatchService) {
    this.getMoves();
  }

  public onStartGame() {
    this.isStartGame = false;
    this.isRoundOne = true;
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

  public onPlay() {
    alert(this.movePlayerTwo);
  }

}
