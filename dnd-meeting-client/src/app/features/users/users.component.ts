import { Component, OnInit } from "@angular/core";
import { User } from "../../core/models/user.model";
import { Router } from "@angular/router";
import { UserService } from "../../core/services/user.service";
import {MatCardModule} from '@angular/material/card';
import { CommonModule } from "@angular/common";
import { MatButtonModule } from "@angular/material/button";
import {MatInputModule} from '@angular/material/input';
import { FormsModule } from "@angular/forms";
import { map } from "rxjs";
import { NotificationService } from "../../core/services/notification.service";

@Component({
    selector: 'app-users',
    standalone: true,   
    imports: [
        MatCardModule,
        CommonModule,
        MatButtonModule,
        MatInputModule,
        FormsModule
    ],
    providers: [UserService],
    templateUrl: './users.component.html',
    styleUrls: ['./users.component.css']
})
export class UsersComponent implements OnInit {
    users: User[] = [];
    newUsername = '';

    constructor(private userService: UserService, private router: Router) {}

    ngOnInit(): void {
        this.loadUsers();
    }

    loadUsers() {
        this.userService.loadUsers().subscribe(data => {
            this.users = data;
        });
    }

    goToCalendar(userId: string) : void {
        this.router.navigate(['/calendar', userId])
    }

    createPerson() {
        this.userService.addUser(this.newUsername)
            .subscribe(user => {
                if (user) {
                    this.users = [...this.users, user];
                } else {
                    console.log('Ошибка при создании пользователя');
                }
            });
    }
    
}
