import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Observable } from 'rxjs';

@Injectable()
export class CustomerService{
    private apiUrl: string = 'https://localhost:44392/api/customer/';
    private reqHeaders: HttpHeaders;

    constructor(private http: HttpClient) {
        this.reqHeaders = new HttpHeaders({"Authorization":"abcd1234"});
    }

    public getAllCustomers() : Observable<ICustomer[]> {
       return this.http.get<ICustomer[]>(this.apiUrl, {headers : this.reqHeaders});
    }

    public getCustomerById(id : number): Observable<ICustomer> {
        return this.http.get<ICustomer>(this.apiUrl + '/' + id, {headers: this.reqHeaders});
    }

    public addCustomer(customer: ICustomer):Observable<any> {
        return this.http.post<number>(this.apiUrl, customer, {headers: this.reqHeaders});
    }

    public updateCustomer(id : number, customer: ICustomer) : Observable<any> {
        return this.http.put(this.apiUrl + '/' + id, customer, {headers: this.reqHeaders});
    }

    public deleteCustomer(id: number) : Observable<any> {
        return this.http.delete(this.apiUrl + '/' + id, {headers : this.reqHeaders});
    }

}