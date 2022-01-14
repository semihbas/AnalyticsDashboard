import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { TradeResponse } from 'src/app/models/tradeResponse';
import { environment } from 'src/environments/environment';
import { Observable } from 'rxjs';
import { ChartSourceResponse } from 'src/app/models/chartSourceResponse';
@Injectable({
  providedIn: 'root'
})
export class TradeService {

  constructor(private http: HttpClient) { }

  get(commodityId: number | null, tradingModelId: number | null) : Observable<TradeResponse[]> {
    return this.http
      .get<TradeResponse[]>(
        `${environment.apiUrl}Trade/GetByFilter?commodityId=${commodityId}&tradingModelId=${tradingModelId}`
      );
  }

  GetChartSourceByCommodity(commodityId: number) : Observable<any> {
    return this.http
      .get<TradeResponse[]>(
        `${environment.apiUrl}Trade/getChartSourceByCommodity?commodityId=${commodityId}`
      );
  }

}
