import { AuthService } from './services/auth.service';
import { Injectable } from '@angular/core';
import {
  CanActivate,
  ActivatedRouteSnapshot,
  RouterStateSnapshot,
  UrlTree,
} from '@angular/router';
import { Observable, of } from 'rxjs';
// import { AuthService } from './auth.service'; // Import your AuthService
import { Router } from '@angular/router';

@Injectable({
  providedIn: 'root',
})
export class AuthGuard implements CanActivate {
  constructor(private authService: AuthService, private router: Router) {}

  canActivate(
    route: ActivatedRouteSnapshot,
    state: RouterStateSnapshot
  ):
    | Observable<boolean | UrlTree>
    | Promise<boolean | UrlTree>
    | boolean
    | UrlTree {
    const token = localStorage.getItem('authToken') ?? '';

    if (!token) {
      this.router.navigate(['/login']);
      return false;
    }

    return this.authService
      .validate(token)
      .then((response) => {
        if (!!response) return true;
        else {
          localStorage.removeItem("authToken");
          this.router.navigate(['/login']);
        return false;}
      })
      .catch((error) => {
        console.error('Error validating token.', error);
        localStorage.removeItem("authToken");
        this.router.navigate(['/login']);
        return false;
      });
  }
}
