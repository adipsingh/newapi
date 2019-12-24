import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { Package } from '../models';
import { URLS } from '../configuration';

@Injectable({
    providedIn: 'root'
})
export class PackageService {

    constructor(private httpClient: HttpClient) { }

    /**
     * Get Security Settings
     */
    getAllPackages(): Observable<Package[]> {
        return this.httpClient.get<Package[]>(`${URLS.allPackages}`);
    }

    buyPackage(data: any): Observable<any> {
        return this.httpClient.post(`${URLS.buyPackage}`, data);
    }
}
