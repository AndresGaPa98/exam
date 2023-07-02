import { NgModule } from '@angular/core';
import { RouterModule, Routes, CanActivate } from '@angular/router';
import { HomeStoreComponent } from './pages/home-store/home-store.component';

import { ProductsComponent } from './pages/products/products.component';
import { CartComponent } from './pages/cart/cart.component';
import { StoreCatalogComponent } from './pages/store-catalog/store-catalog.component';
import { UpdateStoreComponent } from './pages/store-catalog/components/update-store/update-store.component';
import { AddStoreComponent } from './pages/store-catalog/components/add-store/add-store.component';
import { ArticleCatalogComponent } from './pages/article-catalog/article-catalog.component';
import { UpdateArticleComponent } from './pages/article-catalog/components/update-article/update-article.component';
import { AddArticleComponent } from './pages/article-catalog/components/add-article/add-article.component';
import { AdminGuard } from 'src/app/Core/Guards/Admin.guard';
import { ClientGuard } from 'src/app/Core/Guards/Client.guard';

const routes: Routes = [
  {
    path: '',
    component: HomeStoreComponent,
    children: [
      {
        path: 'products',
        component: ProductsComponent
      },
      {
        path: 'cart',
        component: CartComponent,
        canActivate: [ClientGuard] 
      },
      {
        path: 'stores',
        component: StoreCatalogComponent, 
        canActivate: [AdminGuard] 
      },
      {
        path: 'store/update',
        component: UpdateStoreComponent,
        canActivate: [AdminGuard] 
      },
      {
        path: 'store/add',
        component: AddStoreComponent,
        canActivate: [AdminGuard] 
      },
      {
        path: 'articles',
        component: ArticleCatalogComponent,
        canActivate: [AdminGuard] 
        
      },
      {
        path: 'article/update',
        component: UpdateArticleComponent,
        canActivate: [AdminGuard]
      },
      {
        path: 'article/add',
        component: AddArticleComponent,
        canActivate: [AdminGuard] 
      },
      {
        path: '',
        redirectTo: 'products',
        pathMatch: 'full'
      }
    ]
  }

];

@NgModule({
  declarations: [],
  imports: [
    RouterModule.forChild(routes)
  ],
  exports:
  [
    RouterModule
  ]
})
export class StoreRoutingModule { }