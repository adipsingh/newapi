import { Component, OnInit } from '@angular/core';

import { BgImgRefreshService } from '../../services/bg-img-refresh.service';
import { NavigationService } from '../../services/navigation.service';
import { DataUsage } from '../../models';
import { DashboardService } from '../../services/dashboard.service';
import { AuthService } from '../../services/auth.service';

@Component({
  selector: 'am-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.scss']
})
export class HomeComponent implements OnInit {
  imageUrl: string;
  dataUsage: DataUsage;

  constructor(public bgImgRefreshService: BgImgRefreshService,
    public dashboardService: DashboardService,
    public authService: AuthService,
    public navigationService: NavigationService) { }

  ngOnInit() {
    this.imageUrl = this.bgImgRefreshService.imageUrl();

    this.dashboardService.getDataUsage().subscribe(res => {
      this.dataUsage = res;
    });
  }
}
