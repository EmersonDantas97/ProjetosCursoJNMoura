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
  private readonly apiUrlCarro:string;

  constructor(){ 
    this.apiUrlCarro = `${environment.apiUrl}/carros`;
  }

  GetAll(): Observable<CarroModel[]>{
    return this.httpClient.get<CarroModel[]>(this.apiUrlCarro);
  }

  GetById(id:number|string): Observable<CarroModel>{
    return this.httpClient.get<CarroModel>(`${this.apiUrlCarro}/${id}`);
  }

  GetByName(nome:string): Observable<CarroModel[]>{
    return this.httpClient.get<CarroModel[]>(`${this.apiUrlCarro}/${nome}`);
  }

  Add(carro: CarroModel): Observable<CarroModel>{
    return this.httpClient.post<CarroModel>(this.apiUrlCarro, carro);
  }

  Update(carro: CarroModel): Observable<CarroModel>{
    return this.httpClient.put<CarroModel>(`${this.apiUrlCarro}/${carro.Id}`, carro);
  }

  Delete(id: number): Observable<void>{
    return this.httpClient.delete<void>(`${this.apiUrlCarro}/${id}`);
  }
}