import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-key-metrics',
  templateUrl: './key-metrics.component.html',
  styleUrls: ['./key-metrics.component.scss']
})

export class KeyMetricsComponent implements OnInit {
  multi = [
    {
      "name": "Model 1",
      "series": [
        {
          "name": new Date("01/01/2018"),
          "value": 0
        },
        {
          "name": new Date("02/01/2018"),
          "value": 31495.72
        },
        {
          "name": new Date("03/01/2018"),
          "value": 31346.34
        },
        {
          "name": new Date("04/01/2018"),
          "value": 31295.87
        },
        {
          "name": "05/01/2018",
          "value": 31432.13
        }
      ]
    },

  
    
    
  ];
  


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

  constructor() {
  }

  
  ngOnInit(): void {
  }

}
