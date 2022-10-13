import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from "@angular/common/http";
import { Observable } from 'rxjs';


@Injectable({
  providedIn: 'root'
})
export class ApiServiceService {

  constructor(private http: HttpClient) { }

  readonly authURL = 'http://localhost:21971/api/Account'
  readonly reimbursementURL = 'http://localhost:21971/apiReimbursement/Reimbursement'
  readonly AdminURL = 'http://localhost:21971/apiAdmin/Admin'

  // formData:Signup=new Signup()

  Signup(employee: any) {
    return this.http.post(this.authURL, employee);
  }

  //readonly baseURL1 = 'http://localhost:21971/api/Account/Login'

  Login(employee: any) {
    return this.http.post(`${this.authURL}/Login`, employee);
  }

  addReimbursement(reimbursement: any) {
    return this.http.post(this.reimbursementURL, reimbursement);
  }

  MyReimbursements(id: any) {
    return this.http.get(`${this.reimbursementURL}/${id}`);
  }

  //get single student
  //readonly Url1 = 'http://localhost:21971/apiReimbursement/Reimbursement/getReimbursement'
  
  getReimbursementByid(id: any) {
    let reimbursementid = id
    return this.http.get(`${this.reimbursementURL}/getReimbursement/${reimbursementid}`)
  }

  editReimbursement(id: any, reimbursement: any) {
    return this.http.post(`${this.reimbursementURL}/${id}`, reimbursement)
  }

  delete(id: any) {
    return this.http.delete(`${this.reimbursementURL}/${id}`)
  }
  //readonly Url2 = 'http://localhost:21971/apiReimbursement/Reimbursement/allReimbursement'
  
  allReimbursement() {
    return this.http.get(`${this.reimbursementURL}/allReimbursement`)
  }

  approveReimbursement(id: any, reimbursement: any) {
    return this.http.post(`${this.AdminURL}/${id}`, reimbursement)
  }

  getReimbursement(id: any) {
    return this.http.get(`${this.AdminURL}/${id}`)
  }

  //readonly AdminUrl1 = 'http://localhost:21971/apiAdmin/Admin/declineReimbursement'
  
  declineReimbursement(id: any, reimbursement: any) {
    return this.http.post(`${this.AdminURL}/declineReimbursement/${id}`, reimbursement)
  }

}
