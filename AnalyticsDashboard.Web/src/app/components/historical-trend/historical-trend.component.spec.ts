import { HttpClientTestingModule } from '@angular/common/http/testing';
import { ComponentFixture, TestBed } from '@angular/core/testing';
import { MatCardModule } from '@angular/material/card';
import { CommodityService } from 'src/app/services/commodity/commodity.service';
import { TradeService } from 'src/app/services/trade/trade.service';

import { HistoricalTrendComponent } from './historical-trend.component';

describe('HistoricalTrendComponent', () => {
  let component: HistoricalTrendComponent;
  let fixture: ComponentFixture<HistoricalTrendComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ HistoricalTrendComponent ],
      imports: [MatCardModule,HttpClientTestingModule],
      providers: [TradeService, CommodityService]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(HistoricalTrendComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
