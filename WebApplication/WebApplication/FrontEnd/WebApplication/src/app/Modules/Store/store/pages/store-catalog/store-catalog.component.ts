import { Component, OnInit } from '@angular/core';
import { PageEvent } from '@angular/material/paginator';
import {MatTableDataSource} from '@angular/material/table';
import { StoreService } from '../../../../../Core/Services/Store/store.service';
import { StoreUpdateModel } from 'src/app/Core/Models/store.model';
import { StoreStore } from 'src/app/Core/Stores/StoreStore';
import { Router } from '@angular/router';

@Component({
  selector: 'app-store-catalog',
  templateUrl: './store-catalog.component.html',
  styleUrls: ['./store-catalog.component.css']
})
export class StoreCatalogComponent implements OnInit {

  displayedColumns: string[] = [ 'BranchName', 'Address', 'actions'];
  dataSource = new MatTableDataSource<any>();
  totalItems: number = 0;
  index: number = 0;
  size: number = 5;
  constructor(private storeService: StoreService, 
    private storeStore: StoreStore,
    private route: Router) { }

  ngOnInit(): void {
    this.onReload({Index: this.index, Size: this.size });
  }
  public onPageChange(event: PageEvent) {
    this.size = event.pageSize;
    this.index = event.pageIndex;
    this.onReload({Index: this.index, Size: this.size });
  }
  private onReload(filter: any){
    filter.Index = filter.Index * filter.Size;
    this.storeService.getPaginationStores(filter).subscribe(
      res => {

          this.totalItems = res.total;
          this.dataSource = new MatTableDataSource(res.data as StoreUpdateModel[]);

      },
      error => {
        console.error(error);
      }
  );
  }
  public goToAdd(){
    this.route.navigate(['store/add']);
  }
  public goToArticles(item: StoreUpdateModel){
    this.storeStore.setStore(item);
    this.route.navigate(["articles"]);
  }
  public update(item: StoreUpdateModel){
    this.storeStore.setStore(item);
    this.route.navigate(["store/update"]);
  }
  public delete(item: any){
    this.storeService.delete(item.storeId).subscribe(
      res => {  
        this.onReload({Index: this.index, Size: this.size });
      },
      error => {
        console.error(error);
      }
  );
  }

}
