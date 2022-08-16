import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common'; 
import { TicketComponent } from './ticket.component';
import { TicketItemComponent } from './ticket-item/ticket-item.component';
import { SharedModule } from '../shared/shared.module';


@NgModule({
  declarations: [
    TicketComponent,
    TicketItemComponent,
  ],
  imports: [
    CommonModule,
    SharedModule,
  ]
})
export class TicketModule { }
