import { Component } from '@angular/core';
import { CustomerService } from '../customer.service';
@Component({
    selector: 'customer-list',
    templateUrl: 'customer-list.component.html',
    styleUrls: ['customer-list.component.scss']
})

export class CustomerListComponent {
    customers: ICustomer[];
    constructor(private customerService: CustomerService) {
        
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

    save() {
        let customer : ICustomer  = {
            id: null,
            fullName : 'Iron Man',
            dob: '2012-01-01',
            age: 7
        };

        this.customerService.addCustomer(customer).subscribe(data => {
            alert('Saved!');
        }, (err) => { alert(err); });
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
            alert('Customer Id : ' + id + ' Deleted!');
        }, (err) => { alert(err); });
    }
}