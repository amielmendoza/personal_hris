import { Component } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { SpinnerService } from '../../../services/spinner.service';

@Component({
  selector: 'app-employee-list',
  templateUrl: './employee.list.component.html',
  styleUrl: './employee.list.component.scss',
})
export class EmployeeListComponent {
  data = [
    {
      id: 1,
      name: 'John Doe',
      email: 'john@example.com',
      phone: '123-456-7890',
      phone1: '123-456-7890',
      phone2: '123-456-7890',
      phone3: '123-456-7890',
      phone4: '123-456-7890',
      phone5: '123-456-7890',
      phone6: '123-456-7890',
      phone7: '123-456-7890',
      phone8: '123-456-7890',
      phone9: '123-456-7890',
      phone11: '123-456-7890',
      phone12: '123-456-7890',
      phone13: '123-456-7890',
    },
    {
      id: 1,
      name: 'John Doe',
      email: 'john@example.com',
      phone: '123-456-7890',
      phone1: '123-456-7890',
      phone2: '123-456-7890',
      phone3: '123-456-7890',
      phone4: '123-456-7890',
      phone5: '123-456-7890',
      phone6: '123-456-7890',
      phone7: '123-456-7890',
      phone8: '123-456-7890',
      phone9: '123-456-7890',
      phone11: '123-456-7890',
      phone12: '123-456-7890',
      phone13: '123-456-7890',
    },
    {
      id: 1,
      name: 'John Doe',
      email: 'john@example.com',
      phone: '123-456-7890',
      phone1: '123-456-7890',
      phone2: '123-456-7890',
      phone3: '123-456-7890',
      phone4: '123-456-7890',
      phone5: '123-456-7890',
      phone6: '123-456-7890',
      phone7: '123-456-7890',
      phone8: '123-456-7890',
      phone9: '123-456-7890',
      phone11: '123-456-7890',
      phone12: '123-456-7890',
      phone13: '123-456-7890',
    },
    // { id: 2, name: 'Jane Doe', email: 'jane@example.com', phone: '234-567-8901' },
    // { id: 3, name: 'Jim Brown', email: 'jim@example.com', phone: '345-678-9012' },
    // Add more data here...
  ];

  currentPage = 1;
  itemsPerPage = 5;
  paginatedItems: any = [];
  totalPages = 0;
  pages: any = [];

  constructor(
    private router: Router,
    private route: ActivatedRoute,
    private spinnerService: SpinnerService
  ) {}

  ngOnInit() {
    this.spinnerService.show();
    this.calculateTotalPages();
    this.paginateItems();
    this.spinnerService.hide();
  }

  calculateTotalPages() {
    this.totalPages = Math.ceil(this.data.length / this.itemsPerPage);
    this.pages = Array.from({ length: this.totalPages }, (_, i) => i + 1);
  }

  paginateItems() {
    const start = (this.currentPage - 1) * this.itemsPerPage;
    const end = start + this.itemsPerPage;
    this.paginatedItems = this.data.slice(start, end);
  }

  changePage(page: number) {
    if (page >= 1 && page <= this.totalPages) {
      this.currentPage = page;
      this.paginateItems();
    }
  }

  addEmployee() {
    this.router.navigate(['form'], { relativeTo: this.route });
  }
}
