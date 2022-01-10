import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { TradeResponse } from 'src/app/models/tradeResponse';
import { environment } from 'src/environments/environment';
import { Observable } from 'rxjs';
@Injectable({
  providedIn: 'root'
})
export class TradeService {

  constructor(private http: HttpClient) { }

  get(skip :number, take: number, commodityId: number | null, tradingModelId: number | null) : Observable<TradeResponse[]> {
    return this.http
      .get<TradeResponse[]>(
        `${environment.apiUrl}Trade/GetByFilter?skip=${skip}&take=${take}&commodityId=${commodityId}&tradingModelId=${tradingModelId}`
      );
  }

}
