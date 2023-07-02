import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { ArticleStoreService } from 'src/app/Core/Services/articleStore/article-store.service';
import { StoreStore } from 'src/app/Core/Stores/StoreStore';

@Component({
  selector: 'app-add-article',
  templateUrl: './add-article.component.html',
  styleUrls: ['./add-article.component.css']
})
export class AddArticleComponent implements OnInit {
  public data!: any;
  constructor(private storeStore: StoreStore, private route: Router, private articleStoreService: ArticleStoreService) { }

  ngOnInit(): void {
    this.data = {
      storeId: this.storeStore.getStore().storeId,
      article: {code: '',
              description: '',
              price: 0,
              stock: 0,
              urlImage: ''
    }

    };
  }
  public update(){
    this.articleStoreService.insert(this.data).subscribe(res => {
      this.returnToStoresCatalog();
    },
    error => {
      console.error(error);
    });
  }
  public returnToStoresCatalog(){
    this.storeStore.setArticle(null);
    this.route.navigate(['articles']);
  }

}
