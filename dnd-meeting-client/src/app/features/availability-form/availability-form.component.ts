import { Component, Input, OnChanges, OnInit, SimpleChanges } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { DaysService } from '../../core/services/days.service';
import { Observable } from 'rxjs';
import { FreeTime } from '../../core/models/freetime.model';
import { MatCardModule } from '@angular/material/card';
import {MatChipsModule} from '@angular/material/chips';
import {MatFormFieldModule} from '@angular/material/form-field';
import {MatTimepickerModule} from '@angular/material/timepicker';
import {MatInputModule} from '@angular/material/input';
import {FormsModule} from '@angular/forms';
import { CommonModule } from '@angular/common';
import {NgxMaterialTimepickerModule} from 'ngx-material-timepicker';

@Component({
  selector: 'app-availbility-form',
  standalone: true,
  imports: [MatCardModule,
    MatChipsModule,
    MatFormFieldModule,
    MatTimepickerModule,
    MatInputModule,
    FormsModule,
    CommonModule,
    NgxMaterialTimepickerModule
  ],
  providers: [DaysService],
  templateUrl: './avaibility-form.component.html',
  styleUrls: ['./avaibility-form.component.css'],
})
export class AvailabilityFormComponent implements OnChanges {
  @Input() selectedDate: Date | null = null;
  @Input() userId: string = null!;

  freeTimes: FreeTime[] | null = null;

  startTime: Date = new Date();
  endTime: Date = new Date();

  format :number = 24

  constructor(private readonly dayService: DaysService) {}

  ngOnChanges(changes: SimpleChanges): void {
    if (changes['selectedDate'] && this.selectedDate && this.userId) {
      this.loadFreeTimes();
    }
  }

  private loadFreeTimes(): void {
    const formattedDate = this.selectedDate?.toISOString().split('T')[0];
    this.dayService.loadUsersFreeTimesInDay([this.userId], formattedDate!).subscribe(times => {
      this.freeTimes = times
    });
  }

  addTime() {
    if (this.startTime && this.endTime) {

    }
  }

  removeTime(time: FreeTime) {

  }

  submit() {

  }
}
