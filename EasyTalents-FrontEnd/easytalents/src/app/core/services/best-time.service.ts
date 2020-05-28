import { Injectable } from '@angular/core';
import { environment } from 'src/environments/environment';
import { Observable } from 'rxjs';
import { HttpClient, HttpResponse } from '@angular/common/http';
import { BestTime } from '../models/best-time.model';

@Injectable({
    providedIn: 'root'
})

export class BestTimeService {
    private apiControllerUrl = `${environment.API_URL}BestTime`;

    constructor(private http: HttpClient) { }

    getList(): Observable<HttpResponse<BestTime[]>> {
        return this.http.get<BestTime[]>(
            this.apiControllerUrl, { observe: 'response' });
    }
}