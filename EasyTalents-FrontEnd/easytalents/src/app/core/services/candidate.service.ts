import { Injectable } from '@angular/core';
import { environment } from 'src/environments/environment';
import { Observable } from 'rxjs';
import { HttpClient, HttpResponse } from '@angular/common/http';
import { catchError } from 'rxjs/operators';
import { Candidate } from '../models/candidate.model';

@Injectable({
    providedIn: 'root'
})

export class CandidateService {
    private apiControllerUrl = `${environment.API_URL}Candidate`;

    constructor(private http: HttpClient) { }

    getList(): Observable<HttpResponse<Candidate[]>> {
        return this.http.get<Candidate[]>(
            this.apiControllerUrl, { observe: 'response' });
    }

    getById(id: string): Observable<HttpResponse<Candidate>> {
        return this.http.get<Candidate>(
            `${this.apiControllerUrl}/${id}`, { observe: 'response' });
    }

    create(candidate: Candidate): Observable<HttpResponse<Candidate[]>> {
        return this.http.post<Candidate[]>(
            this.apiControllerUrl, candidate, { observe: 'response' });
    }

    update(candidate: Candidate): Observable<HttpResponse<Candidate[]>> {
        return this.http.put<Candidate[]>(
            this.apiControllerUrl, candidate, { observe: 'response' });
    }

    delete(id: string): Observable<HttpResponse<Candidate[]>> {
        return this.http.delete<Candidate[]>(
            `${this.apiControllerUrl}/${id}`, { observe: 'response' });
    }
}