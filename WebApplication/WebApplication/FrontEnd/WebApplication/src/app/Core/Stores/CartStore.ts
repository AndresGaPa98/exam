import { Injectable } from "@angular/core";
import { BehaviorSubject, Observable } from "rxjs";

@Injectable({
    providedIn: 'root'
})
export class CartStore {
    private numberElements = new BehaviorSubject(0);
    getNumberElements = this.numberElements.asObservable();
    constructor() {
    }

    setNumberElements(newNumberElements: number){
        this.numberElements.next(newNumberElements);
    }

}