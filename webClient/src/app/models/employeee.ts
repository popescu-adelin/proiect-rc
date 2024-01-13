import { Time } from "@angular/common";
import { EmployeStatus } from "./employeeStatus";
import { Clocking } from "./clocking";

export type Employee = {
  id: String;
  name: String;
  cardId: String;
  clocking?: Clocking;
  status: EmployeStatus;
}
