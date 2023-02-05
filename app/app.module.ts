import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { TooltipModule } from 'ngx-bootstrap/tooltip';
import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { ProductComponent } from './ProductTree/product/product.component';
import { AllProductComponent } from './AllProduct/all-product/all-product.component';
import { ProductSlideComponent } from './ProductSlide/product-slide/product-slide.component';
import { CarouselModule } from 'ngx-bootstrap/carousel';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { BsDropdownModule } from 'ngx-bootstrap/dropdown';
import { FooterComponent } from './footer/footer/footer.component';
import { PaginationModule } from 'ngx-bootstrap/pagination';
import { IndoorProductComponent } from './IndoorProduct/indoor-product/indoor-product.component';
import { OutdoorProductComponent } from './OutdoorProduct/outdoor-product/outdoor-product.component';
import { HomeComponent } from './Home/home/home.component';
import { BannerComponent } from './banner/banner/banner.component';
import { ProductDetailsComponent } from './ProductDetail/product-details/product-details.component';
import { RatingModule } from 'ngx-bootstrap/rating';
import { CartUserComponent } from './cart/cart-user/cart-user.component';
import { PayOrderComponent } from './OrderUser/pay-order/pay-order.component';
import { PayProductComponent } from './payProduct/pay-product/pay-product.component';
import {FormsModule, ReactiveFormsModule} from '@angular/forms';
import { NavbarComponent } from './navbar/navbar/navbar.component';
import { OpenProductDirective } from './Directive/open-product.directive';
import { ProductDetailDirective } from './Directive/product-detail.directive';
import { LoginComponent } from './Login/login/login.component';
import { RegisterComponent } from './Register/register/register.component';
import { HttpClientModule } from '@angular/common/http';
import { RouterModule } from '@angular/router';
import { ProductPayDirective } from './Directive/product-pay.directive';
import { AdminproductComponent } from './AdminProduct/adminproduct/adminproduct.component';
import { AdminUpdateproductComponent } from './admin-updateproduct/admin-updateproduct.component';
import { AdminEditproductComponent } from './admin-editproduct/admin-editproduct.component';
@NgModule({
  declarations: [
    AppComponent,
    ProductComponent,
    AllProductComponent,
    ProductSlideComponent,
    FooterComponent,
    IndoorProductComponent,
    OutdoorProductComponent,
    HomeComponent,
    BannerComponent,
    ProductDetailsComponent,
    CartUserComponent,
    PayOrderComponent,
    PayProductComponent,
    NavbarComponent,
    OpenProductDirective,
    ProductDetailDirective,
    LoginComponent,
    RegisterComponent,
    ProductPayDirective,
    AdminproductComponent,
    AdminUpdateproductComponent,
    AdminEditproductComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    TooltipModule.forRoot(),
    CarouselModule.forRoot(),
    BrowserAnimationsModule,
    PaginationModule.forRoot(),
    BsDropdownModule.forRoot(),
    ReactiveFormsModule,
    RatingModule.forRoot(),
    HttpClientModule,
    RouterModule,
    FormsModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
