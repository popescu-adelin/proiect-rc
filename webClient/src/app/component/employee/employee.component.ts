import { Component, OnInit } from '@angular/core';
import * as signalR from '@microsoft/signalr';
import { Observable } from 'rxjs';
import { Department } from 'src/app/models/department';
import { Employee } from 'src/app/models/employeee';
import { EmployeesService } from 'src/app/services/employees.service';

@Component({
  selector: 'app-employee',
  templateUrl: './employee.component.html',
  styleUrls: ['./employee.component.scss']
})

export class EmployeeComponent implements OnInit {
  title = 'webClient';
  employees: Employee[] = [];
  departments: Department[] = [];
  filteredEmployees: Employee[] = [];
  showModal: boolean = false;
  hubUrl: string;
  connection: any;

  constructor(
    private employeeService: EmployeesService,
  ) { this.hubUrl = 'https://localhost:44316/clocking' }

  ngOnInit(): void {
    this.loadEmployees();
    this.initiateSignalrConnection();
  }

  public async initiateSignalrConnection(): Promise<void> {
    try {
      this.connection = new signalR.HubConnectionBuilder()
        .withUrl(this.hubUrl)
        .withAutomaticReconnect()
        .build();

      //await this.connection.start({ withCredentials: false });

      this.connection
        .start()
        .then(() => {
          console.log('SignalR connection established');
          this.connection.on('New clocking', (employees: Employee[]) => {
            console.log('New clocking event received:', employees);
            // Update your employees array here with the new data.
            // For example, you can assign the new data to this.employees.
            this.employees = employees;
          });
        })
        .catch((error: any) => {
          console.error('Error establishing SignalR connection:', error);
        });

      console.log(`SignalR connection success! connectionId: ${this.connection.connectionId}`);
    }
    catch (error) {
      console.log(`SignalR connection error: ${error}`);
    }
  }




  loadEmployees() {
    this.employeeService.getEmployees().subscribe(data => {
      this.employees = data;
      console.log(data);
    })
  }

  openAddEmployeeModal() {
    this.showModal = true
  }

  afterAction() {
    this.showModal = false;
    this.ngOnInit()
  }
}
