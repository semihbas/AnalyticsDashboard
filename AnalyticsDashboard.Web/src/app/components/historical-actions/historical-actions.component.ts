import { AfterViewInit, Component, OnInit, ViewChild } from '@angular/core';
import { MatPaginator } from '@angular/material/paginator';
import { MatSort } from '@angular/material/sort';
import { MatTableDataSource } from '@angular/material/table';
import { CommodityResponse } from 'src/app/models/commodityResponse';
import { TradeResponse } from 'src/app/models/tradeResponse';
import { TradingModelResponse } from 'src/app/models/tradingModelResponse';
import { CommodityService } from 'src/app/services/commodity/commodity.service';
import { TradingModelService } from 'src/app/services/trading-model/trading-model.service';

@Component({
  selector: 'app-historical-actions',
  templateUrl: './historical-actions.component.html',
  styleUrls: ['./historical-actions.component.scss']
})
export class HistoricalActionsComponent implements OnInit, AfterViewInit {
  displayedColumns: string[] = ['tradingModel', 'commodity', 'newTradeAction'];
  dataSource: MatTableDataSource<TradeResponse>;
  @ViewChild(MatPaginator) paginator: MatPaginator;
  @ViewChild(MatSort) sort: MatSort;

  tradingModels: TradingModelResponse[] = [];
  commodities: CommodityResponse[] = [];


  selectedCommodity: CommodityResponse;
  selectedTradingModel: TradingModelService;

  constructor() { }

  ngOnInit(): void {



    this.dataSource = new MatTableDataSource();

  }

  ngAfterViewInit() {
    this.dataSource.paginator = this.paginator;
    this.dataSource.sort = this.sort;
  }

}
