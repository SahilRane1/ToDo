import { Injectable } from '@angular/core';
import { environment } from '../../environments/environment';
import { HttpClient } from '@angular/common/http';
import { LoginRequest } from '../Models/loginRequest';
import { Observable } from 'rxjs';
import { LoginResponse } from '../Models/loginResponse';

@Injectable({
  providedIn: 'root'
})
export class AuthService {

  private readonly apiUrl =`${environment.apiUrl}/Auth`;

  constructor(private http:HttpClient) { }

  login(request: LoginRequest):Observable<LoginResponse>{
    return this.http.post<LoginResponse>(
      `${this.apiUrl}/login`,
      request
    );
  }
  

}
