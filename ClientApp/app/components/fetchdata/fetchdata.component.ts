import { Component, Inject } from "@angular/core";
import { Http } from "@angular/http";

@Component({
    selector: "fetchdata",
    templateUrl: "./fetchdata.component.html"
})
export class FetchDataComponent {
    public forecasts: WeatherForecast[];
    public tempSummary: WeatherAddOn;

    constructor(private http: Http, @Inject("BASE_URL") baseUrl: string) {
        http.get(baseUrl + "api/WeatherData/Forecasts").subscribe(result => {
            this.forecasts = result.json() as WeatherForecast[];
        }, error => console.error(error));
    }    

    addRow() {
        
        let rnd = Math.floor(Math.random() * -40) + 50
        this.http.get('api/WeatherData/GetSummary/' + rnd).subscribe(result => {
            this.tempSummary = result.json() as WeatherAddOn;
        });

        this.forecasts.push({ date: new Date(Date.now()), temperatureC: this.tempSummary.temperatureC, temperatureF: this.tempSummary.temperatureF, summary: this.tempSummary.summary });        
    }

}

interface WeatherForecast {
    date: Date;
    temperatureC: number;
    temperatureF: number;
    summary: string;
}

interface WeatherAddOn {
    summary: string;
    temperatureC: number;
    temperatureF: number;
}
