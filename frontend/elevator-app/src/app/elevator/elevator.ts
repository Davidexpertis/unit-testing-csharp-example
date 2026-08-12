import { Component, OnInit, signal } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { ElevatorService, ElevatorStatus } from '../elevator.service';

@Component({
  selector: 'app-elevator',
  imports: [FormsModule],
  templateUrl: './elevator.html',
  styleUrl: './elevator.css'
})
export class ElevatorComponent implements OnInit {
  protected readonly status = signal<ElevatorStatus | null>(null);
  protected readonly errorMessage = signal<string | null>(null);

  protected employeeName = '';
  protected employeeWeight = 70;
  protected isExecutive = false;

  constructor(private readonly elevatorService: ElevatorService) {}

  ngOnInit(): void {
    this.refreshStatus();
  }

  protected refreshStatus(): void {
    this.elevatorService.getStatus().subscribe({
      next: (status) => {
        this.status.set(status);
        this.errorMessage.set(null);
      },
      error: () => this.errorMessage.set('Could not reach the Elevator API. Is the backend running?')
    });
  }

  protected addEmployee(): void {
    this.elevatorService
      .inUser({ name: this.employeeName, weight: this.employeeWeight, isExecutive: this.isExecutive })
      .subscribe({
        next: (status) => this.status.set(status),
        error: () => this.errorMessage.set('Could not reach the Elevator API. Is the backend running?')
      });
  }

  protected removeEmployee(): void {
    this.elevatorService
      .outUser({ name: this.employeeName, weight: this.employeeWeight, isExecutive: this.isExecutive })
      .subscribe({
        next: (status) => this.status.set(status),
        error: () => this.errorMessage.set('Could not reach the Elevator API. Is the backend running?')
      });
  }
}
