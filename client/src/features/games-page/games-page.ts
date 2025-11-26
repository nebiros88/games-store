import { Component } from '@angular/core';

import { GamesList } from './components/games-list/games-list';

@Component({
  selector: 'app-games-page',
  imports: [GamesList],
  templateUrl: './games-page.html',
  styleUrl: './games-page.css',
})
export class GamesPage {}
