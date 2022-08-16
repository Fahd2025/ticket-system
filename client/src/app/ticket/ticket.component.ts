import { Component, ElementRef, OnInit, ViewChild } from '@angular/core';
import { ITicket } from '../shared/models/ticket';
import { TicketParams } from '../shared/models/ticketParams';
import { TicketService } from './ticket.service';

@Component({
  selector: 'app-ticket',
  templateUrl: './ticket.component.html',
  styleUrls: ['./ticket.component.scss']
})
export class TicketComponent implements OnInit {
  
  @ViewChild('search',{static: false}) searchTrem : ElementRef | undefined;
  loadCompleted = false;
  tickets : ITicket[] = [];
  governorates: string[] = [];
  city: string[] = [];
  district: string[] = [];

  ticketParams = new TicketParams();
  totalCount = 0;

  // sortOptions = [
  //   {name:"Alphabetical", value:"name"},
  //   {name:"Price Low to High", value:"priceAsc"},
  //   {name:"Price High to Low", value:"priceDesc"}
  // ];

  constructor(private ticketService : TicketService) { 
    this.ticketParams = this.ticketService.getTicketParams();
  }

  ngOnInit(): void {  
    
    const defaultTicketParamsValues = new TicketParams(); 
    this.getTickets();
  }

  getTickets(){
    this.ticketService.getTickets().subscribe(response => {
      this.tickets = [];
      if(response)
      {
        this.tickets = response.data;       
        this.totalCount = response.count;
        this.loadCompleted = true;
      }
    }, error => { 
       console.log(error);
    });
  }

  onSortSelected(event: EventTarget | null)
  {
    if(event){
      // this.ticketParams.sort = (<HTMLSelectElement>event).value;
      // this.getTickets();
    }  
  }

  onPageChanged(event:any){
    if (this.ticketParams.pageNumber != event.page) {
      this.ticketParams.pageNumber = event.page;
      this.ticketService.setTicketParams(this.ticketParams);
      this.getTickets();
    }    
  }

}
