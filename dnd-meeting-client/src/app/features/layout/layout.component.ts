import { Component } from '@angular/core';
import { MatToolbarModule } from '@angular/material/toolbar';
import { MatButtonModule } from '@angular/material/button';
import { Route, Router, RouterOutlet } from '@angular/router';
import { MatCardModule } from '@angular/material/card';

@Component({
  selector: 'app-layout',
  standalone: true,
  imports: [MatToolbarModule, MatButtonModule, RouterOutlet, MatCardModule],
  templateUrl: './layout.component.html',
  styleUrls: ['./layout.component.scss'],
})
export class LayoutComponent {

    constructor(private router: Router){}
    
    goToUsers() : void {
        this.router.navigate(['/users']);
    }
}
