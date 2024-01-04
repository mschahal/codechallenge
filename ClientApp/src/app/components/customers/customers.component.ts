import { Component, OnDestroy, OnInit } from '@angular/core';
import { Customer } from '../../models/customer';
import { CustomerService } from '../../services/customer.service';
import { Subject, takeUntil } from 'rxjs';
import { Router } from '@angular/router';

@Component({
  selector: 'app-customers',
  templateUrl: './customers.component.html',
  styleUrls: ['./customers.component.css']
})
export class CustomersComponent implements OnInit, OnDestroy {

  customers: Customer[] = [];

  private destroy$ = new Subject();
  constructor(private customerService: CustomerService, private router: Router) { }

  ngOnInit() {
    this.getCustomers();
  }

  addCustomer() {
    this.router.navigate(['add-customer']);
  }

  getCustomers() {
    this.customerService.getCustomers()
    .pipe(takeUntil(this.destroy$))
    .subscribe(res => {
      this.customers = res;
    })
  }

  deleteCustomer(customer: Customer) {
    this.customerService.deleteCustomer(customer.id)
    .pipe(takeUntil(this.destroy$))
    .subscribe(res => {
      alert('Delete Successful!');
      this.getCustomers();
    })
  }

  ngOnDestroy() {
    this.destroy$.next(true);
    this.destroy$.complete();
  }

}
