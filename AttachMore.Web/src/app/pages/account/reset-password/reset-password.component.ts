import { Component, OnInit } from '@angular/core';

import { AuthService } from '../../../services/auth.service';
import { Common } from '../../../configuration';

@Component({
  selector: 'am-reset-password',
  templateUrl: './reset-password.component.html',
  styleUrls: ['./reset-password.component.scss']
})
export class ResetPasswordComponent implements OnInit {

  constructor(private authService: AuthService) { }

  ngOnInit() {
    if (window.location.hash) {
      localStorage.setItem(Common.emailVerifyToken, window.location.hash.split('token=').pop());
    }
  }

}
