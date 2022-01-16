import { AfterViewInit, Component } from '@angular/core';
import { LoaderService } from './interceptor/loader-service';
import { SpinnerService } from './services/spinner/spinner.service';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.scss']
})
export class AppComponent implements AfterViewInit {

  title = 'Analytics Dashboard';

  constructor(private loaderService: LoaderService, 
    private  spinnerService: SpinnerService) {
    
  }

  ngAfterViewInit() {
    this.loaderService.httpProgress().subscribe((status: boolean) => {
      if (status) {
        this.spinnerService.show();
      } else {
        this.spinnerService.hide();
      }
    });
  }

  getYear() {
    return new Date().getUTCFullYear();
  }
}
