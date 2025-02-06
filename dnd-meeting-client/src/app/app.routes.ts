import { Routes } from '@angular/router';
import { UsersComponent } from './features/users/users.component';
import { LayoutComponent } from './features/layout/layout.component';
import { CalendarComponent } from './features/calendar/calendar.component';

export const routes: Routes = [
    {
        path: '',
        redirectTo: 'users',
        pathMatch: 'full',
    },
    {
        path: 'users',
        component: UsersComponent,
    },
    {
        path: 'calendar/:userId',
        component: LayoutComponent,
        children: [
            { path: '', 
              component: CalendarComponent
            }
        ]
    },
    { path: '**', redirectTo: 'users'}
];
