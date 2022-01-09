import { Injectable, Optional, SkipSelf } from '@angular/core';
import { Subject } from 'rxjs';

export interface SpinnerState {
  show: boolean;
}

@Injectable()
export class SpinnerService {
  private spinnerSubject = new Subject<SpinnerState>();

  spinnerState = this.spinnerSubject.asObservable();
  body = document.querySelector('body');
  constructor(@Optional() @SkipSelf() prior: SpinnerService) {
    if (prior) { return prior; }
  }
  show() {
    this.spinnerSubject.next({ show: true } as SpinnerState);
    this.body?.classList.add('body-disabled');
  }

  hide() {
    this.spinnerSubject.next({ show: false } as SpinnerState);
    this.body?.classList.remove('body-disabled');
  }
}
