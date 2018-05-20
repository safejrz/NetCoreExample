import { Component, OnInit, Input } from '@angular/core';
import { Product } from '../../models/product';
import { ProductService } from '../../services/product.service';
import { Router, ActivatedRoute } from '@angular/router';
import { Location } from '@angular/common';

@Component({
    selector: 'edit-product',
    templateUrl: './edit.product.component.html',
    providers: [ProductService]
})

export class EditProductComponent implements OnInit {
    @Input() product: Product = new Product();

    constructor(private productService: ProductService, private activatedRoute: ActivatedRoute, private router: Router, private location: Location) { }

    ngOnInit() {
        if (!this.product.id) {
            this.activatedRoute.params.subscribe(params => {
                let id = Number.parseInt(params['id']);
                this.productService.GetProduct(id).subscribe((product: Product) => this.product = product);
            });
        }
    }

    public updateProduct(product: Product) {
        this.productService.Update(this.product).subscribe(() => { this.location.back() });
    }
}