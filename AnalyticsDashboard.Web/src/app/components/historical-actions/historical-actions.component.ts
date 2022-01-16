import { AfterViewInit, Component, OnInit, ViewChild } from '@angular/core';
import { MatPaginator } from '@angular/material/paginator';
import { MatSort } from '@angular/material/sort';
import { MatTableDataSource } from '@angular/material/table';
import { CommodityResponse } from 'src/app/models/commodityResponse';
import { TradeResponse } from 'src/app/models/tradeResponse';
import { TradingModelResponse } from 'src/app/models/tradingModelResponse';
import { CommodityService } from 'src/app/services/commodity/commodity.service';
import { TradeService } from 'src/app/services/trade/trade.service';
import { TradingModelService } from 'src/app/services/trading-model/trading-model.service';

@Component({
  selector: 'app-historical-actions',
  templateUrl: './historical-actions.component.html',
  styleUrls: ['./historical-actions.component.scss']
})
export class HistoricalActionsComponent implements OnInit {
  displayedColumns: string[] = ['commodity', 'tradingModel', 'newTradeAction'];
  dataSource: MatTableDataSource<TradeResponse>;
  @ViewChild(MatPaginator) paginator: MatPaginator;
  @ViewChild(MatSort) sort: MatSort;

  selectedDateFrom = new Date(new Date().setDate(new Date().getDate() - 5));

  tradingModels: TradingModelResponse[] = [];
  commodities: CommodityResponse[] = [];


  selectedCommodityId: number;
  selectedTradingModelId: number | null;

  constructor(private tradeService: TradeService,
    private commodityService: CommodityService,
    private tradingModelService: TradingModelService) { }

  ngOnInit(): void {

    this.commodityService.get().subscribe((response: CommodityResponse[]) => {
      this.commodities = response;
    });

    this.tradingModelService.get().subscribe((response: TradingModelResponse[]) => {
      this.tradingModels = response;
    });

  }
  commodityItemSelected() {
    this.selectedTradingModelId = null;
    this.loadHistoricalActions();

  }

  private loadHistoricalActions() {
    this.tradeService.get(this.selectedDateFrom, this.selectedCommodityId, this.selectedTradingModelId).subscribe((response: TradeResponse[] | undefined) => {
      this.dataSource = new MatTableDataSource(response);
      this.dataSource.paginator = this.paginator;
      this.dataSource.sort = this.sort;
    });
  }

  tradingModelItemSelected() {
    this.loadHistoricalActions();
  }

  dateFromChanged() {
    this.loadHistoricalActions();
  }

}
