import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { ApiRouting } from '../api/api-routing';
import { ApiService } from '../api/api.service';
import { ArticleStorePaginationModel, CartCount } from '../../Models/articleStore.model';
import { ArticleClientInsertResponseModel, ArticleClientModel, ArticleClientPaginationModel, ArticleClientUpdateModel } from '../../Models/articleClient.model';


@Injectable({
  providedIn: 'root'
})
export class ArticleClientService {

  constructor(
    private apiService: ApiService,
  ) { }

  insert(model: ArticleClientModel): Observable<ArticleClientInsertResponseModel>{
    return this.apiService.post(`/${ApiRouting.articleClient}/${ApiRouting.insert}`, model);
  }

  update(model: ArticleClientUpdateModel): Observable<ArticleClientInsertResponseModel>{
    return this.apiService.put(`/${ApiRouting.articleClient}/${ApiRouting.update}`, model);
  }
  delete(id: number): Observable<boolean>{
    return this.apiService.delete(`/${ApiRouting.articleClient}/${ApiRouting.delete}/${id}`);
  }
  getPaginationArticles(filter: any): Observable<ArticleClientPaginationModel> {
      return this.apiService.post(`/${ApiRouting.articleClient}/${ApiRouting.getByPagination}`, filter);
  }
  getCountCart(): Observable<CartCount>{
    return this.apiService.get(`/${ApiRouting.articleClient}/${ApiRouting.getCount}`);
  }
}
