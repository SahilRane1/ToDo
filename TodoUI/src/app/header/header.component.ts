import { NgClass, NgStyle } from '@angular/common';
import { Component, OnInit } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { TodoService } from '../services/todo.service';
import { Todo } from '../Models/todo';

@Component({
  selector: 'app-header',
  standalone: true,
  imports: [FormsModule, NgClass, NgStyle],
  templateUrl: './header.component.html',
  styleUrl: './header.component.css'
})
export class HeaderComponent implements OnInit {

  title="Todo Management System";
  todos:Todo[]=[];

  constructor(private todoService : TodoService){}

  


  ngOnInit() : void{
    this.todoService.getTodos().subscribe({
      next:(response)=>{
        this.todos=response;
      },
      error:(err)=>{
        console.error("Failes to load Todos",err);
      }
    });
  }


  

  // username="Sahil";  
  // isLoggedIn=true;
  // todos = [
  //   {id:1, title:"Learn Angular"},
  //   {id:2, title:"Build Todo App"},
  //   {id:3, title:"Prepare for an interview"}
  // ]
  // role = "Manager1";
  // isCompleted=false;
  // textcolor="green";

  // isDisabled=false;
  // onButtonClick()
  // {
  //   alert("Welcome to Angular!");
  // }
  // message="";
  // showMessage(){
  //   this.message="Button Clicked!";
  // }
  // website="https://angular.dev";
}
