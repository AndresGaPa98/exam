import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { StoreUpdateModel } from 'src/app/Core/Models/store.model';
import { ArticleStoreService } from 'src/app/Core/Services/articleStore/article-store.service';
import { StoreStore } from 'src/app/Core/Stores/StoreStore';

@Component({
  selector: 'app-update-article',
  templateUrl: './update-article.component.html',
  styleUrls: ['./update-article.component.css']
})
export class UpdateArticleComponent implements OnInit {
  public data!: any;
  constructor(private storeStore: StoreStore, private route: Router, private articleStoreService: ArticleStoreService) { }

  ngOnInit(): void {
    this.data = this.storeStore.getArticle();
  }
  public update(){
    this.articleStoreService.update(this.data).subscribe(res => {
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
