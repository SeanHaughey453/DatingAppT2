import { HttpClient } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';
import { User } from './_models/user';
import { AccountService } from './_services/account.service';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent implements OnInit{
  title = 'The Dating App';
  users: any;

  constructor( private accountService: AccountService){

  }
  ngOnInit(){
  
    this.setCurrentUser();  
  }

  setCurrentUser(){//gets the user object with token from local storage and sets it in the account service
    const user: User = JSON.parse(localStorage.getItem('user'));
    this.accountService.setCurrentUser(user);
  }
 
}
