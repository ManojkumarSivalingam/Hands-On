import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { ToastrService } from 'ngx-toastr';
import { Observable, of } from 'rxjs';
import { User } from '../_models/user';
import { AccountService } from '../_services/account.service';

@Component({
  selector: 'app-nav',
  templateUrl: './nav.component.html',
  styleUrls: ['./nav.component.css']
})
export class NavComponent implements OnInit {
  model: any = {};
  loggedIn: boolean;

  constructor(public accountService: AccountService, private router: Router,
    private toastr: ToastrService) { }

  ngOnInit(): void {

  }

  getCurrentUser() {
    this.accountService.currentUser$.subscribe(user => {
      next: user => this.loggedIn = !!user;
    });
  }

  login():void {
    this.accountService.login(this.model).subscribe(response => {
      this.loggedIn=true;
      this.router.navigateByUrl('/members');
    });
  }

  logout() {
    this.loggedIn = false;
    this.accountService.logout();
    this.router.navigateByUrl('/');
  }

}
