import { Component, OnInit } from '@angular/core';
import { WeatherInfo } from 'src/app/models/weatherInfo.model';
import { ApiComponentService } from 'src/app/services/api-component.service';

@Component({
  selector: 'app-homepage',
  templateUrl: './homepage.component.html',
  styleUrls: ['./homepage.component.scss']
})
export class HomepageComponent implements OnInit {

  weatherinfos: object;

  constructor(
    private weatherService: ApiComponentService,
    ) { }

  ngOnInit(): void {
    this.weatherinfos = [];
    this.Search();
  }

  // tslint:disable-next-line: typedef
  Search() {
    this.weatherService.GetWeathers().subscribe(wInfo => {
      this.weatherinfos = wInfo;
      console.log(this.weatherinfos);
    });
  }

}
