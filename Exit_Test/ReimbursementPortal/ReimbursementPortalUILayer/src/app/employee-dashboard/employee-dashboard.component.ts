import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators ,FormControl,FormGroupName } from '@angular/forms';
import {ApiServiceService} from '../shared/api-service.service'
import {ActivatedRoute, Router} from "@angular/router";

@Component({
  selector: 'app-employee-dashboard',
  templateUrl: './employee-dashboard.component.html',
  styleUrls: ['./employee-dashboard.component.css']
})
export class EmployeeDashboardComponent implements OnInit {
  showModal: any
  registerForm: any;
  submitted = false;
  allData: any;

  user:any
  data:any
  data2:any
  errormsg:any
  successmsg:any
  id:any

  constructor(private route:ActivatedRoute,private router: Router,private service:ApiServiceService) { }

  ngOnInit(): void {
    
    this.route.queryParams.subscribe((res)=>{
      console.log(res,'res1==>')      
      this.user=JSON.parse(res['user'])
      this.userForm.patchValue({
        emailAddress:this.user
      })
    })

    this.service.MyReimbursements(this.user).subscribe((res)=>{
      console.log(res,"res==>")
      this.allData=res
    })
  }

  show()
  {
    this.showModal = true; 
    
  }
  hide()
  {
    this.showModal = false;
  }

  userForm= new FormGroup({
    'date':new FormControl('',Validators.required),    
    'reimbursementType' :new FormControl('',Validators.required),
    'requestedValue' :new FormControl('',Validators.required),
    'currency' :new FormControl('',Validators.required),
    'emailAddress':new FormControl('')
      
  })

 
  addReimbursement(){
    if(this.userForm.valid){      
           this.service.addReimbursement(this.userForm.value).subscribe((res) =>{
           console.log(res,'res==>');                
           this.data = JSON.stringify(res);
           this.data2=JSON.parse(this.data)
           if(this.data2["success"]==true){
            this.showModal = false;
            window.location.reload();
                                 
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

  editForm(){
    this.router.navigate(['employee-Dashboard/edit-reimbursement/:id']);
  }

  delete(id:any){
    this.service.delete(id).subscribe((res)=>{
      console.log(res,'deleteStudentres==>')
      window.location.reload();
  })
}
}