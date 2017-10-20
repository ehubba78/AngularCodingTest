import { Component, Inject } from '@angular/core';
import { Http } from '@angular/http';

@Component({
    selector: 'home',
    templateUrl: './home.component.html'
})
export class HomeComponent  {

    public temperature: GetTemp;

    constructor(http: Http, @Inject("BASE_URL") baseUrl: string) {
        http.get(baseUrl + "api/WeatherData/GetCurrTemp").subscribe(result => {
            this.temperature = result.json() as GetTemp;
        }, error => console.error(error));
    }
}

interface GetTemp {
    temperature: string
}

