import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-historical-trend',
  templateUrl: './historical-trend.component.html',
  styleUrls: ['./historical-trend.component.scss']
})
export class HistoricalTrendComponent implements OnInit {


  multi = [
    {
      name: 'Temperature',
      series: [{
        value: 22,
        name: '2021-06-01 10:45:00+00'
      },
      {
        value: 33,
        name: '2021-06-01 11:14:44+00'
      },
      {
        value: 11,
        name: '2021-06-01 13:45:00+00'
      }]
    }];


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

 public colorScheme = {
  domain: ['rgba(255,255,255,0.8)']
}; 

  constructor() { }

  ngOnInit(): void {
  }

}
