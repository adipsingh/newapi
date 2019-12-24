import { Injectable } from '@angular/core';
import {
  HttpInterceptor,
  HttpRequest,
  HttpHandler,
  HttpEvent
} from '@angular/common/http';
import { Observable } from 'rxjs';

import { AuthService } from '../services/auth.service';
import { Common } from '../configuration';

@Injectable()
export class TokenAppenderInterceptor implements HttpInterceptor {
  constructor(
    private authService: AuthService
  ) { }

  intercept(
    req: HttpRequest<any>,
    next: HttpHandler
  ): Observable<HttpEvent<any>> {

    if (req.headers.has(Common.noToken) || req.headers.has(Common.emailVerifyToken)) {
      req.headers.delete(Common.emailVerifyToken);
      req.headers.delete(Common.noToken);
      return next.handle(req);
    }

    let authReq;
    if (this.authService.isLoggedIn) {
      authReq = req.clone({
        headers: req.headers.set(Common.authorization, `Bearer ${this.authService.token}`)
      });
    } else {
      authReq = req;
    }

    return next.handle(authReq);
  }
}
