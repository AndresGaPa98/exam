import { ArticleUpdateModel } from "./articleStore.model";

export interface ArticleClientModel{
    ArticleId: number;
    ClientId: string;
    Amount: number;
}
export interface ArticleClientUpdateModel extends ArticleClientModel{
    Id: number;
}
export interface ArticleClientCountModel{
    total: number;
}
export interface ArticleClientGetModel{
    id: number;
    articleId: number;
    date: string;
    article: ArticleUpdateModel
}
export interface ArticleClientPaginationModel{
    total: number;
    data: ArticleClientGetModel[];
}
export interface ArticleClientInsertResponseModel{
    id: number;
    articleId: number;
    clientId: string;
    date: string;
    amount: number;
}