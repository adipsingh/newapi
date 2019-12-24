import { Injectable } from '@angular/core';
import { HttpClient, HttpParams } from '@angular/common/http';
import { Observable } from 'rxjs';

import { URLS } from '../configuration';
import { ExpirySettings, SecuritySettings, NotificationSettings } from '../models';

@Injectable({
    providedIn: 'root'
})
export class SettingsService {

    constructor(private httpClient: HttpClient) { }

    /**
   * expiry settings
   * @param attachmentId
   */
    expirySettings(data: ExpirySettings) {
        return this.httpClient.post(`${URLS.expirySettings}`, data);
    }

    /**
     * Security Settings
     * @param data
     */
    securitySettings(data: SecuritySettings) {
        return this.httpClient.post(`${URLS.securitySettings}`, data);
    }

    /**
     * Notification Settings
     * @param data
     */
    notificationSettings(data: NotificationSettings) {
        return this.httpClient.post(`${URLS.notificationSettings}`, data);
    }

    /**
     * Get Security Settings
     */
    getSecuritySettings(aId: number): Observable<SecuritySettings> {
        const PARAMS = new HttpParams().append('AttachmentId', aId.toString());
        return this.httpClient.get<SecuritySettings>(`${URLS.securitySettingsInfo}`, { params: PARAMS });
    }
}
