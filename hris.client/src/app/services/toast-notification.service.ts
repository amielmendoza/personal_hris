import { Injectable } from '@angular/core';
import { Subject } from 'rxjs';

export interface Toast {
  message: string;
  type: 'success' | 'error';
  timeout: number;
}

@Injectable({
  providedIn: 'root'
})
export class ToastNotificationService {
  private toastSubject = new Subject<Toast>();
  toast$ = this.toastSubject.asObservable();

  showSuccess(message: string, timeout: number = 5000) {
    this.toastSubject.next({ message, type: 'success', timeout });
  }

  showError(message: string, timeout: number = 5000) {
    this.toastSubject.next({ message, type: 'error', timeout });
  }
}
