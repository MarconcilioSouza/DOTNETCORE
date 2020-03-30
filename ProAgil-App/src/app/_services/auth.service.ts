import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { JwtHelperService } from '@auth0/angular-jwt';
import { map } from 'rxjs/operators';
import { Constants } from '../util/Constants';

@Injectable({
  providedIn: 'root'
})
export class AuthService {

  baseURL = Constants.baseURL + '/api/user/';
  jwtHelper = new JwtHelperService();
  decodedToken: any;

  constructor(private http: HttpClient) { }

  login(model: any) {
    return this.http
      .post(`${this.baseURL}login`, model).pipe(
        map((response: any) => {
          const user = response;
          // salvar o token em memoria local do browser, não deve ser usado o cookie porque ele pode ser acessado
          // obtido por outra pessoa.
          if (user) {
            localStorage.setItem('token', user.token);
            this.decodedToken = this.jwtHelper.decodeToken(user.token);
            sessionStorage.setItem('username', this.decodedToken.unique_name);
          }
        })
      );
  }

  register(model: any) {
    return this.http.post(`${this.baseURL}register`, model);
  }

  loggedIn() {
    const token = localStorage.getItem('token');
    // determina se o token esta inspirado, vendo o paramentro passado da api.
    // que tem Expires = DateTime.Now.AddDays(1), usar um tempo menor para uma api de produção
    return !this.jwtHelper.isTokenExpired(token);
  }

}