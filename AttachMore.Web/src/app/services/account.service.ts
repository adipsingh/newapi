import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';

import { URLS, Common } from '../configuration';
import { ResetPassword } from '../models';

@Injectable({
    providedIn: 'root'
})
export class AccountService {

    constructor(private httpClient: HttpClient) { }

    /**
    * Reset Password
    */
    resetPassword(type: string, data: ResetPassword) {
        let header = new HttpHeaders();
        if (type === 'RESET') {
            header = header.append(Common.emailVerifyToken, 'true');
            header = header.append(Common.authorization, `Bearer ${localStorage.getItem(Common.emailVerifyToken)}`);
        }
        return this.httpClient.post(URLS.resetPassword, data, { headers: header, responseType: 'text' });
    }
}
