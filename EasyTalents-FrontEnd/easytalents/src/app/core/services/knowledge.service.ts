import { Injectable } from '@angular/core';
import { environment } from 'src/environments/environment';
import { Observable } from 'rxjs';
import { HttpClient, HttpResponse } from '@angular/common/http';
import { Knowledge } from '../models/knowledge.mode';

@Injectable({
    providedIn: 'root'
})

export class KnowledgeService {
    private apiControllerUrl = `${environment.API_URL}Knowledge`;

    constructor(private http: HttpClient) { }

    getList(): Observable<HttpResponse<Knowledge[]>> {
        return this.http.get<Knowledge[]>(
            this.apiControllerUrl, { observe: 'response' });
    }
}