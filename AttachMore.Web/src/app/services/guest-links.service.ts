import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { GuestLink } from '../models/guest-link.model';
import { URLS } from '../configuration';
import { map } from 'rxjs/operators';

@Injectable({
  providedIn: 'root'
})
export class GuestLinksService {
  constructor(private httpClient: HttpClient) { }

  /**
   * Get Guest Link
   */
  getGuestLinks(): Observable<GuestLink[]> {
    return this.httpClient.get<GuestLink[]>(URLS.guestLink);
  }

  /**
   * Get Guest Link
   */
  generateGuestLinks(data: GuestLink): Observable<string> {
    return this.httpClient.post(URLS.guestLink, data, { observe: 'body', responseType: 'text' }).pipe(map((res) => {
      return res as string;
    }));
  }
}
