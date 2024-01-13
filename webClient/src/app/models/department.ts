import { Employee } from "./employeee"

export type Department = {
    id: String,
    name: String,
    description: String,
    parentDepartmentName: String,
    employees?: Employee[]
}