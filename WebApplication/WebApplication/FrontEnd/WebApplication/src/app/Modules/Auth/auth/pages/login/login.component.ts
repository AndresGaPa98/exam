import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { AuthorizeModel } from 'src/app/Core/Models/authorize.model';
import { AuthService } from 'src/app/Core/Services/Auth/auth.service';
import { AccountStore } from 'src/app/Core/Stores/AccountStore';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent implements OnInit {
  public form!: FormGroup;
  public errors: string = '';
  public procesando: boolean = false;
  constructor(private _builder: FormBuilder,
    private authService: AuthService,
    private accountStore: AccountStore,
    private activatedRoute: ActivatedRoute,
    private router: Router,) { }

  ngOnInit(): void {
    this.createForm();
    }
    createForm(){
      this.form = this._builder.group({
        userName: ['', Validators.required],
        password: ['', Validators.required],
      });
    }

  onSubmit(){
    this.errors = '';
    this.procesando = true;
   
    var model = {UserName: this.form.get('userName')?.value,
                 Password: this.form.get('password')?.value} as AuthorizeModel;
      this.authService.postLogin(model).subscribe(data => {
          if(data.autentificado){
              this.accountStore.setRole(data.role);
              this.accountStore.setUserId(data.userId);
              this.accountStore.setAccessToken(data.accessToken);
              this.accountStore.setAutentificado(true);
              this.router.navigate(['/products']);
          }
         else{
              this.errors = 'Usuario y/o contraseña errónea.'
              this.procesando =false;
         }
      }, error => {
        console.log(error); 
        this.errors = 'Usuario y/o contraseña errónea.'
        this.procesando =false;})
  }
}
