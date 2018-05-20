import { Component, OnInit, Input } from '@angular/core';
import { Product } from '../../models/product';
import { ProductService } from '../../services/product.service';
import { Router, ActivatedRoute } from '@angular/router';

@Component({
    selector: 'details-product',
    templateUrl: './details.product.component.html',
    providers: [ProductService]
})

export class DetailsProductComponent implements OnInit {
    product: Product = new Product();

    constructor(private productService: ProductService, private activatedRoute: ActivatedRoute, private router: Router) { }

    ngOnInit() {
        if (!this.product.id) {
            this.activatedRoute.params.subscribe(params => {
                let id = Number.parseInt(params['id']);
                this.productService.GetProduct(id).subscribe((product: Product) => this.product = product);
            });
        }
    }
}