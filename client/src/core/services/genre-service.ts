import { HttpClient } from '@angular/common/http';
import { inject, Injectable } from '@angular/core';
import { Observable } from 'rxjs';

import { ConfigurationService } from './configuration-service';
import { Genre } from '../../types';

@Injectable({
  providedIn: 'root',
})
export class GenreService {
  private configService = inject(ConfigurationService);
  private http = inject(HttpClient);

  getGenres(): Observable<Genre[]> {
    return this.http.get<Array<Genre>>(`${this.configService.apiBaseUrl()}/genres`);
  }
}
