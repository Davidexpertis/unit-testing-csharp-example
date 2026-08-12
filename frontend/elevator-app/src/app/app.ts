import { Component, signal } from '@angular/core';
import { ElevatorComponent } from './elevator/elevator';

@Component({
  selector: 'app-root',
  imports: [ElevatorComponent],
  templateUrl: './app.html',
  styleUrl: './app.css'
})
export class App {
  protected readonly title = signal('elevator-app');
}
