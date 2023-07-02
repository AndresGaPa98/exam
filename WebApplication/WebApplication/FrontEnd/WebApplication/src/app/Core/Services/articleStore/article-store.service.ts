import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { ApiRouting } from '../api/api-routing';
import { ApiService } from '../api/api.service';
import { ArticleStoreGetModel, ArticleStoreInsertModel, ArticleStorePaginationModel, ArticleStoreUpdateModel } from '../../Models/articleStore.model';


@Injectable({
  providedIn: 'root'
})
export class ArticleStoreService {

  constructor(
    private apiService: ApiService,
  ) { }

  insert(model: ArticleStoreInsertModel): Observable<ArticleStoreGetModel>{
    return this.apiService.post(`/${ApiRouting.articleStore}/${ApiRouting.insert}`, model);
  }

  update(model: ArticleStoreUpdateModel): Observable<ArticleStoreGetModel>{
    return this.apiService.put(`/${ApiRouting.articleStore}/${ApiRouting.update}`, model);
  }
  delete(id: number): Observable<boolean>{
    return this.apiService.delete(`/${ApiRouting.articleStore}/${ApiRouting.delete}/${id}`);
  }
  getPaginationArticles(filter: any): Observable<ArticleStorePaginationModel> {
      return this.apiService.post(`/${ApiRouting.articleStore}/${ApiRouting.getAllProductsPagination}`, filter);
  }
  getByPagination(filter: any): Observable<ArticleStorePaginationModel>{
    return this.apiService.post(`/${ApiRouting.articleStore}/${ApiRouting.getByPagination}`, filter);
  }
}
