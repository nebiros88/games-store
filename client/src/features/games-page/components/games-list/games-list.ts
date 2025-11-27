import { Component, inject, OnInit, signal } from '@angular/core';

import { Game } from '../../../../types';
import { GamesService } from '../../../../core/services/games-service';

@Component({
  selector: 'app-games-list',
  templateUrl: './games-list.html',
  styleUrl: './games-list.css',
})
export class GamesList implements OnInit {
  public games = signal<Game[]>([]);
  private gamesService = inject(GamesService);

  ngOnInit(): void {
    this.gamesService.getGames().subscribe((result) => this.games.set(result));
  }
}
