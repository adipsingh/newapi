import { Component, OnInit } from '@angular/core';
import { Router, NavigationError, NavigationCancel, NavigationEnd, NavigationStart, Event } from '@angular/router';

import { LoaderService } from './services/loader.service';

@Component({
  selector: 'am-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.scss']
})
export class AppComponent implements OnInit {

  constructor(private router: Router, private loaderService: LoaderService) { }

  ngOnInit(): void {
    this.registerNavigationEvents();
  }

  /**
   * @description Registering the Navigation Events and Showing Loader when navigation is changing
   */
  registerNavigationEvents(): void {
    this.router.events.subscribe((event: Event) => {
      switch (true) {
        case event instanceof NavigationStart: {
          this.loaderService.show();
          break;
        }
        case event instanceof NavigationEnd:
        case event instanceof NavigationCancel:
        case event instanceof NavigationError: {
          this.loaderService.hide();
          break;
        }
        default:
          break;
      }
    });
  }

}
