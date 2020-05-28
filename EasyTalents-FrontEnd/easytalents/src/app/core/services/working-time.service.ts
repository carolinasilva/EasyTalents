import { Injectable } from '@angular/core';
import { environment } from 'src/environments/environment';
import { Observable } from 'rxjs';
import { HttpClient, HttpResponse } from '@angular/common/http';
import { WorkingTime } from '../models/working-time.model';

@Injectable({
    providedIn: 'root'
})

export class WorkingTimeService {
    private apiControllerUrl = `${environment.API_URL}WorkingTime`;

    constructor(private http: HttpClient) { }

    getList(): Observable<HttpResponse<WorkingTime[]>> {
        return this.http.get<WorkingTime[]>(
            this.apiControllerUrl, { observe: 'response' });
    }
}