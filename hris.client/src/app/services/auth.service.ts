import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { catchError, map, Observable, of } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class AuthService {

  constructor(private http: HttpClient) {}
  login(email: string, password: string): Observable<any> {
    // Replace with actual login logic, such as an HTTP request
    let parameter = {"Username": email, "Password": password};
    return this.http.post('/auth/login', parameter).pipe(
      map(response => {
        return true;
      },
      catchError(error => {
        throw new Error('Invalid credentials');
      })
    ));
  }
}
