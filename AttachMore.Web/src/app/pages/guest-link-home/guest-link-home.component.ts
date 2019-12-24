import { Component, OnInit } from '@angular/core';

import { BgImgRefreshService } from '../../services/bg-img-refresh.service';
import { NavigationService } from '../../services/navigation.service';
import { DataUsage } from '../../models';
import { DashboardService } from '../../services/dashboard.service';
import { AuthService } from '../../services/auth.service';
import { ActivatedRoute } from '@angular/router';

@Component({
  selector: 'am-home',
  templateUrl: './guest-link-home.component.html',
  styleUrls: ['./guest-link-home.component.scss']
})
export class GuestLinkHomeComponent implements OnInit {
  imageUrl: string;
  dataUsage: DataUsage;
  guestLinkId: string;

  constructor(public bgImgRefreshService: BgImgRefreshService,
    public dashboardService: DashboardService,
    public authService: AuthService,
    public navigationService: NavigationService,
    private activatedRoute: ActivatedRoute) { }

  ngOnInit() {
    this.activatedRoute.params.subscribe(res => {
      this.guestLinkId = res.guestLinkId;
    });

    this.imageUrl = this.bgImgRefreshService.imageUrl();

    this.dashboardService.getDataUsage().subscribe(res => {
      this.dataUsage = res;
    });
  }
}
