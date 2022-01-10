import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { TradingModelResponse } from 'src/app/models/tradingModelResponse';
import { environment } from 'src/environments/environment';
import { Observable } from 'rxjs';


@Injectable({
  providedIn: 'root'
})
export class TradingModelService {

 
  constructor(private http: HttpClient) { }

  get(): Observable<TradingModelResponse[]> {
    return this.http
      .get<TradingModelResponse[]>(
        `${environment.apiUrl}TradingModel`
      );
  }
}
