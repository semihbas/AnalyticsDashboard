import { TestBed } from '@angular/core/testing';
import { HttpClientTestingModule, HttpTestingController } from '@angular/common/http/testing';


import { TradeService } from './trade.service';
import { HttpClient, HttpClientModule } from '@angular/common/http';
import { TradeResponse } from 'src/app/models/tradeResponse';
import { environment } from 'src/environments/environment';

describe('TradeService', () => {
  let service: TradeService;
  let httpclient: HttpClient;
  let httpTestingController: HttpTestingController;

  beforeEach(() => {
    TestBed.configureTestingModule({
      imports: [HttpClientTestingModule],
      providers: [TradeService]
    });

    httpclient = TestBed.inject(HttpClient);
    httpTestingController = TestBed.inject(HttpTestingController);

    service = TestBed.inject(TradeService);
  });

  afterEach(() => {
    httpTestingController.verify();
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });

  it('getChartSourceByCommodity_should_return_list_of_tradingmodels', () => {
    const mockTrades: TradeResponse[] = [
      {
        id: 1,
        commodityId: 1,
        contract: 'Apr 18',
        tradingModelId: 3,
        date: new Date("2021-11-21"),
        pnLDaily: 123,
        newTradeAction: 2,
        position: 3,
        price: 124,
        tradingModel: { id: 3, name: 'test 3' },
        commodity: { id: 1, name: 'test 1' }
      },
      {
        id: 2,
        commodityId: 1,
        contract: 'Apr 18',
        tradingModelId: 1,
        date: new Date("2021-11-21"),
        pnLDaily: 123,
        newTradeAction: 2,
        position: 3,
        price: 124,
        tradingModel: { id: 1, name: 'test 1' },
        commodity: { id: 1, name: 'test 1' }
      }
    ];
    service.getChartSourceByCommodity(1).subscribe((data: TradeResponse[]) => {
      expect(data.length).toBe(2);
      expect(data).toEqual(mockTrades);
    })
    const request = httpTestingController.expectOne( `${environment.apiUrl}Trade/getChartSourceByCommodity?commodityId=1`);
    expect(request.request.method).toBe('GET');
    request.flush(mockTrades);
  });

});
