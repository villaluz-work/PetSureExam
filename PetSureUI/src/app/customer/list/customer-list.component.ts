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
    isUserAdding: boolean = false;
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
        this.isUserAdding = true;
    }

    save() {
        let customer : ICustomer  = {
            id: null,
            fullName : this.fg.controls['fullName'].value,
            dob: this.fg.controls['dob'].value,
            age: this.fg.controls['age'].value
        };
        if (this.fg.valid) {
            this.customerService.addCustomer(customer).subscribe(data => {
                this.isUserAdding = false;
                this.getAllCustomers();
            }, (err) => { alert(err); });    
        }else {
            alert('Form not valid!');
        }
    }

    update() {
        let customer: ICustomer = {
            id: 10, 
            fullName: 'Iron Man 2',
            dob: '2012-01-01',
            age: 7
        }
        this.customerService.updateCustomer(customer.id, customer).subscribe(data => {
            alert('Updated!');
        }, (err) => { alert(err); })
    }

    delete(id: number) {
        this.customerService.deleteCustomer(id).subscribe(data => {
            this.getAllCustomers();
            alert('Customer Id : ' + id + ' Deleted!');
        }, (err) => { alert(err); });
    }

    cancel() {
        this.isUserAdding = false;
        this.getAllCustomers();
    }
}