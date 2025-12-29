import { Component } from "@angular/core";
import { MatButton } from "@angular/material/button";
import { MatIconModule } from "@angular/material/icon";
import { MatListModule } from "@angular/material/list";
import { MatMenuModule } from "@angular/material/menu";
import { MatToolbar } from "@angular/material/toolbar";
import { RouterLink, RouterLinkActive } from "@angular/router";

@Component({
  selector: 'app-nav',
  standalone: true,
  imports: [
    MatIconModule,
    MatMenuModule,
    MatListModule,
    MatToolbar,
    MatButton,
    RouterLink,
    RouterLinkActive
  ],
  templateUrl: './nav.component.html',
  styleUrl: './nav.component.scss'
})
export class NavComponent {
  public navItems = [
    { link: 'authors', label: 'Authors',icon: 'people_alt'},
    { link: 'books', label: 'Books' ,icon: 'auto_stories'},
    { link: 'reports', label: 'Reports',icon: 'insert_chart_outlined'}
  ];
}
