import { Component, OnInit, OnDestroy } from '@angular/core';
import { Subscription } from 'rxjs';

import { LoaderService } from '../../../services/loader.service';
import { LoaderState } from '../../../models';

@Component({
  selector: 'am-progress-bar',
  templateUrl: './progress-bar.component.html',
  styleUrls: ['./progress-bar.component.scss']
})
export class ProgressBarComponent implements OnInit, OnDestroy {
  show = false;
  private subscription: Subscription;

  constructor(private loaderService: LoaderService) { }

  ngOnInit() {
    this.subscription = this.loaderService.loaderState
    .subscribe((state: LoaderState) => {
      setTimeout(() => {
        this.show = state.show;
      }, 50);
    });
  }

  ngOnDestroy() {
    this.subscription.unsubscribe();
  }
}
