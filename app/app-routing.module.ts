import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { AdminEditproductComponent } from './admin-editproduct/admin-editproduct.component';
import { AdminUpdateproductComponent } from './admin-updateproduct/admin-updateproduct.component';
import { AdminproductComponent } from './AdminProduct/adminproduct/adminproduct.component';
import { AllProductComponent } from './AllProduct/all-product/all-product.component';
import { CartUserComponent } from './cart/cart-user/cart-user.component';
import { HomeComponent } from './Home/home/home.component';
import { IndoorProductComponent } from './IndoorProduct/indoor-product/indoor-product.component';
import { NavbarComponent } from './navbar/navbar/navbar.component';
import { PayOrderComponent } from './OrderUser/pay-order/pay-order.component';
import { OutdoorProductComponent } from './OutdoorProduct/outdoor-product/outdoor-product.component';
import { PayProductComponent } from './payProduct/pay-product/pay-product.component';
import { ProductDetailsComponent } from './ProductDetail/product-details/product-details.component';


const routes: Routes = [
  {path:'',component:NavbarComponent},
  {path:'home',component: HomeComponent},
  {path:'allplant',component: AllProductComponent},
  {path:'indoorplant',component: IndoorProductComponent},
  {path:'outdoorplant',component: OutdoorProductComponent},
  {path:'payorderlist',component: PayOrderComponent},
  {path:'cart',component: CartUserComponent},
  {path:'payProduct',component: PayProductComponent},
  {path:'detailProduct',component:ProductDetailsComponent},
  {path: 'AdminProduct',component:AdminproductComponent},
  {path: 'AdminEditProduct',component:AdminEditproductComponent},
  {path: 'AdminUpdateProduct',component:AdminUpdateproductComponent}


];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
