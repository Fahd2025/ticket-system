import { HttpClient, HttpParams } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { IPagination, Pagination } from '../shared/models/pagination';
import { map } from 'rxjs/operators'
import { TicketParams } from '../shared/models/ticketParams';
import { ITicket } from '../shared/models/ticket';
import { environment } from 'src/environments/environment';
import { of } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class TicketService {
  baseUrl = environment.apiUrl;
  tickets: ITicket[] = [];  
  pagination = new Pagination();
  ticketParams = new TicketParams();

  constructor(private http: HttpClient) { }

  getTickets() {
    const pagesReceived = Math.ceil(this.tickets.length / this.pagination.pageSize);
    if (this.ticketParams.pageNumber <= pagesReceived) {
      this.pagination.data = this.tickets.slice((this.ticketParams.pageNumber - 1) * this.ticketParams.pageSize, this.ticketParams.pageNumber * this.ticketParams.pageSize);

      return of(this.pagination);
    }
    
    let params = new HttpParams();

    params = params.append("pageIndex", this.ticketParams.pageNumber.toString());
    params = params.append("pageSize", this.ticketParams.pageSize.toString());

    return this.http.get<IPagination>(this.baseUrl , { observe: "response", params }).pipe(
      map(response => {
        this.pagination = response.body as IPagination;
        this.tickets = [...this.tickets, ...this.pagination.data];
        return this.pagination;
      })
    );
  }

  setTicketParams(params: TicketParams) {
    this.ticketParams = params;
  }

  getTicketParams() {
    return this.ticketParams;
  }

  getTicket(id: number) {
    const ticket = this.tickets.find(p => p.id === id);
    if (ticket) { return of(ticket); }
    return this.http.get<ITicket>(this.baseUrl + "/" + id);
  }
}
