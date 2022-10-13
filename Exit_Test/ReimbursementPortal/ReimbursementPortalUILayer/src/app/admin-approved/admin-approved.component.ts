import { Component, OnInit } from '@angular/core';
import {ApiServiceService} from '../shared/api-service.service'



@Component({
  selector: 'app-admin-approved',
  templateUrl: './admin-approved.component.html',
  styleUrls: ['./admin-approved.component.css']
})
export class AdminApprovedComponent implements OnInit {
  allData: any;

  constructor(private service:ApiServiceService) { }

  ngOnInit(): void {
    this.service.getReimbursement("Approved").subscribe((res)=>{       
      console.log(res,"res==>")
      this.allData=res
      console.log(this.allData)
            
    })
  }


}
