import { HttpClient } from '@angular/common/http';
import { inject, Injectable } from '@angular/core';
import { CarroModel } from '../models/carro-model';
import { Observable } from 'rxjs';


@Injectable({
  providedIn: 'root'
})
export class CarrosApi {

  private readonly httpClient:HttpClient = inject(HttpClient)

  constructor() { }

  GetAll(): Observable<CarroModel[]>{
    // return this.httpClient.get<any[]>('https://localhost:44360/api/Carros')
    return this.httpClient.get<CarroModel[]>('https://localhost:44360/api/Carros')
  }
}
