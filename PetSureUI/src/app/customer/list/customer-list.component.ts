import { Component, OnInit } from '@angular/core';
import { CustomerService } from '../customer.service';
import { FormGroup, FormBuilder, FormControl, Validators } from '@angular/forms';
@Component({
    selector: 'customer-list',
    templateUrl: 'customer-list.component.html',
    styleUrls: ['customer-list.component.scss'],
    providers: [CustomerService]
})

export class CustomerListComponent implements OnInit {
    customers: ICustomer[];
    updateCustomerId: number;
    userActivity: number = 0;
    fg: FormGroup
    constructor(private customerService: CustomerService, private fb: FormBuilder) {
        this.fg = new FormGroup({
            fullName: new FormControl('', Validators.required),
            dob: new FormControl('', Validators.required),
            age: new FormControl('')
        });

        this.fg.controls['dob'].valueChanges.subscribe(d => {
            let dateDiff = Math.abs(Date.now() - d);
            var ageVal = Math.ceil(dateDiff / (1000 * 60 * 60 * 24 * 30 * 12)); 
            this.fg.controls['age'].setValue(ageVal);
        });
    }

    ngOnInit() {
        this.getAllCustomers();
    }

    getAllCustomers() {
        this.customerService.getAllCustomers().subscribe(c => {
            this.customers = c;
            console.log('Customer : ', this.customers);
        });
    }

    getCustomer(id: number) {
        this.customerService.getCustomerById(id).subscribe(c => {
            console.log('customer : ', c);
        });
    }

    addCustomer() {
        this.userActivity = 1;
    }

    save(customerParam: ICustomer = null) {
        let customer : ICustomer  = {
            id: null,
            fullName : this.fg.controls['fullName'].value,
            dob: this.fg.controls['dob'].value,
            age: this.fg.controls['age'].value
        };
        if (this.fg.valid) {
            switch(this.userActivity) {
                case 1:
                    this.customerService.addCustomer(this.fg.value).subscribe(data => {
                        this.userActivity = 0;
                        this.getAllCustomers();
                    }, (err) => { alert(err); });  
                    break;
                case 2:
                    this.customerService.updateCustomer(this.updateCustomerId, this.fg.value).subscribe(data => {
                        this.userActivity = 0;
                        this.getAllCustomers();
                    }, (err) => { alert(err); })
                    break;
                default:
                    alert('Undefined user activity');
            }
        }else {
            alert('Form invalid!');
        }
    }

    update(customer: ICustomer) {
        this.userActivity = 2;
        this.updateCustomerId = customer.id;
        this.fg.controls['fullName'].setValue(customer.fullName);
        this.fg.controls['dob'].setValue(customer.dob);
        this.fg.controls['age'].setValue(customer.age);
    }

    delete(id: number) {
        this.customerService.deleteCustomer(id).subscribe(data => {
            this.getAllCustomers();
            alert('Customer Id : ' + id + ' Deleted!');
        }, (err) => { alert(err); });
    }

    cancel() {
        this.userActivity = 0;
        this.getAllCustomers();
    }
}