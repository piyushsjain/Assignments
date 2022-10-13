import { Component, OnInit } from '@angular/core';
import {ApiServiceService} from '../shared/api-service.service'

@Component({
  selector: 'app-admin-decline',
  templateUrl: './admin-decline.component.html',
  styleUrls: ['./admin-decline.component.css']
})
export class AdminDeclineComponent implements OnInit {
  allData: any;

  constructor(private service:ApiServiceService) { }

  ngOnInit(): void {
    this.service.getReimbursement("Declined").subscribe((res)=>{       
      console.log(res,"res==>")
      this.allData=res
            
    })
  }

}
