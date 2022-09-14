import { Component, OnInit } from '@angular/core';
import { FormControl, Validators, FormGroup, FormBuilder } from '@angular/forms';
import { HotelmanagementApiService } from 'src/app/hotelmanagement-api.service';

@Component({
  selector: 'app-logindialog',
  templateUrl: './logindialog.component.html',
  styleUrls: ['./logindialog.component.css']
})
export class LogindialogComponent implements OnInit {
  loginForm !: FormGroup;
  constructor(private formBuilder : FormBuilder, private api:HotelmanagementApiService) { }

  ngOnInit(): void {
    this.loginForm = this.formBuilder.group( {
      email: ['', Validators.required],
      password: ['', Validators. required]
    })
  }

  email = new FormControl('', [Validators.required, Validators.email]);
  hide = true;
  getErrorMessage() {
    if (this.email.hasError('required')) {
      return 'You must enter a value';
    }

    return this.email.hasError('email') ? 'Not a valid email' : '';
  }

  login() {
    if(this.loginForm.valid){
      this.api.login(this.loginForm.value)
      .subscribe({
        next:(res)=>{
          alert("Login Successfully");
          this.loginForm.reset();
        },
        error:()=> {
          alert("Login Fail");
        }
      })
    }
  }
}

