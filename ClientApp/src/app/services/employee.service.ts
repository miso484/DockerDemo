import { Injectable } from '@angular/core';
import { Http } from '@angular/http';
import 'rxjs/add/operator/map';

@Injectable()
export class EmployeeService {
  constructor(private http: Http) { }
  create(employee:any){
    return this.http.post('/api/employees', employee)
      .map(res => res.json());
  }
  getEmployee(id:any){
    return this.http.get('/api/employees/' + id)
      .map(res => res.json());
  }
  update(employee:any){
    return this.http.put('/api/employees/' + employee.id, employee)
      .map(res => res.json());
  }
  delete(id:any){
    return this.http.delete('/api/employees/' + id)
      .map(res => res.json());
  }
  getEmployees()
  {
    return this.http.get('/api/employees')
      .map(res => res.json());
  }
}