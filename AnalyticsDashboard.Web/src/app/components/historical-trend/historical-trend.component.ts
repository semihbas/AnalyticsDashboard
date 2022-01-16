import { Component, OnInit } from '@angular/core';
import { ChartSourceResponse } from 'src/app/models/chartSourceResponse';
import { CommodityResponse } from 'src/app/models/commodityResponse';
import { CommodityService } from 'src/app/services/commodity/commodity.service';
import { TradeService } from 'src/app/services/trade/trade.service';

@Component({
  selector: 'app-historical-trend',
  templateUrl: './historical-trend.component.html',
  styleUrls: ['./historical-trend.component.scss']
})
export class HistoricalTrendComponent implements OnInit {

  chartSource: any;

  commodities: CommodityResponse[] = [];
  selectedCommodityId: number;

  // options
  legend: boolean = true;
  showLabels: boolean = true;
  animations: boolean = true;
  xAxis: boolean = true;
  yAxis: boolean = true;
  showYAxisLabel: boolean = true;
  showXAxisLabel: boolean = true;
  xAxisLabel: string = 'Date';
  yAxisLabel: string = 'Price';
  timeline: boolean = true;

  colorScheme = {
    domain: ['#5AA454', '#E44D25', '#CFC0BB', '#7aa3e5', '#a8385d', '#aae3f5']
  };

  constructor(private tradeService: TradeService
    , private commodityService: CommodityService) {
  }


  ngOnInit(): void {
    this.commodityService.get().subscribe(response => {
      this.commodities = response;
      this.selectedCommodityId = this.commodities[0].id;
      this.commodityItemSelected(this.selectedCommodityId);
    });

  }

  commodityItemSelected(commodityId: number) {
    this.tradeService.GetChartSourceByCommodity(commodityId).subscribe((response: ChartSourceResponse[]) => {
      this.chartSource = response;
    });
  }
}
