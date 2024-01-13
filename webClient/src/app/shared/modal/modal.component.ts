import { Component, EventEmitter, Input, Output } from '@angular/core';
import { Department } from 'src/app/models/department';
import { Employee } from 'src/app/models/employeee';
import { EmployeesService } from 'src/app/services/employees.service';

@Component({
  selector: 'app-modal',
  templateUrl: './modal.component.html',
  styleUrls: ['./modal.component.scss']
})
export class ModalComponent {

  @Input() isVisible = false;
  @Input() type = 'employee';
  @Input() title = '';
  @Output() close = new EventEmitter<any>();
  data: any = {};

  constructor(private employeeService: EmployeesService) { }

  onClose() {
    this.isVisible = false;
    this.close.emit();
  }
  onSubmit() {

    this.employeeService.addEmployee(this.data).subscribe({
      next: () => {
        this.close.emit();
      },
      error: (error) => {
        console.error('Error creating a new employee:', error);
        // Handle error (e.g., show user feedback)
      }

    });

  }
}
