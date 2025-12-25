import { Component, inject } from '@angular/core';
import { RouterOutlet } from '@angular/router';
import { SharedDataService } from '../../../infrastructure/comunication/shared-data.service';

@Component({
  selector: 'app-root',
  standalone: true,
  imports: [RouterOutlet],
  //template: `<div> <h1> {{title}} </h1>
  //            <div> My first component </div>
  //          </div>`,
  //styles: [`div { color: blue; }`]
  templateUrl: './app.component.html',
  styleUrl: './app.component.scss'
})
export class AppComponent {
  private SharedDataService = inject(SharedDataService);

  //constructor(private SharedDataService: SharedDataService) {}

  public title: string = 'full-stack-ng';
  public name: string = 'Erick';

  public onClickMe(): void {
    console.log('Clicked!');
    console.log(this.SharedDataService.getFullName(this.name, 'Aróstegui'));
  }
}
