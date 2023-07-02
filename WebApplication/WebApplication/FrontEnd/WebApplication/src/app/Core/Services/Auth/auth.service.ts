import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { ApiRouting } from '../api/api-routing';
import { ApiService } from '../api/api.service';
import { AuthorizeModel, LoginResponseModel } from '../../Models/authorize.model';

@Injectable({
  providedIn: 'root'
})
export class AuthService {

  constructor(
    private apiService: ApiService,

) { }
postLogin(model: AuthorizeModel): Observable<LoginResponseModel> {
    return this.apiService.post(`/${ApiRouting.auth}/${ApiRouting.login}`, model);
}
logout(): Observable<LoginResponseModel> {
  return this.apiService.get(`/${ApiRouting.auth}/${ApiRouting.logout}`);
}
}
