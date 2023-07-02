import { Component, OnInit } from '@angular/core';
import { PageEvent } from '@angular/material/paginator';
import { ArticleClientGetModel, ArticleClientPaginationModel, ArticleClientUpdateModel } from 'src/app/Core/Models/articleClient.model';
import { ArticleClientService } from 'src/app/Core/Services/articleClient/article-client.service';
import { ArticleStoreService } from 'src/app/Core/Services/articleStore/article-store.service';
import { AccountStore } from 'src/app/Core/Stores/AccountStore';
import { CartStore } from 'src/app/Core/Stores/CartStore';

@Component({
  selector: 'app-cart',
  templateUrl: './cart.component.html',
  styleUrls: ['./cart.component.css']
})
export class CartComponent implements OnInit {

  data!: ArticleClientPaginationModel;
  totalItems: number = 0;
  index: number = 0;
  size: number = 5;
  constructor(
    private articleClientService: ArticleClientService,
    private cartStore: CartStore,
    private accountStore: AccountStore) { }

  ngOnInit(): void {
    this.onReload({Index: this.index, Size: this.size });
  }
  public delete(item: ArticleClientGetModel){
    let valid = confirm('¿Desea eliminar el articulo del carrito?');
    if(!valid) return
    this.articleClientService.delete(item.id).subscribe(
      res => {  
        this.onReload({Index: this.index, Size: this.size });
        
      },
      error => {
        console.error(error);
      }
  );
  }
  public update(item: ArticleClientGetModel){
    if(item.article.amount! <= 0) return;
    if(item.article.amount! > item.article.stock) {
      window.alert("Por favor, seleccione una cantidad menor o igual al Stock");
      return;
    }
    const article: ArticleClientUpdateModel  = {Id : item.id ,ArticleId: item.articleId, ClientId: this.accountStore.getUserId(), Amount: item.article.amount! }

    this.articleClientService.update(article).subscribe(
      res => {
        this.onReload({Index: this.index, Size: this.size });
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
    this.articleClientService.getPaginationArticles(filter).subscribe(
      res => {

          this.totalItems = res.total;
          this.data = res;
          this.cartStore.setNumberElements(this.totalItems);
      },
      error => {
        console.error(error);
      }
  );
  }
}
