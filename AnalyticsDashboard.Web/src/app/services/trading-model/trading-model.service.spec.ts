import { TestBed } from '@angular/core/testing';

import { TradingModelService } from './trading-model.service';

describe('TradingModelService', () => {
  let service: TradingModelService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(TradingModelService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
