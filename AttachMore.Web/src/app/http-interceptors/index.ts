import { HttpErrorInterceptor } from './http-error.interceptor';
import { LoaderInterceptor } from './loader.interceptor';
import { TokenAppenderInterceptor } from './token-appender.interceptor';
import { LoggingInterceptor } from './logging.interceptor';
import { HTTP_INTERCEPTORS } from '@angular/common/http';

export const HTTP_INTERCEPTORS_PROVIDERS = [
    { provide: HTTP_INTERCEPTORS, useClass: HttpErrorInterceptor, multi: true },
    { provide: HTTP_INTERCEPTORS, useClass: LoaderInterceptor, multi: true },
    { provide: HTTP_INTERCEPTORS, useClass: TokenAppenderInterceptor, multi: true },
    { provide: HTTP_INTERCEPTORS, useClass: LoggingInterceptor, multi: true },
];
