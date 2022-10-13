import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators, FormControl, FormGroupName } from '@angular/forms';
import { ApiServiceService } from '../shared/api-service.service'
import { ActivatedRoute, Router } from "@angular/router";

@Component({
  selector: 'app-edit-reimbursement',
  templateUrl: './edit-reimbursement.component.html',
  styleUrls: ['./edit-reimbursement.component.css']
})
export class EditReimbursementComponent implements OnInit {
  errormsg: any
  getParamId: any
  reimbursementData: any
  data: any
  data2: any
  successmsg: any
  user: any
  constructor(private Route: ActivatedRoute, private router: Router, private service: ApiServiceService) { }

  ngOnInit(): void {
    this.getParamId = this.Route.snapshot.paramMap.get('id')
    this.service.getReimbursementByid(this.getParamId).subscribe((res) => {
      console.log(res, 'res ==>')

      this.reimbursementData = JSON.parse(JSON.stringify(res))
      this.userForm.patchValue({
        date: this.reimbursementData['date'],
        reimbursementType: this.reimbursementData['reimbursementType'],
        requestedValue: this.reimbursementData['requestedValue'],
        currency: this.reimbursementData['currency'],
        emailAddress: this.reimbursementData['emailAddress']
      })
    })


  }

  userForm = new FormGroup({
    'date': new FormControl('', Validators.required),
    'reimbursementType': new FormControl('', Validators.required),
    'requestedValue': new FormControl('', Validators.required),
    'currency': new FormControl('', Validators.required),
    'emailAddress': new FormControl('', Validators.required)
  })

  editReimbursement() {
    if (this.userForm.valid) {
      this.service.editReimbursement(this.reimbursementData['id'], this.userForm.value).subscribe((res) => {
        console.log(res, 'res==>');
        this.data = JSON.stringify(res);
        this.data2 = JSON.parse(this.data)

        let user = this.userForm.value['emailAddress']

        if (this.data2["success"] == true) {
          this.router.navigate(['/employee-Dashboard'],
            { queryParams: { user: JSON.stringify(user) } });
        }
        else {
          this.errormsg = this.data2["errors"]
        }

      },
        error => {
          console.log(error)
        }
      );
    }

    else {
      this.errormsg = 'please check all the feilds and fill properlly'

    }

  }
  back() {
    let user = this.userForm.value['emailAddress']
    this.router.navigate(['/employee-Dashboard'],{ queryParams: { user: JSON.stringify(user) } });
  }
}
function queryParams(arg0: string[], queryParams: any, arg2: { employeeData: string; }) {
  throw new Error('Function not implemented.');
}

