import { Component, OnInit } from "@angular/core";
import { ActivatedRoute, Router, RouterOutlet } from "@angular/router";
import { FreeDay } from "../../core/models/freeday.model";
import {TuiCalendar} from '@taiga-ui/core';
import type {TuiDay} from '@taiga-ui/cdk';
import { tuiDayToDate } from "../../core/functions/date.mapping";
import { AvailabilityFormComponent } from "../availability-form/availability-form.component";
import { CommonModule } from "@angular/common";

@Component({
    selector: 'app-calendar',
    standalone: true,
    imports: [
        TuiCalendar,
        AvailabilityFormComponent,
        CommonModule
    ],
    templateUrl: './calendar.component.html',
    styleUrls: ['./calendar.component.css'],
})
export class CalendarComponent implements OnInit{
    userId!: string;

    freeDays: FreeDay[] = [
        { id: '1', date: new Date('2025-02-10') },
        { id: '2', date: new Date('2025-02-15') }
    ];

    constructor(private route: ActivatedRoute,
    ) {}

    ngOnInit(): void {
        this.userId = this.route.snapshot.paramMap.get('userId')!;
    }

    protected selectedDay: TuiDay | null = null;
    protected selectedDayAsDate: Date | null = null;

    protected onDayClick(day: TuiDay): void {
        this.selectedDay = day;
        this.selectedDayAsDate = tuiDayToDate(day);
    }

}