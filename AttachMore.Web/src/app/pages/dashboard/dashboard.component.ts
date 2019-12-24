import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';

import { DashboardService } from '../../services/dashboard.service';
import { Dashboard, UserDetail, DataUsage } from '../../models';
import { UserStatus } from '../../enum';

@Component({
  selector: 'am-dashboard',
  templateUrl: './dashboard.component.html',
  styleUrls: ['./dashboard.component.scss']
})
export class DashboardComponent implements OnInit {

  dashboard: Dashboard;
  userDetail: UserDetail = <UserDetail>{};
  dataUsage: DataUsage = <DataUsage>{};
  userStatus = UserStatus;

  constructor(public dashboardService: DashboardService, private route: Router) { }

  ngOnInit() {
    this.dashboardService.getStats().subscribe(res => {
      this.dashboard = res;
    });

    this.dashboardService.getUserDetails().subscribe(res => {
      this.userDetail = res;
    });

    this.dashboardService.getDataUsage().subscribe(res => {
      this.dataUsage = res;
      this.dataUsage.usagePercentage = Math.round((this.dataUsage.usage / this.dataUsage.totalData) * 100);
    });
  }

  /**
   * Navigate To File History
   */
  navigateToFileHistory() {
    this.route.navigate(['/filesHistory']);
  }

}
