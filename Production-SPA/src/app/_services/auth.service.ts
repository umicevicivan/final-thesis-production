import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { map } from 'rxjs/operators';
import { JwtHelperService } from '@auth0/angular-jwt';
import { environment } from 'src/environments/environment';


@Injectable({
  providedIn: 'root',
})
export class AuthService {
  constructor(private http: HttpClient) {}
  baseUrl = environment.apiUrl;
  jwtHelper = new JwtHelperService();
  decodedToken: any;

  login(user: any) {
    return this.http.post(this.baseUrl + 'auth/login', user).pipe(
      map((response: any) => {
        const userFromServer = response;
        if (userFromServer) {
          localStorage.setItem('token', userFromServer.token);
          this.decodedToken = this.jwtHelper.decodeToken(userFromServer.token)
        }
      })
    );
  }

  loggedIn(){
    const token = localStorage.getItem('token');
    return !this.jwtHelper.isTokenExpired(token);
  }
}
