import { HttpClientTestingModule } from '@angular/common/http/testing';
import { ComponentFixture, TestBed } from '@angular/core/testing';
import { CommodityService } from 'src/app/services/commodity/commodity.service';
import { TradeService } from 'src/app/services/trade/trade.service';
import { TradingModelService } from 'src/app/services/trading-model/trading-model.service';

import { HistoricalActionsComponent } from './historical-actions.component';

describe('HistoricalActionsComponent', () => {
  let component: HistoricalActionsComponent;
  let fixture: ComponentFixture<HistoricalActionsComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ HistoricalActionsComponent ],
      imports: [HttpClientTestingModule],
      providers: [TradeService, CommodityService, TradingModelService]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(HistoricalActionsComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
