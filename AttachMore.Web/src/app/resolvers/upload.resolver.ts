import { Injectable, Inject } from '@angular/core';
import { Resolve, ActivatedRouteSnapshot, RouterStateSnapshot } from '@angular/router';
import { Observable } from 'rxjs';

import { AttachmentService } from '../services/attachment.service';

@Injectable({
    providedIn: 'root'
})
export class UploadResover implements Resolve<any> {
    constructor(private attachmentService: AttachmentService) {

    }
    resolve(route: ActivatedRouteSnapshot, state: RouterStateSnapshot): Observable<any> | Promise<any> | any {
        this.attachmentService.guestLinkId = route.params['guestLinkId'];
        return null;
    }
}
