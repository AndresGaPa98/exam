import { Component, OnInit } from '@angular/core';
import { PageEvent } from '@angular/material/paginator';
import { ArticleClientModel } from 'src/app/Core/Models/articleClient.model';
import { ArticleModel, ArticleStoreGetModel, ArticleStorePaginationModel } from 'src/app/Core/Models/articleStore.model';
import { ArticleClientService } from 'src/app/Core/Services/articleClient/article-client.service';
import { ArticleStoreService } from 'src/app/Core/Services/articleStore/article-store.service';
import { AccountStore } from 'src/app/Core/Stores/AccountStore';
import { CartStore } from 'src/app/Core/Stores/CartStore';


@Component({
  selector: 'app-products',
  templateUrl: './products.component.html',
  styleUrls: ['./products.component.css']
})
export class ProductsComponent implements OnInit {

  data!: ArticleStorePaginationModel;
  totalItems: number = 0;
  index: number = 0;
  size: number = 5;
  constructor(private articleStoreService: ArticleStoreService, 
    private articleClientService: ArticleClientService,
    private accountStore: AccountStore,
    private cartStore: CartStore) { }

  ngOnInit(): void {
    this.onReload({Index: this.index, Size: this.size });
    this.getCount();
  }
  public addToCart(item: ArticleStoreGetModel){
    if(!this.accountStore.isAuthorized()){
      window.alert("Por favor, si quiere guardar en el carrito inicie sesión");
      return;
    }
    if(item.article.amount! <= 0) return;
    if(item.article.amount! > item.article.stock) {
      window.alert("Por favor, seleccione una cantidad menor o igual al Stock");
      return;
    }
    const article: ArticleClientModel  = { ArticleId: item.articleId, ClientId: this.accountStore.getUserId(), Amount: item.article.amount! }
    this.articleClientService.insert(article).subscribe(
      res => {
        this.getCount();
      },
      error => {
        console.error(error);
      }
  );
  }
  private getCount(){
      this.articleClientService.getCountCart().subscribe(
        res => {
           this.cartStore.setNumberElements(res.total);
        },
        error => {
          console.error(error);
        }
    );
  }
  public onPageChange(event: PageEvent) {
    this.size = event.pageSize;
    this.index = event.pageIndex;
    this.onReload({Index: this.index, Size: this.size });
  }
  private onReload(filter: any){
    filter.Index = filter.Index * filter.Size;
    this.articleStoreService.getPaginationArticles(filter).subscribe(
      res => {

          this.totalItems = res.total;
          this.data = res;

      },
      error => {
        console.error(error);
      }
  );
  }

}
