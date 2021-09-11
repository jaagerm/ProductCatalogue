import { Component, OnInit, OnDestroy } from '@angular/core';
import { IProduct } from '../models/products';
import { getFromApi } from '../services/product-api-service';
import { ProductService } from '../services/product.service';
import { Subscription } from 'rxjs';

@Component({
  selector: 'app-products',
  templateUrl: './products.component.html',
  styleUrls: ['./products.component.css']
})
export class ProductsComponent implements OnInit, OnDestroy {
  products: IProduct[] = [];
  subscription: Subscription;

  constructor(
    public productService: ProductService
  ) { 
    this.products = productService.getProducts();
  }

  async ngOnInit() {
     this.subscription = this.productService.getSub().subscribe(products => {
      this.products = products;
    })
  }

  ngOnDestroy(): void {
    this.subscription.unsubscribe();
  }
}
