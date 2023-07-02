import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { ClientType } from 'src/app/Core/Enums/Client.enum';
import { AuthService } from 'src/app/Core/Services/Auth/auth.service';
import { AccountStore } from 'src/app/Core/Stores/AccountStore';
import { CartStore } from 'src/app/Core/Stores/CartStore';

@Component({
  selector: 'app-home-store',
  templateUrl: './home-store.component.html',
  styleUrls: ['./home-store.component.css']
})
export class HomeStoreComponent implements OnInit {

  public isLogged: boolean = false;
  public clientType = ClientType;
  public clientRole: string = '';
  public CartCount: number = 0;
  constructor(private router: Router, 
    private accountStore: AccountStore,
    private cartStore: CartStore,
    private authService: AuthService) {
    this.cartStore.getNumberElements.subscribe(count => this.CartCount = count);
    
   }

  ngOnInit(): void {
    this.isLogged = this.accountStore.isAuthorized();
    this.clientRole = this.accountStore.getRole();
  }
  public goHome(){
    this.router.navigate(['']);
  }
  public logOut(){
    this.authService.logout().subscribe(res => {
        this.accountStore.setAccessToken('');
        this.accountStore.setAutentificado(false);
        this.accountStore.setRole('');
        this.accountStore.setUserId('');
        this.router.navigate(['Auth']);
    }, error => {
      console.error(error);
    });
  }
  public redirectToLogin(){
    this.router.navigate(['/Auth']);
  }
  public redirectToCart(){
    this.router.navigate(['/cart']);
  }
  public redirectToStores(){
    this.router.navigate(['/stores']);
  }
}
