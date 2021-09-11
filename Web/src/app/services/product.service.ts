import { Injectable } from '@angular/core';
import { getFromApi } from './product-api-service';
import { Subject } from 'rxjs';
import { IProduct } from '../models/products';

@Injectable({
  providedIn: 'root'
})
export class ProductService {
  private getProductsTimeout: any;
  private subject = new Subject<IProduct[]>();
  private products: IProduct[];
  
  constructor() {
    this.requestProductsPeriodically();
  }

  public getSub() {
    return this.subject;
  };

  public getProducts() {
    return this.products;
  }

  private async requestProductsPeriodically() {
    await this.requestOrCatch();

    this.getProductsTimeout = setTimeout(
      async () => await this.requestProductsPeriodically(), 5000);
  }

  private async requestOrCatch() {
    try {
        await this.requestProducts();
    } catch (error) {
        console.log("Error occurred while requesting products!" + JSON.stringify(error))
    }
  }

  private async requestProducts() {
    this.products = await getFromApi();
    
    this.subject.next(this.products);
  }
}
