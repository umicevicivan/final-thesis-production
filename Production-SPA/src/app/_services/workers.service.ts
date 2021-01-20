import { Injectable } from '@angular/core';
import { environment } from 'src/environments/environment';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class WorkersService {
baseUrl = environment.apiUrl;

constructor(private http: HttpClient) { }

getWorkers(): Observable<Worker[]> {
  return this.http.get<Worker[]>(this.baseUrl + 'workers');
}

getWorker(id): Observable<Worker>{
  return this.http.get<Worker>(this.baseUrl + 'workers/' + id);
}

}
