import { HttpClientTestingModule, HttpTestingController } from '@angular/common/http/testing';
import { TestBed } from '@angular/core/testing';
import { mockCommodityArray } from 'src/app/mocks/mockCommodity';
import { CommodityResponse } from 'src/app/models/commodityResponse';
import { environment } from 'src/environments/environment';

import { CommodityService } from './commodity.service';

describe('CommodityService', () => {
  let service: CommodityService;
  let httpclient: HttpClientTestingModule;
  let httpTestingController: HttpTestingController;
  let url = 'localhost:5001/api';

  beforeEach(() => {
    TestBed.configureTestingModule({
      imports: [HttpClientTestingModule],
      providers: [CommodityService]
    });

    httpclient = TestBed.inject(HttpClientTestingModule);
    httpTestingController = TestBed.inject(HttpTestingController);

    service = TestBed.inject(CommodityService);
  });

  afterEach(() => {
    httpTestingController.verify();
  });


  it('should be created', () => {
    expect(service).toBeTruthy();
  });

  it('get_should_return_list_of_commodities', () => {
    const mockCommodities: CommodityResponse[] = [
      {
        id: 1,
        name: 'Name 1'
      },
      {
        id: 2,
        name: 'Name 2'
      }
    ];
    service.get().subscribe((data: CommodityResponse[]) => {
      expect(data.length).toBe(2);
      expect(data).toEqual(mockCommodities);
    })
    const request = httpTestingController.expectOne(`${environment.apiUrl}Commodity`);
    expect(request.request.method).toBe('GET');
    request.flush(mockCommodities);
  });

});
