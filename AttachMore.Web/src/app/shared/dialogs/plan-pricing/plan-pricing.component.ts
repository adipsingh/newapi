import { Component, OnInit, ViewChild, ElementRef } from '@angular/core';
import { MatRadioButton } from '@angular/material';

import { PackageService } from '../../../services/package.service';
import { Package } from '../../../models/package.model';
import { NotificationService } from '../../../services/notification.service';
import { MESSAGES } from '../../../configuration/success.msg';

@Component({
  selector: 'am-plan-pricing',
  templateUrl: './plan-pricing.component.html',
  styleUrls: ['./plan-pricing.component.scss']
})

export class PlanPricingComponent implements OnInit {

  packages: Package[];
  selectedPackage = 1;

  constructor(private packageService: PackageService, private notificationService: NotificationService) { }

  ngOnInit(): void {
    this.packageService.getAllPackages().subscribe(res => {
      this.packages = res;
    });
  }

  onBuyPlan() {
    this.packageService.buyPackage({ packageId: this.selectedPackage, userId: 12 }).subscribe(res => {
      this.notificationService.notify(MESSAGES.packagePurchased);
    });
  }

}
