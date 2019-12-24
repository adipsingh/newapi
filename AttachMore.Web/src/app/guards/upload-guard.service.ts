import { Injectable } from '@angular/core';
import { CanActivate, ActivatedRouteSnapshot, RouterStateSnapshot, Router } from '@angular/router';

import { Observable } from 'rxjs';
import { UploadService } from '../services/upload.service';

@Injectable({
    providedIn: 'root'
})
export class UploadGuardService implements CanActivate {

    constructor(private router: Router, private uploadService: UploadService) { }

    canActivate(route: ActivatedRouteSnapshot, state: RouterStateSnapshot): Observable<boolean> | Promise<boolean> | boolean {
        return this.verifyFiles();
    }

    /**
     * @description Check Login details
     * @returns boolean
     */
    verifyFiles(): boolean {
        if (this.uploadService.uploader.queue.length) {
            return true;
        }

        this.router.navigate(['/home']);
        return false;
    }
}
