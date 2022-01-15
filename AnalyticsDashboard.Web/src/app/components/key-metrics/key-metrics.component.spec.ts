import { HttpClient } from '@angular/common/http';
import { HttpClientTestingModule, HttpTestingController } from '@angular/common/http/testing';
import { ComponentFixture, TestBed } from '@angular/core/testing';
import { CommodityService } from 'src/app/services/commodity/commodity.service';
import { TradeService } from 'src/app/services/trade/trade.service';

import { KeyMetricsComponent } from './key-metrics.component';

describe('KeyMetricsComponent', () => {
  let component: KeyMetricsComponent;
  let httpclient: HttpClient;
  let httpTestingController: HttpTestingController;

  
  let fixture: ComponentFixture<KeyMetricsComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ KeyMetricsComponent ],
      imports: [HttpClientTestingModule],
      providers: [TradeService, CommodityService]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(KeyMetricsComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
