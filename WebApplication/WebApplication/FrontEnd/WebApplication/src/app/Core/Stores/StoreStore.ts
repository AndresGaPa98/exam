import { Injectable } from "@angular/core";
import { StoreUpdateModel } from "../Models/store.model";
import { ArticleStoreGetModel } from "../Models/articleStore.model";

@Injectable({
    providedIn: 'root'
})
export class StoreStore {

    private selectedStore!: any;
    private selectedArticle!: any;
    constructor() {
    }
    setStore(newStore: any){
        this.selectedStore = newStore;
    }
    getStore(){
        return this.selectedStore;
    }
    setArticle(newArticle: any){
        this.selectedArticle = newArticle;
    }
    getArticle(){
        return this.selectedArticle;
    }

}