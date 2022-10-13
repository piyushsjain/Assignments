import { Component, OnInit } from '@angular/core';
import { FormControl, FormGroup, FormGroupName, Validators } from '@angular/forms'
import { ApiServiceService } from '../shared/api-service.service'
import { Router } from "@angular/router";



@Component({
  selector: 'app-signup',
  templateUrl: './signup.component.html',
  styleUrls: ['./signup.component.css']
})
export class SignupComponent implements OnInit {
  data: any
  data2: any
  errormsg: any
  constructor(private router: Router, private service: ApiServiceService) { }

  ngOnInit(): void {
  }


  userForm = new FormGroup({
    'fullname': new FormControl('', Validators.required),
    'emailAddress': new FormControl('', Validators.required),
    'panNumber': new FormControl('', Validators.required),
    'bank': new FormControl('', Validators.required),
    'bankNumber': new FormControl('', Validators.required),
    'password': new FormControl('', Validators.required),
    'confirmPassword': new FormControl('', Validators.required)
  })


  Signup() {
    if (this.userForm.valid) {
      var formvalue = this.userForm.value;
      var pwd = this.userForm.value.password;
      var cnfrmpwd = this.userForm.value.confirmPassword;
      console.log(pwd +" "+ cnfrmpwd);
      if (pwd === cnfrmpwd) {
        //console.log(this.userForm.value)
        //console.log(this.userForm.value.password,this.userForm.value.confirmPassword)
        this.service.Signup(formvalue).subscribe((res) => {
          //console.log('res==>');
          this.data = JSON.stringify(res);
          this.data2 = JSON.parse(this.data)
          if (this.data2["success"] == true) {
            console.log("Success");
            this.router.navigate(['']);
          }
          else {
            this.errormsg = this.data2["errors"]
          }
        }, error => {
          console.log(error);
        });
      }
      else {
        this.errormsg = "Password Doesn't Match !! "
      }

    }

    else {
      this.errormsg = 'Please Complete All Fields !!'

    }

  }

  back() {
    this.router.navigate([''])
  }
}
