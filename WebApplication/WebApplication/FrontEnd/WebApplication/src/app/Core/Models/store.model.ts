export interface StoreModel{
    BranchName: string;
    Address: string;
}
export interface StoreUpdateModel extends StoreModel{
    StoreId: number;
}
export interface StorePaginationModel{
    total: number;
    data: StoreUpdateModel[];
}