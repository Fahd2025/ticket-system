import { ITicket } from "./ticket";

export interface IPagination {
  pageIndex: number;
  pageSize: number;
  count: number;
  data: ITicket[];
}

export class Pagination implements IPagination {
  pageIndex = 1;
  pageSize = 5;
  count = 0;
  data: ITicket[] = [];
}
