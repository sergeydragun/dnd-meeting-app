import { Injectable } from '@angular/core';
import { MatSnackBar } from '@angular/material/snack-bar';
import { ToastrService } from 'ngx-toastr';

@Injectable({
    providedIn: 'root' // Работает и без модуля
  })
  export class NotificationService {
    constructor(private toastr: ToastrService) {}
  
    showError(message: string): void {
      this.toastr.error(message, 'Ошибка(', {
        progressBar: true
      });
    }
  
    showSuccess(message: string): void {
      this.toastr.success(message, 'Моводец!');
    }
  }
