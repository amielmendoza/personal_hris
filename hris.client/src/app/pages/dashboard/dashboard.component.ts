import { Component, OnInit } from '@angular/core';
import navigations from './navigation.json';
import { ActivatedRoute, Router } from '@angular/router';

@Component({
  selector: 'app-dashboard',
  templateUrl: './dashboard.component.html',
  styleUrl: './dashboard.component.scss',
})
export class DashboardComponent implements OnInit{
  navigations: any = [];
  currentRoute: string = '';
  constructor(private router: Router, private route: ActivatedRoute) {
    // Subscribe to router events to get the updated route
    this.router.events.subscribe(() => {
      this.currentRoute = this.router.url;
    });
  }

  ngOnInit(): void {
      this.navigations = navigations;
      console.log(this.navigations);
  }
}
