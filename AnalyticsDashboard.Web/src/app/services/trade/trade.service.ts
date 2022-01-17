import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { TradeResponse } from 'src/app/models/tradeResponse';
import { environment } from 'src/environments/environment';
import { Observable } from 'rxjs';
import { ChartSourceResponse } from 'src/app/models/chartSourceResponse';
import { TradingModelTrades } from 'src/app/models/tradingModelTrades';
@Injectable({
  providedIn: 'root'
})
export class TradeService {

  constructor(private http: HttpClient) { }

  get(selectedDateFrom: Date, commodityId: number | null, tradingModelId: number | null): Observable<TradeResponse[]> {
    return this.http
      .get<TradeResponse[]>(
        `${environment.apiUrl}Trade/GetByFilter?fromDate=${selectedDateFrom}&commodityId=${commodityId}&tradingModelId=${tradingModelId}`
      );
  }

  getChartSourceByCommodity(commodityId: number): Observable<any> {
    return this.http
      .get<TradeResponse[]>(
        `${environment.apiUrl}Trade/getChartSourceByCommodity?commodityId=${commodityId}`
      );
  }

  getByDateAndCommodity(fromDate: string, commodityId: number) : Observable<TradingModelTrades[]> {
    return this.http
    .get<TradingModelTrades[]>(
      `${environment.apiUrl}Trade/getByDateAndCommodity?fromDate=${fromDate}&commodityId=${commodityId}`
    );
  }
}

