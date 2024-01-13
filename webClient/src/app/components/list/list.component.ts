import { Component, EventEmitter, Input, OnInit, Output } from '@angular/core';
import { Department } from 'src/app/models/department';
import { Employee } from 'src/app/models/employeee';

@Component({
  selector: 'app-list',
  templateUrl: './list.component.html',
  styleUrls: ['./list.component.scss']
})

export class ListComponent implements OnInit {

  @Input() data: any[] = []
  @Output() submit = new EventEmitter<any>(); // Emit the updated data
  showEditModal: boolean = false;
  selectedElement: Employee | undefined;

  displayedColumns: string[] = [];

  constructor() {
    console.log(this.data);
  }

  ngOnInit(): void {
    this.displayedColumns = ['name', 'cardId', 'status', 'startTime', 'stopTime', 'workTime']
    console.log(this.data);
  }

  displayEditModal(row: any) {
    this.selectedElement = row;
    this.showEditModal = true;
  }

  submitEdit(updatedData: any) {
    this.submit.emit();
    this.showEditModal = false;
  }
}
