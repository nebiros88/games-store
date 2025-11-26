import { Routes } from '@angular/router';

import { MainPage } from '../features/main-page/main-page';
import { GamesPage } from '../features/games-page/games-page';
import { NotFoundPage } from '../features/not-found-page/not-found-page';

export const routes: Routes = [
  {
    path: '',
    component: MainPage,
    title: 'Main page',
  },
  {
    path: 'games',
    component: GamesPage,
    title: 'Games page',
  },
  {
    path: '**',
    component: NotFoundPage,
  },
];
