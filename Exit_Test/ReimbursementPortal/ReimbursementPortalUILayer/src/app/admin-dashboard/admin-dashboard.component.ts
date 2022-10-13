import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators ,FormControl,FormGroupName } from '@angular/forms';
import {ApiServiceService} from '../shared/api-service.service'
import {ActivatedRoute, Router} from "@angular/router";

@Component({
  selector: 'app-admin-dashboard',
  templateUrl: './admin-dashboard.component.html',
  styleUrls: ['./admin-dashboard.component.css']
})

export class AdminDashboardComponent implements OnInit {
  allData: any;
  showModal:any;
  getParamId: any;
  data:any
  data2:any
  successmsg:any
  errormsg:any
  reimbursementData: any;
  reimbursementId: any;

  emailAddress:any
  reimbursementType:any
  admin:any
  constructor(private Route:ActivatedRoute,private router: Router,private service:ApiServiceService) { }
  

  ngOnInit(): void {

    this.Route.queryParams.subscribe((res)=>{
      console.log(res,'res1==>')      
      this.admin=JSON.parse(res['admin'])
      this.userForm.patchValue({
        approvedBy:this.admin
      })
    })

    this.service.getReimbursement("Pending").subscribe((res)=>{       
      console.log(res,"res==>")
      this.allData=res
            
    })
   
  }
  
  userForm= new FormGroup({
    'approvedBy':new FormControl('',Validators.required),    
    'approvedValue' :new FormControl('',Validators.required),  
    'internalNotes':new FormControl('')      
  })

  approveReimbursement(){    
      if(this.userForm.valid){          
        this.service.approveReimbursement(this.reimbursementId,this.userForm.value).subscribe((res) =>{
        console.log(res,'res==>');                
        this.data = JSON.stringify(res);
        this.data2=JSON.parse(this.data)

        if(this.data2["success"]==true){
          this.router.navigate(['/admin-Dashboard']);   
          this.showModal = false;
          window.location.reload()
          this.successmsg="Reimbursement Approved Succefully"
         }
         else{
            this.errormsg=this.data2["errors"]
          }
   
       }
       ,error=>{
          console.log(error)       
       }
       );     
    }
  
  else{
        this.errormsg='please check all the feilds and fill properlly'
        
  }
  
  }

  
  show(id:any)
  {
    this.showModal = true;

    this.reimbursementId=id
  }
  hide()
   {
     this.showModal = false;
   }
  
  decline(id:any){
    this.service.declineReimbursement(id,this.userForm.value).subscribe((res) =>{
      window.location.reload()
  })

}


}
