import { Injectable } from '@angular/core';
import { MOVES } from './move-data';
import { IGameStatistics } from '../interfaces/IGameStatistics';


@Injectable({
  providedIn: 'root',
})
export class MatchService {
  private _winnerRoundOne: string;
  private _winnerRoundTwo: string;
  private _winnerRoundThree: string;
  private _matchResults: IGameStatistics[];
  public winner:string;
  public loser:string;

  public getMoves(): any {
    return MOVES;
  }

  public getWinnerPlayer(moveOne: string, moveTwo: string): string {
    if (moveOne === moveTwo) return "tie match";

    switch (moveOne) {
    case "Rock":
      if (moveTwo === "Scissors") {
        return "PlayerOne";
      } else {
        if (moveTwo === "Paper") {
          return "PlayerTwo";
        }
      }
    case "Paper":
      if (moveTwo === "Rock") {
        return "PlayerOne";
      } else {
        if (moveTwo === "Scissors") {
          return "PlayerTwo";
        }
      }
    case "Scissors":
      if (moveTwo === "Paper") {
        return "PlayerOne";
      } else {
        if (moveTwo === "Rock") {
          return "PlayerTwo";
        }
      }
    }
  }

  public fillMatchResults(): IGameStatistics[]  {
    var result: IGameStatistics[] =
      [
        { round: 1, winnerName: this._winnerRoundOne },
        { round: 2, winnerName: this.winnerRoundTwo }
      ];

    return result;
  }

  public getWinner(): string {
    var array = this.matchResults;

    var modeMap = {},
      maxEl = array[0].winnerName,
      maxCount = 1;

    for (var i = 0; i < array.length; i++) {
      var el = array[i];

      if (modeMap[el.winnerName] == null)
        modeMap[el.winnerName] = 1;
      else
        modeMap[el.winnerName]++;

      if (modeMap[el.winnerName] > maxCount) {
        maxEl = el.winnerName;
        maxCount = modeMap[el.winnerName];
      }
      else if (modeMap[el.winnerName] == maxCount) {
        maxEl += '&' + el.winnerName;
        maxCount = modeMap[el.winnerName];
      }
    }

    this.winner = maxEl;
    return maxEl;
  }

  public get matchResults(): IGameStatistics[] {
    var result: IGameStatistics[] =
    [
      { round: 1, winnerName: this._winnerRoundOne },
      { round: 2, winnerName: this.winnerRoundTwo },
      { round: 3, winnerName: this.winnerRoundThree }
      ];

    return result;
  }
  public set matchResults(newMatchResult: IGameStatistics[]) {
    this._matchResults = newMatchResult;
  }

  public get winnerRoundOne(): string {
    return this._winnerRoundOne;
  }
  public set winnerRoundOne(newWinner: string) {
    this._winnerRoundOne = newWinner;
  }

  public get winnerRoundTwo(): string {
    return this._winnerRoundTwo;
  }
  public set winnerRoundTwo(newWinner: string) {
    this._winnerRoundTwo = newWinner;
  }

  public get winnerRoundThree(): string {
    return this._winnerRoundThree;
  }
  public set winnerRoundThree(newWinner: string) {
    this._winnerRoundThree = newWinner;
  }
}
