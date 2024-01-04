import { Injectable } from '@angular/core';
import { RestService } from '../../core/services/rest.service';
import { Customer } from '../models/customer';
@Injectable({
  providedIn: 'root'
})
export class CustomerService {
  private endpoint = 'api/Customers';

  constructor(private restService: RestService) { }

  public getCustomers() {
    return this.restService.get<Customer[]>(`${this.endpoint}`);
  }

  public getCustomerById(customerId: number) {
    return this.restService.get<Customer>(`${this.endpoint}/${customerId}`);
  }

  public addCustomer(customer: Customer) {
    return this.restService.post(`${this.endpoint}`, customer)
  }

  public updateCustomer(customer: Customer) {
    return this.restService.put(`${this.endpoint}/${customer.id}`, customer);
  }

  public deleteCustomer(customerId: number) {
    return this.restService.delete(`${this.endpoint}/${customerId}`);
  }

}
