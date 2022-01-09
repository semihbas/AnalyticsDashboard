import { ComponentFixture, TestBed } from '@angular/core/testing';

import { HistoricalActionsComponent } from './historical-actions.component';

describe('HistoricalActionsComponent', () => {
  let component: HistoricalActionsComponent;
  let fixture: ComponentFixture<HistoricalActionsComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ HistoricalActionsComponent ]
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
