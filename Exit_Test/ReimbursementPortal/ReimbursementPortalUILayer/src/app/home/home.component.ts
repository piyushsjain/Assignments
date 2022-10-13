import { Component, OnInit } from '@angular/core';
import { FormControl, FormGroup, FormGroupName, SelectControlValueAccessor, Validators } from '@angular/forms'
import { ApiServiceService } from '../shared/api-service.service'
import { Router, ActivatedRoute } from "@angular/router";
import { HttpErrorResponse, HttpHeaders, HttpParams } from '@angular/common/http';
import { throwError } from 'rxjs';
@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.css']
})
export class HomeComponent implements OnInit {
  data: any
  data2: any
  errormsg: any

  constructor(private route: ActivatedRoute, private router: Router, private service: ApiServiceService) { }

  ngOnInit(): void {
  }

  userForm = new FormGroup({
    'emailAddress': new FormControl('', Validators.required),
    'password': new FormControl('', Validators.required),

  })

  Login() {
    if (this.userForm.valid) {
      //console.log(this.userForm.value)
      this.service.Login(this.userForm.value).subscribe((res) => {
        //console.log(res,'res==>'); 
        this.data = JSON.stringify(res);
        this.data2 = JSON.parse(this.data)

        if (this.data2["success"] == true) {
          if (this.userForm.value['emailAddress'] == 'admin1@gmail.com' || this.userForm.value['emailAddress'] == 'admin2@gmail.com' || this.userForm.value['emailAddress'] == 'admin3@gmail.com') {
            let admin = this.userForm.value['emailAddress']
            this.router.navigate(['/admin-Dashboard'], {
              queryParams: { admin: JSON.stringify(admin) }
            }
            );
          }
          else {
            let user = this.userForm.value['emailAddress']
            console.log(user)
            this.router.navigate(['/employee-Dashboard'], {
              queryParams: { user: JSON.stringify(user) }
            });

          }
        }
        else {
          this.errormsg = this.data2["errors"]
        }
      });
    }
    else {
      this.errormsg = 'All fields are required !!'
    }
  }
}
