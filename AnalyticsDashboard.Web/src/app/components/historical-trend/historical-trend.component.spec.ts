import { ComponentFixture, TestBed } from '@angular/core/testing';

import { HistoricalTrendComponent } from './historical-trend.component';

describe('HistoricalTrendComponent', () => {
  let component: HistoricalTrendComponent;
  let fixture: ComponentFixture<HistoricalTrendComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ HistoricalTrendComponent ]
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
