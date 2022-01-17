import { Component, OnInit, ViewChild } from '@angular/core';
import { TradeService } from 'src/app/services/trade/trade.service';
import { Observable } from 'rxjs';
import { TradeResponse } from 'src/app/models/tradeResponse';
import { ChartSourceResponse } from 'src/app/models/chartSourceResponse';
import { CommodityService } from 'src/app/services/commodity/commodity.service';
import { CommodityResponse } from 'src/app/models/commodityResponse';
import { TradingModelTrades } from 'src/app/models/tradingModelTrades';
import { MatDatepickerInputEvent } from '@angular/material/datepicker';
import { MatTableDataSource } from '@angular/material/table';
import { MatSort } from '@angular/material/sort';
import { MatPaginator } from '@angular/material/paginator';

@Component({
  selector: 'app-key-metrics',
  templateUrl: './key-metrics.component.html',
  styleUrls: ['./key-metrics.component.scss']
})

export class KeyMetricsComponent implements OnInit {

  displayedColumns: string[] = ['commodity', 'tradingModel','date', 'newTradeAction','contract', 'price', 'position','pnLDaily'];
   
  tradingModelTrades: TradingModelTrades[] = [];
  commodities: CommodityResponse[] = [];
  selectedDateFrom = new Date(new Date().setDate(new Date().getDate() - 5));
  selectedCommodityId: number;

  constructor(private tradeService: TradeService,
    private commodityService: CommodityService) { }

  ngOnInit(): void {

    this.commodityService.get().subscribe((response: CommodityResponse[]) => {
      this.commodities = response;
      this.selectedCommodityId = this.commodities[0].id;      
    });

  }
  commodityItemSelected() {
    this.loadHistoricalActions();
  }

  private loadHistoricalActions() {
    this.tradeService.getByDateAndCommodity(this.selectedDateFrom.toLocaleDateString(), this.selectedCommodityId).subscribe((response: TradingModelTrades[]) => {
      this.tradingModelTrades = response;
    });
  }


  dateFromChanged(type: string, event: MatDatepickerInputEvent<Date>) {
    if(event.value){
      this.selectedDateFrom = event.value;
    }
    this.loadHistoricalActions();
  }

}
