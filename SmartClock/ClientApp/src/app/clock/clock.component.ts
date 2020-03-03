import { Component, OnInit } from '@angular/core';
import { ClockService } from '../clock.service';

@Component({
  selector: 'app-clock',
  templateUrl: './clock.component.html',
  styleUrls: ['./clock.component.scss']
})
export class ClockComponent implements OnInit {
  date: Date;

  constructor(private clockService: ClockService) { }

  ngOnInit(): void {
    this.clockService.date.subscribe(d => this.date = d);
  }

}
