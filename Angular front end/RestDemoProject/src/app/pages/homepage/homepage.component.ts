import { Component, OnInit, ViewChild } from '@angular/core';
import { ConsoleReporter } from 'jasmine';
import * as moment from 'moment';
import { WeatherInfo } from 'src/app/models/weatherInfo.model';
import { ApiComponentService } from 'src/app/services/api-component.service';


@Component({
  selector: 'app-homepage',
  templateUrl: './homepage.component.html',
  styleUrls: ['./homepage.component.scss']
})
export class HomepageComponent implements OnInit {

  weatherinfos: WeatherInfo[];
  newWeather: WeatherInfo = { degrees: 20, dateTime: moment().format('YYYY-MM-DDTHH:mm') };

  editingRecord = false;
  insertRecord = true;

  editingId = 0;
  editingWeatherRecord: WeatherInfo;

  constructor(
    private weatherService: ApiComponentService,
    ) { }

  ngOnInit(): void {
    this.weatherinfos = [];
    this.newWeather.dateTime = moment().format('YYYY-MM-DDTHH:mm');
    this.newWeather.degrees = 20;
    this.Search();
  }

  Search() {
    this.weatherService.GetWeathers().subscribe(wInfo => {
      this.weatherinfos = wInfo;
    });
  }

  public PostWeather(){
    this.weatherService.PostWeather(this.newWeather).subscribe(w => this.weatherinfos.push(w));
  }

  public PutWeather(){
    this.weatherService.PutWeather(this.editingWeatherRecord).subscribe();
    this.weatherinfos[this.weatherinfos.findIndex(x => x.id === this.editingWeatherRecord.id)] = this.editingWeatherRecord;
  }

  public DeleteWeather(idW: number){
    this.weatherService.DeleteWeather(idW).subscribe();
    this.weatherinfos.splice(this.weatherinfos.findIndex(x => x.id === idW), 1);
  }

  editButton(id: number){
    if (id === this.editingId){
      this.editingRecord = !this.editingRecord;
      this.insertRecord = !this.insertRecord;
    }else{
      this.editingRecord = true;
      this.insertRecord = false;
      this.editingId = id;
    }
    if(this.editingRecord){
      this.editingWeatherRecord = this.weatherinfos[this.weatherinfos.findIndex(x => x.id === id)];
    }
  }

}
