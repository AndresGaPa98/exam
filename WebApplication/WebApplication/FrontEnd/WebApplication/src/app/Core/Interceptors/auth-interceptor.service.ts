import { Injectable } from '@angular/core';
import { HttpInterceptor, HttpRequest, HttpHandler, HttpEvent } from '@angular/common/http';
import { Observable } from 'rxjs';
import {Router} from '@angular/router';
import { AccountStore } from '../Stores/AccountStore';


@Injectable({
    providedIn: 'root'
})
export class AuthInterceptorService implements HttpInterceptor {

    constructor(private route: Router, private accountStore: AccountStore) {}

    intercept(req: HttpRequest<any>, next: HttpHandler): Observable<HttpEvent<any>> {
        const token = this.accountStore.getAccessToken();
        const autentificado = this.accountStore.getAutentificado();
        let request = req;
        if (token != undefined && autentificado) {
            request = req.clone({
                setHeaders: {
                    authorization: `Bearer ${ token  }`
                }
            });
        }

        return next.handle(request);
    }

}
