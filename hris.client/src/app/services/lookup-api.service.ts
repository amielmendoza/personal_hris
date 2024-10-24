import { Injectable, Inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { API_BASE_URL } from '../app.config';

@Injectable({
  providedIn: 'root'
})
export class LookupApiService {
  constructor(
    private http: HttpClient,
    @Inject(API_BASE_URL) private baseUrl: string
  ) {}

  getAllLookupData(): Observable<{ [key: string]: string[] }> {
    const authToken = localStorage.getItem("authToken");
    return this.http.get<{ [key: string]: string[] }>(`${this.baseUrl}/lookup`, { headers: { 'Authorization': `Bearer ${authToken}` } });
  }
}
