import { Injectable } from "@angular/core";
import { Observable } from "rxjs";
import { ClientType } from "../Enums/Client.enum";

@Injectable({
    providedIn: 'root'
})
export class AccountStore {
    private token!: string;
    private autentificado!: boolean;
    private userId!: string;
    private role!: string;
    constructor() {
    }

    isAdminAuthenticated(): Observable<boolean>{
        return Observable.create( (observer: any) => {
            let bandera = false;
            if(this.token != undefined && this.autentificado && this.role == ClientType.ADMIN) {
                bandera = true;
            }
            observer.next(bandera);
            observer.complete();
        });
    }
    isClientAuthenticated(): Observable<boolean>{
        return Observable.create( (observer: any) => {
            let bandera = false;
            if(this.token != undefined && this.autentificado && this.role == ClientType.CLIENT) {
                bandera = true;
            }
            observer.next(bandera);
            observer.complete();
        });
    }

    isAuthorized():boolean{
        return this.token != undefined && this.autentificado === true;
    }
    setRole(role: string){
        this.role = role;
    }
    setUserId(userId: string){
        this.userId = userId;
    }
    setAccessToken(token: string){
        this.token = token;
    }
    setAutentificado(autentificado: boolean){
        this.autentificado = autentificado;
    }
    getRole(){
        return this.role;
    }
    getUserId(){
        return this.userId;
    }
    getAutentificado(){
        return this.autentificado;
    }
    getAccessToken(): string{
        return this.token;
    }
}