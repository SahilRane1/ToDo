import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Todo } from '../Models/todo';
import { Observable } from 'rxjs';
import { environment } from '../../environments/environment';

@Injectable({
  providedIn: 'root'
})
export class TodoService {

  private apiUrl=`${environment.apiUrl}/Todos`;

  constructor(private http : HttpClient) { 
    console.log("Todo Service Created");
    
  }
  // getMessage(): string { 
  //   return "Hello from Todo Service";
  // } 

  getTodos(): Observable<Todo[]>{
    return this.http.get<Todo[]>(this.apiUrl);
  }
}
