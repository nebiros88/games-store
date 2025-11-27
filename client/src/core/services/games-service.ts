import { HttpClient } from '@angular/common/http';
import { inject, Injectable } from '@angular/core';

import { ConfigurationService } from './configuration-service';
import { Observable } from 'rxjs';
import { Game } from '../../types';

@Injectable({
  providedIn: 'root',
})
export class GamesService {
  private configService = inject(ConfigurationService);
  private http = inject(HttpClient);

  getGames(): Observable<Game[]> {
    return this.http.get<Array<Game>>(`${this.configService.apiBaseUrl()}/games`);
  }
}
