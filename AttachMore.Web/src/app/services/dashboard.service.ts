import { Injectable } from '@angular/core';
import { HttpClient, HttpParams } from '@angular/common/http';
import { Observable } from 'rxjs';
import { map, tap } from 'rxjs/operators';

import { URLS } from '../configuration';
import { Dashboard, FilesHistory, AttachmentDetails, UserDetail, DataUsage } from '../models';

@Injectable({
    providedIn: 'root'
})
export class DashboardService {

    constructor(private httpClient: HttpClient) { }

    /**
     * Get Stats
     */
    getStats(): Observable<Dashboard> {
        return this.httpClient.get<Dashboard>(URLS.dashboard);
    }

    /**
     * Get Files History
     */
    getFilesHistory(): Observable<FilesHistory[]> {
        return this.httpClient.get<FilesHistory[]>(URLS.filesHistory)
            .pipe(map((arr) => {
                return arr.map((value, index, array) => {
                    const attachmentTypeArr = value.attachmentType.split('.');
                    return {
                        ...value,
                        extension: (attachmentTypeArr && attachmentTypeArr.length) ? attachmentTypeArr.pop().toLowerCase() : 'zip',
                    };
                });
            }));
    }

    /**
     * Get Attachment Details
     */
    getAttachmentDetails(attachmentId: number): Observable<AttachmentDetails> {
        const PARAMS = new HttpParams().append('AttachmentId', attachmentId.toString());
        return this.httpClient.get<AttachmentDetails>(URLS.attachmentDetails, { params: PARAMS });
    }

    /**
     * Get User Details
     */
    getUserDetails(): Observable<UserDetail> {
        return this.httpClient.get<UserDetail>(URLS.userDetail);
    }

    /**
     * Get Data usage
     */
    getDataUsage(): Observable<DataUsage> {
        return this.httpClient.get<DataUsage>(URLS.dataUsage);
    }
}
