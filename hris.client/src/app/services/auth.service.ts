import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { catchError, map, Observable, of } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class AuthService {

  constructor(private http: HttpClient) {}
  login(email: string, password: string): Observable<any> {
    let parameter = {"Username": email, "Password": password};
    return this.http.post('/auth/login', parameter).pipe(
      map(response => {
        return response;
      },
      catchError(error => {
        throw new Error('Invalid credentials');
      })
    ));
  }

  validate(token: string): Promise<boolean> {
    return this.http.post('/auth/validate?token='+token, null).toPromise().then(response => {
        return !!response;
    }).catch(error=>{
      console.error('Error validating token.', error);
      return false;
    });
  }
}
