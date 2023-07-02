import { Injectable } from '@angular/core';
import {
    HttpHeaders,
    HttpParams,
    HttpClient
} from '@angular/common/http';
import {
    Observable,
    throwError
} from 'rxjs';
import { catchError } from 'rxjs/operators';
import { ApiRouting } from './api-routing';

@Injectable({
    providedIn: 'root'
  })
export class ApiService {

    constructor(
        private http: HttpClient
    ) { }
    get_blob(path: string, params: HttpParams = new HttpParams(), headers: HttpHeaders = new HttpHeaders()): Observable<any> {
        return this.http.get(`${ApiRouting.api_url}${path}`,
            { params: params, headers: headers, responseType: 'blob', observe: 'response' })
            .pipe(catchError(this.formatErrors));
    }

    get_blob_post(path: string, body: Object = {}, params: HttpParams = new HttpParams(), headers: HttpHeaders = new HttpHeaders()): Observable<any> {
        return this.http.post(`${ApiRouting.api_url}${path}`,
            body,
            { params: params, headers: headers, responseType: 'blob', observe: 'response' })
            .pipe(catchError(this.formatErrors));
    }

    get(path: string, params: HttpParams = new HttpParams(), headers: HttpHeaders = new HttpHeaders()): Observable<any> {
        return this.http.get(`${ApiRouting.api_url}${path}`,
            { params: params, headers: headers })
            .pipe(catchError(this.formatErrors));
    }
    getAPI(path: string, params: HttpParams = new HttpParams(), headers: HttpHeaders = new HttpHeaders()): Observable<any> {
        return this.http.get(`${path}`,
            { params: params, headers: headers })
            .pipe(catchError(this.formatErrors));
    }


    put(path: string, body: Object = {}, params: HttpParams = new HttpParams(), headers: HttpHeaders = new HttpHeaders): Observable<any> {
        return this.http.put(`${ApiRouting.api_url}${path}`,
            body,
            { params: params, headers: headers })
            .pipe(catchError(this.formatErrors));
    }

    post(path: string, body: Object = {}, params: HttpParams = new HttpParams(), headers: HttpHeaders = new HttpHeaders): Observable<any> {
        return this.http.post(`${ApiRouting.api_url}${path}`,
            body,
            { params: params, headers: headers })
            .pipe(catchError(async (err) => await console.log(err)));
    }
    postAPI(path: string, body: Object = {}, params: HttpParams = new HttpParams(), headers: HttpHeaders = new HttpHeaders): Observable<any> {
        return this.http.post(`${path}`,
            body,
            { params: params, headers: headers })
            .pipe(catchError(async (err) => await console.log(err)));
    }

    delete(path: string, params: HttpParams = new HttpParams(), headers: HttpHeaders = new HttpHeaders): Observable<any> {
        return this.http.delete(`${ApiRouting.api_url}${path}`,
            { params: params, headers: headers })
            .pipe(catchError(this.formatErrors));
    }
    request(method: string,path: string, body?: any, headers: HttpHeaders = new HttpHeaders, params: HttpParams = new HttpParams()): Observable<any> {
        return this.http.request(method, `${ApiRouting.api_url}${path}`, {
            body: body,
            headers: headers,
            params: params
        }).pipe(catchError(this.formatErrors));
    }

    private formatErrors(error: any) {
        return throwError(error.error);
    }
}
