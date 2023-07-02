import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { HomeStoreComponent } from './pages/home-store/home-store.component';
import { StoreRoutingModule } from './store.routing.module';
import { ProductsComponent } from './pages/products/products.component';
import { MatPaginatorModule } from '@angular/material/paginator';
import { MatCardModule} from '@angular/material/card';
import { MatTableModule } from '@angular/material/table';
import { CartComponent } from './pages/cart/cart.component';
import { StoreCatalogComponent } from './pages/store-catalog/store-catalog.component';
import { AddStoreComponent } from './pages/store-catalog/components/add-store/add-store.component';
import { FormsModule } from '@angular/forms';
import { UpdateStoreComponent } from './pages/store-catalog/components/update-store/update-store.component';
import { ArticleCatalogComponent } from './pages/article-catalog/article-catalog.component';
import { UpdateArticleComponent } from './pages/article-catalog/components/update-article/update-article.component';
import { AddArticleComponent } from './pages/article-catalog/components/add-article/add-article.component';



@NgModule({
  declarations: [
    HomeStoreComponent,
    ProductsComponent,
    CartComponent,
    StoreCatalogComponent,
    AddStoreComponent,
    UpdateStoreComponent,
    ArticleCatalogComponent,
    UpdateArticleComponent,
    AddArticleComponent
  ],
  imports: [
    CommonModule,
    StoreRoutingModule,
    MatPaginatorModule,
    MatCardModule,
    MatTableModule,
    FormsModule
  ],
  providers: [
  ]
})
export class StoreModule { }
