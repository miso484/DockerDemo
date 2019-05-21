import { Component, OnInit } from '@angular/core';
import { EmployeeService } from './../../services/employee.service';
import { ActivatedRoute, Router } from '@angular/router';
@Component({
  selector: 'app-employee',
  templateUrl: './employee.component.html',
  styleUrls: ['./employee.component.css']
})
export class EmployeeComponent implements OnInit {

  employee = {
    id:0,
  };


  id:any;
  name: any;
  fatherName: any;
  address:any;
  city: any;


  constructor(
    private route: ActivatedRoute,
    private router: Router,
    private employeeService: EmployeeService

  ) { 

    route.params.subscribe(p => {
      this.employee.id = +p['id'];
    }, err => {
      if(err.status == 404)
        this.router.navigate(['/employee']);
    });

  }

  ngOnInit() {
    this.employeeService.getEmployee(this.employee.id)
    .subscribe(b => {
        this.employee = b;
    });
  }


  submit(){
    debugger;
    this.employee.id = 0;
    if(this.employee.id != 0)
    {
      this.employeeService.update(this.employee)
        .subscribe( x => 
          {
            console.log(x),
            this.router.navigate(['/employee'])
          });
    }
    else{
      this.employeeService.create(this.employee)
        .subscribe( x => 
          {
            console.log(x),
            this.router.navigate(['/employee'])
          });
    }
  }

  delete(){
    if(confirm("Are you sure?")){
      this.employeeService.delete(this.employee.id)
        .subscribe(x => {
          console.log(x),
          this.router.navigate(['/employee'])
        });
    }
  }

}
