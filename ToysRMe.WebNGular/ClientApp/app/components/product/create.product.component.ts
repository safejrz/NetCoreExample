import { Component, OnInit, Input } from '@angular/core';
import { Product } from '../../models/product';
import { ProductService } from '../../services/product.service';
import { Router, ActivatedRoute } from '@angular/router';

@Component({
    selector: 'create-product',
    templateUrl: './create.product.component.html',
    providers: [ProductService]
})

export class CreateProductComponent implements OnInit {
    @Input() product: Product = new Product();

    constructor(private productService: ProductService, private activatedRoute: ActivatedRoute, private router: Router) { }

    ngOnInit() { }

    public createProduct() {
        this.productService.Add(this.product).subscribe(() => { this.router.navigate(['/products']); });
    }
}