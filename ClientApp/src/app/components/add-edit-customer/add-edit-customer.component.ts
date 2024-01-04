import { Component, OnDestroy, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { Subject, takeUntil } from 'rxjs';
import { CustomerService } from '../../services/customer.service';
import { FormControl, FormGroup, Validators } from '@angular/forms';

@Component({
  selector: 'app-add-edit-customer',
  templateUrl: './add-edit-customer.component.html',
  styleUrls: ['./add-edit-customer.component.css']
})
export class AddEditCustomerComponent implements OnInit, OnDestroy {

  customerId: number = 0;
  customerForm: FormGroup = this.createCustomerForm();

  private destroy$ = new Subject();

  constructor(private route: ActivatedRoute, private router: Router, private customerService: CustomerService) { }

  ngOnInit() {
    this.route.params
      .pipe(takeUntil(this.destroy$)).subscribe((params) => {
        this.customerId = params['id'];
        if (this.customerId) {
          this.getCustomerDetail();
        }
      });
  }

  public saveCustomer() {
    if (this.customerId) {
      this.customerService.updateCustomer(this.customerForm.value)
      .pipe(takeUntil(this.destroy$)).subscribe((res) => {
        alert('Customer updated');
        this.router.navigate(['']);
      });
    } else {
      this.customerService.addCustomer(this.customerForm.value)
      .pipe(takeUntil(this.destroy$)).subscribe((res) => {
        alert('Customer added');
        this.router.navigate(['']);
      });
    }

  }

  private createCustomerForm() {
    return new FormGroup({
      id: new FormControl(0),
      firstName: new FormControl('', [Validators.required]),
      lastName: new FormControl('', [Validators.required]),
      email: new FormControl('', [Validators.required, Validators.email]),
    })
  }

  private getCustomerDetail() {
    this.customerService.getCustomerById(this.customerId)
      .pipe(takeUntil(this.destroy$)).subscribe((res) => {
        this.customerForm.patchValue(res);
      });
  }

  ngOnDestroy(): void {
    this.destroy$.next(null);
    this.destroy$.complete();
  }

}
