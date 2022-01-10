import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { CommodityResponse } from 'src/app/models/commodityResponse';
import { environment } from 'src/environments/environment';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class CommodityService {

  constructor(private http: HttpClient) { }

  get(): Observable<CommodityResponse[]> {
    return this.http
      .get<CommodityResponse[]>(
        `${environment.apiUrl}Commodity`
      );
  }
}
