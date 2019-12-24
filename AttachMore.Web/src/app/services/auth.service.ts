import { Injectable } from '@angular/core';
import { Router } from '@angular/router';
import { Subject, Observable } from 'rxjs';
import { HttpClient, HttpHeaders, HttpParams } from '@angular/common/http';

import { Register, Signin } from '../models';
import { URLS } from '../configuration/url.config';
import { Common } from '../configuration';
import { tap } from 'rxjs/operators';

@Injectable({
  providedIn: 'root'
})
export class AuthService {

  whenUserLoggedIn = new Subject();

  set redirectUrl(url: string) {
    localStorage.setItem(Common.redirectUrl, url);
  }

  get redirectUrl(): string {
    const url = localStorage.getItem(Common.redirectUrl);
    return url ? url : '/';
  }

  set token(token: string) {
    localStorage.setItem(Common.authToken, token);
  }

  get token(): string {
    return localStorage.getItem(Common.authToken);
  }

  set userInfo(user: any) {
    localStorage.setItem(Common.userInfo, JSON.stringify(user));
  }

  get userInfo(): any {
    return JSON.parse(localStorage.getItem(Common.userInfo));
  }

  get isLoggedIn(): boolean {
    return !!(this.token && this.userInfo);
  }

  constructor(private router: Router, private httpClient: HttpClient) {
  }

  /**
     * -- register user
     * @param {Register} data
     * @param {HttpHeaders } headers
     * @returns observalbe of type any
     */
  registerUser(data: Register, headers?: HttpHeaders): Observable<any> {
    let newHeaders: HttpHeaders;
    if (!headers) {
      newHeaders = new HttpHeaders();
    }
    newHeaders = newHeaders.append(Common.noToken, 'true');
    return this.httpClient.post<any>(URLS.register, data, { headers: newHeaders })
      .pipe(tap(res => {
        this.token = res.token;
        this.userInfo = res;
      }));
  }

  /**
    * @description Signin user
    * @param {Register} data
    * @param { HttpHeaders } headers
    * @returns observalbe of type any
    */
  signinUser(data: Signin, headers?: HttpHeaders): Observable<any> {
    let newHeaders: HttpHeaders;
    if (!headers) {
      newHeaders = new HttpHeaders();
    }
    newHeaders = newHeaders.append(Common.noToken, 'true');
    return this.httpClient.post<any>(URLS.login, data, { headers: newHeaders })
      .pipe(tap(res => {
        this.token = res.token;
        this.userInfo = res;
      }));
  }

  verifyEmail(email: string, headers?: HttpHeaders) {
    let newHeaders: HttpHeaders;
    if (!headers) {
      newHeaders = new HttpHeaders();
    }
    newHeaders = newHeaders.append(Common.noToken, 'true');
    const PARAMS = new HttpParams().append('Email', email);
    return this.httpClient.get<any>(URLS.verifyEmail, { headers: newHeaders, params: PARAMS });
  }

  forgetPassword(email: string, headers?: HttpHeaders) {
    let newHeaders: HttpHeaders;
    if (!headers) {
      newHeaders = new HttpHeaders();
    }
    newHeaders = newHeaders.append(Common.noToken, 'true');
    const PARAMS = new HttpParams().append('Email', email);
    return this.httpClient.get(URLS.forgetPassword,
      { headers: newHeaders, params: PARAMS, responseType: 'text' });
  }

  /**
   * @description Signout user
   */
  signOut(): void {
    localStorage.removeItem(Common.authToken);
    localStorage.removeItem(Common.redirectUrl);
    localStorage.removeItem(Common.userInfo);
    this.router.navigate(['/home']);
  }

}
