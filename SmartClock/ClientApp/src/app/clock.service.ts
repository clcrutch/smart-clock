import { Injectable } from '@angular/core';
import { Subject, Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class ClockService {

  private dateSubject = new Subject<Date>();
  date: Observable<Date>;

  constructor() {
    this.date = this.dateSubject.asObservable();

    setInterval(() => this.dateSubject.next(new Date()), 1000);
  }
}
