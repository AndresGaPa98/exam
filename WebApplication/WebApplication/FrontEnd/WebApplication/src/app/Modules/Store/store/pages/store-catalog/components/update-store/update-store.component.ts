import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { StoreUpdateModel } from 'src/app/Core/Models/store.model';
import { StoreService } from 'src/app/Core/Services/Store/store.service';
import { StoreStore } from 'src/app/Core/Stores/StoreStore';

@Component({
  selector: 'app-update-store',
  templateUrl: './update-store.component.html',
  styleUrls: ['./update-store.component.css']
})
export class UpdateStoreComponent implements OnInit {

  public data!: any;
  constructor(private storeStore: StoreStore, private route: Router, private storeService: StoreService) { }

  ngOnInit(): void {
    this.data = this.storeStore.getStore() as StoreUpdateModel;
  }
  public update(){
    this.storeService.update(this.data).subscribe(res => {
      this.returnToStoresCatalog();
    },
    error => {
      console.error(error);
    });
  }
  public returnToStoresCatalog(){
    this.storeStore.setStore(null);
    this.route.navigate(['stores']);
  }

}
