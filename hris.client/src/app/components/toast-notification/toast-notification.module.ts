import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { BrowserModule } from '@angular/platform-browser';
import { RouterModule } from '@angular/router';
import { ToastNotificationComponent } from './toast-notification.component';

@NgModule({
  declarations: [ToastNotificationComponent],
  exports: [ToastNotificationComponent],
  imports: [CommonModule, FormsModule, BrowserModule, RouterModule, ReactiveFormsModule],
})
export class ToastNotificationModule {}
