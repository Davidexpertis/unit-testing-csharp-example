import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';

export interface Employee {
  name: string;
  weight: number;
  isExecutive: boolean;
}

export interface ElevatorStatus {
  maxWeightAllowed: number;
  currentWeight: number;
  maxWeightAllowedReached: boolean;
}

@Injectable({
  providedIn: 'root'
})
export class ElevatorService {
  private readonly baseUrl = 'http://localhost:5173/api/elevator';

  constructor(private readonly http: HttpClient) {}

  getStatus(): Observable<ElevatorStatus> {
    return this.http.get<ElevatorStatus>(`${this.baseUrl}/status`);
  }

  inUser(employee: Employee): Observable<ElevatorStatus> {
    return this.http.post<ElevatorStatus>(`${this.baseUrl}/in`, employee);
  }

  outUser(employee: Employee): Observable<ElevatorStatus> {
    return this.http.post<ElevatorStatus>(`${this.baseUrl}/out`, employee);
  }

  goToVipSection(employee: Employee): Observable<boolean> {
    return this.http.post<boolean>(`${this.baseUrl}/vip-section`, employee);
  }
}
