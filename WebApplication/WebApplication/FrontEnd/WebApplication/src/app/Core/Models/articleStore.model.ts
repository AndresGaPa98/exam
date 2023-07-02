export interface ArticleModel{
    code: string;
    description: string;
    price: number;
    urlImage: string;
    stock: number;
    amount?: number;
  }
  export interface ArticleUpdateModel extends ArticleModel{
    id: number;
  }
  export interface ArticleStoreGetModel{
    id: number;
    storeId: number;
    articleId: number;
    date: string;
    
    article: ArticleUpdateModel;
  }
  export interface ArticleStorePaginationModel{
    total: number;
    data: ArticleStoreGetModel[]
  }
  export interface CartCount{
    total: number;
  }


  export interface ArticleUpperModel{
    Code: string;
    Description: string;
    Price: number;
    UrlImage: string;
    Stock: number;
  }
  export interface ArticleUpdateUpperModel extends ArticleModel{
    Id: number;
  }
  export interface ArticleStoreInsertModel{
    StoreId: number;
    Article: ArticleUpperModel;
  }
  export interface ArticleStoreUpdateModel{
    Id: number;
    StoreId: number;
    Article: ArticleUpdateUpperModel;
  }