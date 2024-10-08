import { Component, OnInit } from '@angular/core';
import { RouterOutlet } from '@angular/router';
import { HttpClient } from '@angular/common/http';

@Component({
  selector: 'app-root',
  standalone: true,
  imports: [RouterOutlet],
  templateUrl: './app.component.html',
  styleUrl: './app.component.css'
})
export class AppComponent implements OnInit {
  title = 'client';
  weatherForecasts: any;

  constructor(private http: HttpClient){

  }
  ngOnInit(): void {
    this.http.get('http://localhost.5264/weatherforecast').subscribe({
      next: (response) => this.weatherForecasts = response,
      error: (e) => console.error(e),
      complete: () => console.log('complete')
    })
    // throw new Error('Method not implemented.');
  }
}
