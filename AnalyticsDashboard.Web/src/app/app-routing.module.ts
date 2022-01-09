import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { DashboardComponent } from './components/dashboard/dashboard.component';
import { HistoricalActionsComponent } from './components/historical-actions/historical-actions.component';
import { HistoricalTrendComponent } from './components/historical-trend/historical-trend.component';
import { KeyMetricsComponent } from './components/key-metrics/key-metrics.component';

const routes: Routes = [
  {
    path: '', component: DashboardComponent, data: { title: 'Dashboard' },
    children: [
      { path: '', component: KeyMetricsComponent, data: { title: 'Key Metrics' } },
      { path: 'historical-trend', component: HistoricalTrendComponent, data: { title: 'Historical Trend' } },
      { path: 'historical-actions', component: HistoricalActionsComponent, data: { title: 'Historical Actions' } }
    ]
  }
];


@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
