import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { StoreModel, StoreUpdateModel } from 'src/app/Core/Models/store.model';
import { StoreService } from 'src/app/Core/Services/Store/store.service';
import { StoreStore } from 'src/app/Core/Stores/StoreStore';

@Component({
  selector: 'app-add-store',
  templateUrl: './add-store.component.html',
  styleUrls: ['./add-store.component.css']
})
export class AddStoreComponent implements OnInit {
  public data!: StoreModel;
  constructor(private route: Router, private storeService: StoreService) { }

  ngOnInit(): void {
    this.data = {
      Address: '',
      BranchName: ''
    };
  }
  public insert(){
    this.storeService.insert(this.data).subscribe(res => {
      this.returnToStoresCatalog();
    },
    error => {
      console.error(error);
    });
  }
  public returnToStoresCatalog(){
    this.route.navigate(['stores']);
  }
}
