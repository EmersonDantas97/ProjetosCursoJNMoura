import { HttpClient } from '@angular/common/http';
import { inject, Injectable } from '@angular/core';
import { CarroModel } from '../models/carro-model';
import { Observable } from 'rxjs';
import { environment } from '../../environments/environment';

@Injectable({
  providedIn: 'root'
})
export class CarrosApi {

  private readonly httpClient:HttpClient = inject(HttpClient);
  private readonly urlBase:string;

  constructor() { 
    this.urlBase = `${environment.apiUrl}/carros`;
  }

  GetAll(): Observable<CarroModel[]>{
    return this.httpClient.get<CarroModel[]>(this.urlBase);
  }

  GetById(id:number|string): Observable<CarroModel>{
    return this.httpClient.get<CarroModel>(`${this.urlBase}/${id}`);
  }

  GetByName(nome:string): Observable<CarroModel[]>{
    return this.httpClient.get<CarroModel[]>(`${this.urlBase}/${nome}`);
  }

  Add(carro:CarroModel): Observable<CarroModel>{
    return this.httpClient.post<CarroModel>(this.urlBase,carro);
  }

  Delete(id:number): Observable<void>{
    return this.httpClient.delete<void>(`${this.urlBase}/${id}`);
  }

  Update(carro:CarroModel): Observable<CarroModel>{
    return this.httpClient.put<CarroModel>(`${this.urlBase}/${carro.Id}`,carro);
  }

}