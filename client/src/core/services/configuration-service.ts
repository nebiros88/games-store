import { Injectable } from '@angular/core';
import { environment } from '../../environments/environment';

@Injectable({
  providedIn: 'root',
})
export class ConfigurationService {
  public apiBaseUrl() {
    return `${environment.API_BASE}:${environment.API_PORT}`;
  }
}
