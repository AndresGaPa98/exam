import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { ApiRouting } from '../api/api-routing';
import { ApiService } from '../api/api.service';
import { ArticleStorePaginationModel } from '../../Models/articleStore.model';
import { StoreModel, StorePaginationModel, StoreUpdateModel } from '../../Models/store.model';


@Injectable({
  providedIn: 'root'
})
export class StoreService {

  constructor(
    private apiService: ApiService,
  ) { }

  delete(id: number): Observable<boolean>{
    return this.apiService.delete(`/${ApiRouting.store}/${ApiRouting.delete}/${id}`);
  }
  insert(item: StoreModel): Observable<StoreUpdateModel>{
    return this.apiService.post(`/${ApiRouting.store}/${ApiRouting.insert}`, item);
  }
  update(item: StoreUpdateModel): Observable<StoreUpdateModel>{
    return this.apiService.put(`/${ApiRouting.store}/${ApiRouting.update}`, item);
  }
  getPaginationStores(filter: any): Observable<StorePaginationModel> {
      return this.apiService.post(`/${ApiRouting.store}/${ApiRouting.getByPagination}`, filter);
  }
}
