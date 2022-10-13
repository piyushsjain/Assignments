import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';

import {HomeComponent} from './home/home.component'
import {SignupComponent} from './signup/signup.component'
import {AdminDashboardComponent} from './admin-dashboard/admin-dashboard.component'
import {EmployeeDashboardComponent} from './employee-dashboard/employee-dashboard.component'
import { EditReimbursementComponent} from './edit-reimbursement/edit-reimbursement.component'
import { AdminApprovedComponent} from './admin-approved/admin-approved.component'
import { AdminDeclineComponent} from './admin-decline/admin-decline.component'

const routes: Routes = [
  {
    path:'',
    component:HomeComponent
  },
  {
    path:'signup',
    component:SignupComponent
  },
  {
    path:'admin-Dashboard',
    component:AdminDashboardComponent
  },
  {
    path:'employee-Dashboard',
    component:EmployeeDashboardComponent
  },
  {
    path:'employee-Dashboard/edit-reimbursement/:id',
    component:EditReimbursementComponent
  },
  {
    path:"admin-approved",
    component:AdminApprovedComponent
  },
  {
    path:"admin-decline",
    component:AdminDeclineComponent
  }
  
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
