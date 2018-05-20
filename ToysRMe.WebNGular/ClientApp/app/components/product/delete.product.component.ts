import { Component, OnInit, Input } from '@angular/core';
import { Product } from '../../models/product';
import { ProductService } from '../../services/product.service';
import { Router, ActivatedRoute } from '@angular/router';
import { Location } from '@angular/common';


@Component({
    selector: 'delete-product',
    templateUrl: './delete.product.component.html',
    providers: [ProductService]
})

export class DeleteProductComponent implements OnInit {
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

    public goBack() {
        this.location.back();
    }

    public deleteProduct(product: Product) {
        this.productService.Delete(this.product.id).subscribe(() => { this.router.navigate(['/products']); })
    }
}