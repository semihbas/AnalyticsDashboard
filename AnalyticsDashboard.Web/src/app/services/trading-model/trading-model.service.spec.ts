import { HttpClientTestingModule, HttpTestingController } from '@angular/common/http/testing';
import { TestBed } from '@angular/core/testing';
import { TradingModelResponse } from 'src/app/models/tradingModelResponse';
import { environment } from 'src/environments/environment';

import { TradingModelService } from './trading-model.service';

describe('TradingModelService', () => {
  let service: TradingModelService;
  let httpclient: HttpClientTestingModule;
  let httpTestingController: HttpTestingController;

  beforeEach(() => {
    TestBed.configureTestingModule({
      imports: [HttpClientTestingModule],
      providers: [TradingModelService]
    });
    httpclient = TestBed.inject(HttpClientTestingModule);
    httpTestingController = TestBed.inject(HttpTestingController);

    service = TestBed.inject(TradingModelService);
  });

  afterEach(() => {
    httpTestingController.verify();
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });


  it('get_should_return_list_of_tradingmodels', () => {
    const mockTradingModel: TradingModelResponse[] = [
      {
        id: 1,
        name: 'Name 1'
      },
      {
        id: 2,
        name: 'Name 2'
      }
    ];
    service.get().subscribe((data: TradingModelResponse[]) => {
      expect(data.length).toBe(2);
      expect(data).toEqual(mockTradingModel);
    })
    const request = httpTestingController.expectOne(`${environment.apiUrl}TradingModel`);
    expect(request.request.method).toBe('GET');
    request.flush(mockTradingModel);
  });

});
