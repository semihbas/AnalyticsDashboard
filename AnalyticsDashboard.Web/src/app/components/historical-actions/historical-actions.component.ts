import { Component, OnInit, ViewChild } from '@angular/core';
import { MatPaginator } from '@angular/material/paginator';
import { MatSort } from '@angular/material/sort';
import { MatTableDataSource } from '@angular/material/table';

@Component({
  selector: 'app-historical-actions',
  templateUrl: './historical-actions.component.html',
  styleUrls: ['./historical-actions.component.scss']
})
export class HistoricalActionsComponent implements OnInit {
  displayedColumns: string[] = [ 'tradingModel', 'commodity', 'newTradeAction'];
  dataSource: MatTableDataSource<UserData>;

  @ViewChild(MatPaginator) paginator: MatPaginator;
  @ViewChild(MatSort) sort: MatSort;
  
  constructor() { }

  ngOnInit(): void {
  }

}
