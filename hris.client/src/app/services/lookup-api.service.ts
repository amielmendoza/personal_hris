import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class LookupApiService {
  private baseUrl = 'https://localhost:7234/Lookup';

  constructor(private http: HttpClient) {}

  // If you need to get all lookup data at once
  getAllLookupData(): Observable<{ [key: string]: string[] }> {
    const authToken = localStorage.getItem("authToken");
    return this.http.get<{ [key: string]: string[] }>(this.baseUrl, { headers: { 'Authorization': `Bearer ${authToken}` } });
  }
}
