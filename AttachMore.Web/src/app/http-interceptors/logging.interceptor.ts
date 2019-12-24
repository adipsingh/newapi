import { Injectable, Inject } from '@angular/core';
import { HttpInterceptor, HttpRequest, HttpHandler, HttpEvent, HttpResponse } from '@angular/common/http';
import { Observable } from 'rxjs';
import { tap, finalize } from 'rxjs/operators';

import { environment } from '../../environments/environment';

@Injectable()
export class LoggingInterceptor implements HttpInterceptor {

  constructor() { }

  intercept(req: HttpRequest<any>, next: HttpHandler): Observable<HttpEvent<any>> {

    // not logging request if app is running in production mode
    if (environment.production) {
      return next.handle(req);
    }
    const currentDate = Date.now();
    let status: string;

    // logging request if app is running in production mode
    return next.handle(req)
      .pipe(
        tap(
          event => status = event instanceof HttpResponse ? 'succeeded' : '',
          error => status = 'failed'
        ),
        // Logging request when observable either completes or errors
        finalize(() => {
          const msg = `${req.method} "${req.urlWithParams}"
          ${req.body ? JSON.stringify(req.body) : ''} ${status} in ${Date.now() - currentDate} ms.`;
          // tslint:disable-next-line:no-console
          console.info(msg);
        })
      );
  }
}
