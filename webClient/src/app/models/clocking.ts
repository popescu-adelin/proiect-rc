import { Time } from "@angular/common";

export type Clocking = {
    arrivingTime?: Date;
    leavingTime?: Date;
    workTime?: Time;
}