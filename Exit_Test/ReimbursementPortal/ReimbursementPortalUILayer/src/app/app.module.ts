import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import{MaterialModule} from './material/material.module'

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { HomeComponent } from './home/home.component';
import { EmployeeDashboardComponent } from './employee-dashboard/employee-dashboard.component';
import { SignupComponent } from './signup/signup.component';
import { AdminDashboardComponent } from './admin-dashboard/admin-dashboard.component';
import{ FormsModule,ReactiveFormsModule } from '@angular/forms';
import {HttpClientModule} from '@angular/common/http';
import { EditReimbursementComponent } from './edit-reimbursement/edit-reimbursement.component';
import { AdminCommonComponent } from './admin-common/admin-common.component';
import { AdminApprovedComponent } from './admin-approved/admin-approved.component';
import { AdminDeclineComponent } from './admin-decline/admin-decline.component';
import { Ng2SearchPipeModule} from 'ng2-search-filter'

@NgModule({
  declarations: [
    AppComponent,
    HomeComponent,
    EmployeeDashboardComponent,
    SignupComponent,
    AdminDashboardComponent,
    EditReimbursementComponent,
    AdminCommonComponent,
    AdminApprovedComponent,
    AdminDeclineComponent,
    
    
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    ReactiveFormsModule,
    HttpClientModule,
    FormsModule,
    MaterialModule,
    Ng2SearchPipeModule
 
  ],
 
  providers: [],
  bootstrap: [AppComponent],
  entryComponents:[EmployeeDashboardComponent]
})
export class AppModule { }
