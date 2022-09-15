import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { environment } from 'src/environments/environment';

@Injectable({
  providedIn: 'root'
})
export class CardService {

  constructor(private httpClient: HttpClient,) { }

  addCard(url:any,obj:any): Observable<any>{
    return this.httpClient.post(url,obj);
  }
  getCard(url:any): Observable<any>{
     return this.httpClient.get(url)
  }
  payBill(url:any,obj:any): Observable<any>{
    return this.httpClient.post(url,obj);
  }
  getPaymentDetail(url:any): Observable<any>{
    return this.httpClient.get(url)
  }
}
