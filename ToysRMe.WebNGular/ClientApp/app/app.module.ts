import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { UniversalModule } from 'angular2-universal';
import { AppComponent } from './components/app/app.component'
import { ReactiveFormsModule, FormsModule } from '@angular/forms';
import { NavMenuComponent } from './components/navmenu/navmenu.component';
import { HomeComponent } from './components/home/home.component';
import { IndexProductsComponent } from './components/product/index.product.component';
import { CreateProductComponent } from './components/product/create.product.component';
import { DeleteProductComponent } from './components/product/delete.product.component';
import { EditProductComponent } from './components/product/edit.product.component';
import { DetailsProductComponent } from './components/product/details.product.component';
import { Product } from './models/product';
import { ProductService } from './services/product.service';

@NgModule({
    bootstrap: [AppComponent],
    declarations: [
        AppComponent,
        NavMenuComponent,
        IndexProductsComponent,
        CreateProductComponent,
        DetailsProductComponent,
        DeleteProductComponent,
        EditProductComponent,
        HomeComponent,
    ],
    providers: [
        ProductService
    ],
    imports: [
        UniversalModule, // Must be first import. This automatically imports BrowserModule, HttpModule, and JsonpModule too.
        ReactiveFormsModule,
        FormsModule,
        RouterModule.forRoot([
            { path: '', redirectTo: 'home', pathMatch: 'full' },
            { path: 'home', component: HomeComponent },
            { path: 'products', component: IndexProductsComponent },
            { path: 'create', component: CreateProductComponent },
            { path: 'delete/:id', component: DeleteProductComponent },
            { path: 'edit/:id', component: EditProductComponent },
            { path: 'details/:id', component: DetailsProductComponent }
        ])
    ]
})
export class AppModule {
}
