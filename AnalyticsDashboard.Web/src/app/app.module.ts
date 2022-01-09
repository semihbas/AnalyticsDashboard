import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { DashboardComponent } from './components/dashboard/dashboard.component';
import { HistoricalTrendComponent } from './components/historical-trend/historical-trend.component';
import { HistoricalActionsComponent } from './components/historical-actions/historical-actions.component';
import { KeyMetricsComponent } from './components/key-metrics/key-metrics.component';
import { NavigationBarComponent } from './components/navigation-bar/navigation-bar.component';
import { SpinnerComponent } from './components/spinner/spinner.component';
import { SpinnerService } from './services/spinner.service';

import { MatFormFieldModule } from '@angular/material/form-field';
import { MatListModule } from '@angular/material/list';
import { MatRadioModule } from '@angular/material/radio';
import { MatCardModule } from '@angular/material/card';
import { MatIconModule } from '@angular/material/icon';
import { MatTooltipModule } from '@angular/material/tooltip';
import { MatMenuModule } from '@angular/material/menu';
import { MatSlideToggleModule } from '@angular/material/slide-toggle';
import { MatDialogModule } from '@angular/material/dialog';
import { MatSelectModule } from '@angular/material/select';
import { MatToolbarModule } from '@angular/material/toolbar';
import { MatProgressSpinnerModule } from '@angular/material/progress-spinner';
import { MatSortModule } from '@angular/material/sort';
import { MatPaginatorModule } from '@angular/material/paginator';
import { MatChipsModule } from '@angular/material/chips';
import { MatGridListModule } from '@angular/material/grid-list';
import { MatDatepickerModule } from '@angular/material/datepicker';
import { MatTableModule } from '@angular/material/table';
import { MatTabsModule } from '@angular/material/tabs';
import { MatButtonToggleModule } from '@angular/material/button-toggle';
import { MatAutocompleteModule } from '@angular/material/autocomplete';
import { MatExpansionModule } from '@angular/material/expansion';
import { MatButtonModule } from '@angular/material/button';
import { MatInputModule } from '@angular/material/input';
import { MatCheckboxModule } from '@angular/material/checkbox';
import { MatStepperModule } from '@angular/material/stepper';
import { MatProgressBarModule } from '@angular/material/progress-bar';
import { MatSidenavModule } from '@angular/material/sidenav';
import { MatSliderModule } from '@angular/material/slider';
import { MatSnackBarModule } from '@angular/material/snack-bar';
import { MatNativeDateModule } from '@angular/material/core';
import { FlexLayoutModule } from '@angular/flex-layout';
import { NgxChartsModule } from '@swimlane/ngx-charts';


@NgModule({
  declarations: [
    AppComponent,
    DashboardComponent,
    HistoricalTrendComponent,
    HistoricalActionsComponent,
    KeyMetricsComponent,
    NavigationBarComponent,
    SpinnerComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    BrowserAnimationsModule,
    MatFormFieldModule,
    MatListModule,
    MatRadioModule,
    MatCardModule,
    MatIconModule,
    MatTooltipModule,
    MatMenuModule,
    MatSlideToggleModule,
    MatDialogModule,
    MatSelectModule,
    MatToolbarModule,
    MatProgressSpinnerModule,
    MatSortModule,
    MatPaginatorModule,
    MatChipsModule,
    MatGridListModule,
    MatDatepickerModule,
    MatTableModule,
    MatTabsModule,
    MatButtonToggleModule,
    MatAutocompleteModule,
    MatExpansionModule,
    MatButtonModule,
    MatInputModule,
    MatCheckboxModule,
    MatStepperModule,
    MatProgressBarModule,
    MatSidenavModule,
    MatSliderModule,
    MatSnackBarModule,
    MatNativeDateModule,
    FlexLayoutModule,
    NgxChartsModule
  ],
  providers: [SpinnerService],
  bootstrap: [AppComponent]
})
export class AppModule { }
