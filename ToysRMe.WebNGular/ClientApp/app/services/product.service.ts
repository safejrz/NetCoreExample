import { Injectable } from '@angular/core';
import { Http, Response, Headers, RequestOptions } from '@angular/http';
import { Product } from '../models/product';
import { Observable } from "rxjs/Rx";
import "rxjs/Rx";

@Injectable()

export class ProductService {
    private WebApiUrl: string = 'http://localhost:5000/api/product/';

    constructor(private http: Http) { }

    GetProducts() {
        let data: Observable<Product[]> = this.http.get(this.WebApiUrl)
            .map(res => <Product[]>res.json())
            .catch(this.handleError);

        return data;
    }


    GetProduct(id: number) {
        let data: Observable<Product> = this.http.get(this.WebApiUrl + id)
            .map(res => <Product>res.json())
            .catch(this.handleError);

        return data;
    }

    Add(product: Product) {
        let body = JSON.stringify(product);
        let headers = new Headers({ 'Content-Type': 'application/json' });
        let options = new RequestOptions({ headers: headers });

        console.info('Body ' + body);
        console.info('Headers ' + headers);
        console.info('Options ' + options);
        console.info('WebApiUrl ' + this.WebApiUrl);

        let data = this.http.post(this.WebApiUrl, body, options)
            .map(res => console.info(res))
            .catch(this.handleError);

        return data;
    }

    Update(product: Product) {
        let body= JSON.stringify(product);
        console.info(body);
        let headers = new Headers({ 'Content-Type': 'application/json' });
        let options = new RequestOptions({ headers: headers });

        console.info('Body ' + body);
        console.info('Headers ' + headers);
        console.info('Options ' + options);
        console.info('WebApiUrl ' + this.WebApiUrl);

        let data = this.http.put(this.WebApiUrl, body, options)
            .map(res => console.info(res))
            .catch(this.handleError);

        return data;
    }

    Delete(id: number) {
        let data = this.http.delete(this.WebApiUrl + id)
            .map(res => console.info(res))
            .catch(this.handleError);

        return data;
    }

    private handleError(error: Response) {
        console.error(error);
        return Observable.throw(error.json().error || 'Server error');
    }
}