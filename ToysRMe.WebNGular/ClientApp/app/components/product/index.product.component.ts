import { Component, OnInit, Input } from '@angular/core';
import { Product } from '../../models/product';
import { ProductService } from '../../services/product.service';

@Component({
    selector: 'list-products',
    templateUrl: './index.product.component.html',
    providers: [ProductService]
})
export class IndexProductsComponent implements OnInit {

    constructor(private productService: ProductService) { }

    products: Product[];
    errorMessage: any;

    ngOnInit() {
        this.productService.GetProducts()
            .subscribe(
            products => this.products = products,
            error => this.errorMessage = <any>error);
    }
}
