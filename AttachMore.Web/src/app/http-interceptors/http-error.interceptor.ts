import { Injectable } from '@angular/core';
import {
  HttpInterceptor,
  HttpRequest,
  HttpHandler,
  HttpEvent,
  HttpErrorResponse
} from '@angular/common/http';
import { Observable, throwError } from 'rxjs';

import { catchError } from 'rxjs/operators';
import { AuthService } from '../services/auth.service';
import { NotificationService } from '../services/notification.service';
import { TM_ERRORS } from '../configuration';

@Injectable()
export class HttpErrorInterceptor implements HttpInterceptor {
  constructor(public notificationService: NotificationService, private authService: AuthService) { }

  intercept(
    req: HttpRequest<any>,
    next: HttpHandler
  ): Observable<HttpEvent<any>> {

    return next.handle(req)
      .pipe(catchError((error: HttpErrorResponse) => {
        // intercept the response error and displace it to the console
        if (error instanceof HttpErrorResponse) {
          this.handleHttpError(error);
        }
        return throwError(error);
      }));
  }

  /**
   * @description Handing Http Errors
   * @param err
   */
  private handleHttpError(err: HttpErrorResponse): void {
    switch (err.status) {
      case 400:
        this.notificationService.notify(TM_ERRORS.BAD_REQUEST);
        break;
      case 401:
        this.authService.signOut();
        break;
    }
  }
}

