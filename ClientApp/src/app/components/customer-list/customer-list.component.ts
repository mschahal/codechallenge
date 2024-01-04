import {
  Component,
  Input,
  ChangeDetectionStrategy,
  Output,
  EventEmitter,
  OnInit
} from '@angular/core';
import { Customer } from '../../models/customer';
import { Router } from '@angular/router';

@Component({
  selector: 'app-customer-list',
  templateUrl: './customer-list.component.html',
  styleUrls: ['./customer-list.component.css'],
  changeDetection: ChangeDetectionStrategy.OnPush
})
export class CustomerListComponent implements OnInit {
  @Input() set customers(customers: Customer[]) {
    this._customers = customers;
    this._filteredCustomers = customers;
  }
  @Input() active: boolean = false;
  @Output() deleteEvent: EventEmitter<Customer> = new EventEmitter<Customer>();

  _customers: Customer[] = [];
  _filteredCustomers: Customer[] = [];
  filterValue = '';
  currentSorting = { column: '', direction: '' };
  selectedCustomerId: number = 1;

  constructor(private router: Router) { }

  ngOnInit(): void {
      this.selectedCustomerId = Number.parseInt(sessionStorage.getItem('selected-customer') ?? "0");
  }

  filterCustomers(event: any) {
    const value = event.target.value?.toLowerCase();
    if (!value) {
      this._filteredCustomers = this._customers;
      return;
    }
    this._filteredCustomers = this._customers.filter(x => x.firstName.toLowerCase().includes(value)
      || x.lastName.toLowerCase().includes(value)
      || x.email.toLowerCase().includes(value));
  }

  sortData(column: string) {
    if (this.currentSorting.column === column) {
      this.currentSorting.direction = this.currentSorting.direction === 'asc' ? 'desc' : 'asc';
    } else {
      this.currentSorting.column = column;
      this.currentSorting.direction = 'asc';
    }

    this._filteredCustomers.sort((a: any, b: any) => {
      if (a[column] < b[column]) {
        return this.currentSorting.direction === 'asc' ? -1 : 1;
      }
      if (a[column] > b[column]) {
        return this.currentSorting.direction === 'asc' ? 1 : -1;
      }
      return 0;
    });
  }

  edit(customer: Customer) {
    this.selectedCustomerId = customer.id;
    sessionStorage.setItem('selected-customer', this.selectedCustomerId?.toString());
    this.router.navigate(['edit-customer', customer.id]);
  }

  deleteCustomer(customer: Customer) {
    var confirmAction = confirm(`Are you sure you would like to delete "${customer.firstName} ${customer.lastName}"`);
    if (customer && confirmAction) this.deleteEvent.emit(customer);
  }
}
