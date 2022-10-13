import { Component, OnInit } from '@angular/core';
import {Router} from "@angular/router";

@Component({
  selector: 'app-admin-common',
  templateUrl: './admin-common.component.html',
  styleUrls: ['./admin-common.component.css']
})
export class AdminCommonComponent implements OnInit {

  constructor(private router: Router) { }

  ngOnInit(): void {
  }
  
  decline(){
    this.router.navigate(['/admin-decline'])

  }

  approved(){
    this.router.navigate(['/admin-approved'])
  }

  panding(){
    this.router.navigate(['/admin-Dashboard'])
  }

 
}
