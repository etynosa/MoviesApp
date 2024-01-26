import { HttpClient } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';
import { APIResponse, Movie } from './models/movie.model';
import { SelectItem } from 'primeng/api';
import { DataView } from 'primeng/dataview';

interface WeatherForecast {
  date: string;
  temperatureC: number;
  temperatureF: number;
  summary: string;
}

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent implements OnInit {
  public forecasts: WeatherForecast[] = [];
  public movies: Movie[] = [];
  sortOrder: number = 0;
  sortOptions: SelectItem[] = [];


  sortField: string = '';

  constructor(private http: HttpClient) {}

  ngOnInit() {
    this.getForecasts();
    this.getMovies();
  }

  getForecasts() {
    this.http.get<WeatherForecast[]>('/weatherforecast').subscribe(
      (result) => {
        this.forecasts = result;
      },
      (error) => {
        console.error(error);
      }
    );
  }
  
  getMovies() {
    this.http.get<APIResponse>('https://localhost:7045/api/v1/Movie/all').subscribe(
      (result) => {
        this.movies = result.data
      },
      (error) => {
        console.error("i am logging", error);
      }
    );
  }

  onSortChange(event: any) {
    const value = event.value;

    if (value.indexOf('!') === 0) {
        this.sortOrder = -1;
        this.sortField = value.substring(1, value.length);
    } else {
        this.sortOrder = 1;
        this.sortField = value;
    }
}

onFilter(dv: DataView, event: Event) {
    dv.filter((event.target as HTMLInputElement).value);
}

  title = 'moviesapp.client';
}
