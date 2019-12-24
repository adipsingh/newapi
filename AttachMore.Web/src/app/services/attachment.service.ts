import { Injectable } from '@angular/core';
import { HttpClient, HttpParams } from '@angular/common/http';
import { Observable, Subject } from 'rxjs';
import { tap } from 'rxjs/operators';

import { Attachment, AttachmentPreview, DownloadAttachment } from '../models';
import { URLS } from '../configuration/url.config';

@Injectable({
  providedIn: 'root'
})
export class AttachmentService {

  attachmentId = 0;
  url = new Subject();
  attachment: AttachmentPreview;
  guestLinkId: string;

  constructor(private httpClient: HttpClient) { }

  /**
   * get Attachment
   * @param jsonData
   */
  getAttachment(jsonData: Attachment): Observable<Attachment> {
    jsonData.guestLinkID = this.guestLinkId;
    return this.httpClient.post<Attachment>(URLS.attachment, jsonData)
      .pipe(tap((data) => this.url.next(`${data.downloadUrl}`)));
  }

  /**
   * update attachment name
   * @param jsonData
   */
  upadateAttachmentName(jsonData: any) {
    const FORM_DATA = new FormData();
    Object.keys(jsonData).forEach(f => {
      FORM_DATA.append(f, jsonData[f]);
    });
    return this.httpClient.post(URLS.updateAttachmentName, FORM_DATA, { responseType: 'text' });
  }

  /**
   * donwload attachment from server
   * @param data
   */
  downloadAttachment(data: DownloadAttachment) {
    return this.httpClient.post(`${URLS.downloadAttachment}`, data, { responseType: 'blob' });
  }

  /**
 * Get attachment Preview by id from server
 * @param attachmentId
 */
  getAttachmentPreviewById(attachmentId: number): Observable<any> {
    const PARAMS = new HttpParams().append('Id', attachmentId.toString());
    return this.httpClient.get(`${URLS.attachmentPreview}`, { params: PARAMS }).pipe(tap((data) => this.attachment = data));
  }
}
