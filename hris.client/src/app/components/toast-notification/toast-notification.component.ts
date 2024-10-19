import { Component, OnInit, OnDestroy } from '@angular/core';
import { Subscription } from 'rxjs';
import { ToastNotificationService, Toast } from '../../services/toast-notification.service';

@Component({
  selector: 'app-toast-notification',
  templateUrl: './toast-notification.component.html',
  styles: [`

  `]
})
export class ToastNotificationComponent implements OnInit, OnDestroy {
  toasts: Toast[] = [];
  private subscription: Subscription;

  constructor(private toastNotificationService: ToastNotificationService) {
    this.subscription = new Subscription();
  }

  ngOnInit() {
    this.subscription = this.toastNotificationService.toast$
      .subscribe(toast => {
        this.toasts.push(toast);
        setTimeout(() => this.removeToast(toast), toast.timeout);
      });
  }

  ngOnDestroy() {
    if (this.subscription) {
      this.subscription.unsubscribe();
    }
  }

  removeToast(toastToRemove: Toast) {
    this.toasts = this.toasts.filter(toast => toast !== toastToRemove);
  }
}
