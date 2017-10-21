import { Component, Inject } from '@angular/core';
import { Http } from '@angular/http';

@Component({
    selector: 'home',
    templateUrl: './home.component.html'
})
export class HomeComponent  {

    public message: GetTemp;

    constructor(http: Http, @Inject("BASE_URL") baseUrl: string) {
        http.get(baseUrl + "api/WeatherData/GetCurrTemp").subscribe(result => {
            this.message = result.json() as GetTemp;
        }, error => console.error(error));
    }
}

interface GetTemp {    
    city: string;
    temperatureC: string;
    temperatureF: string;
    localTime: string;
    message: string;
    weather: string;
    relative_humidity: string;
}

