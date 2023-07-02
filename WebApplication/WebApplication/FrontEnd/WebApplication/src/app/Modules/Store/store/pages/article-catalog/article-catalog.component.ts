import { Component, OnInit } from '@angular/core';
import { PageEvent } from '@angular/material/paginator';
import { MatTableDataSource } from '@angular/material/table';
import { Router } from '@angular/router';
import { StoreUpdateModel } from 'src/app/Core/Models/store.model';
import { StoreService } from 'src/app/Core/Services/Store/store.service';
import { ArticleStoreService } from 'src/app/Core/Services/articleStore/article-store.service';
import { StoreStore } from 'src/app/Core/Stores/StoreStore';
import { ArticleStoreGetModel, ArticleStoreUpdateModel } from '../../../../../Core/Models/articleStore.model';

@Component({
  selector: 'app-article-catalog',
  templateUrl: './article-catalog.component.html',
  styleUrls: ['./article-catalog.component.css']
})
export class ArticleCatalogComponent implements OnInit {
  displayedColumns: string[] = [ 'urlImage','code', 'description', 'price',  'stock', 'actions'];
  dataSource = new MatTableDataSource<any>();
  totalItems: number = 0;
  index: number = 0;
  size: number = 5;
  constructor(private articleStoreService: ArticleStoreService, 
    private storeStore: StoreStore,
    private route: Router) { }

  ngOnInit(): void {
    this.onReload({Index: this.index, Size: this.size });
  }
  public onPageChange(event: PageEvent) {
    this.size = event.pageSize;
    this.index = event.pageIndex;
    this.onReload({Index: this.index, Size: this.size });
  }
  private onReload(filter: any){
    filter.Index = filter.Index * filter.Size;
    filter.Id = this.storeStore.getStore().storeId;
    this.articleStoreService.getByPagination(filter).subscribe(
      res => {

          this.totalItems = res.total;
          this.dataSource = new MatTableDataSource(res.data as ArticleStoreGetModel[]);

      },
      error => {
        console.error(error);
      }
  );
  }
  public goToAdd(){
    this.route.navigate(['article/add']);
  }
  public update(item: ArticleStoreGetModel){
    this.storeStore.setArticle(item);
    this.route.navigate(["article/update"]);
  }
  public delete(item: ArticleStoreGetModel){
    this.articleStoreService.delete(item.articleId).subscribe(
      res => {  
        this.onReload({Index: this.index, Size: this.size });
      },
      error => {
        console.error(error);
      }
  );
  }

}
