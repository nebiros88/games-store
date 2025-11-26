import { Component, OnInit, signal } from '@angular/core';

@Component({
  selector: 'app-games-list',
  imports: [],
  templateUrl: './games-list.html',
  styleUrl: './games-list.css',
})
export class GamesList implements OnInit {
  public games = signal([]);

  ngOnInit(): void {
    console.log('ON INIT GAMES LIST');
  }
}
