import { CommonModule } from '@angular/common';
import { Component, Input } from '@angular/core';
import { AvailabilityFormComponent } from "../availability-form/availability-form.component";

@Component({
  selector: 'app-custom-toast',
  templateUrl: './custom-toast.component.html',
  styleUrls: ['./custom-toast.component.css'],
  standalone: true,
  imports: [CommonModule]
})
export class CustomToastComponent {
  @Input() message: string = '';
  @Input() show: boolean = false;

  close() {
    this.show = false;
  }
}
