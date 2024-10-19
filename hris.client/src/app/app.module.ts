import { HttpClientModule } from '@angular/common/http';
import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { LoginModule } from './pages/login/login.module';
import { DashboardModule } from './pages/dashboard/dashboard.module';
import { SpinnerModule } from './components/spinner/spinner.module';
import { ToastNotificationModule } from './components/toast-notification/toast-notification.module';

@NgModule({
  declarations: [
    AppComponent,
  ],
  imports: [
    BrowserModule,
    HttpClientModule,
    AppRoutingModule,
    LoginModule,
    DashboardModule,
    SpinnerModule,
    ToastNotificationModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
