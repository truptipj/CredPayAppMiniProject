import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class CardService {

  constructor(private httpClient: HttpClient,) { }

  addCard(url:any,obj:any): Observable<any>{
    return this.httpClient.post(`CardDetails`,obj);

    // return this.httpClient.post(`${environment.baseUrl}CardDetails`,obj);
  }
  getCard(): Observable<any>{
     return this.httpClient.get(`CardDetails`)

    // return this.httpClient.get(`${environment.baseUrl}CardDetails`)
  }
  payBill(url:any,obj:any): Observable<any>{
    return this.httpClient.post(`CardDetails`,obj);

    // return this.httpClient.post(`${environment.baseUrl}CardDetails`,obj);
  }
}
