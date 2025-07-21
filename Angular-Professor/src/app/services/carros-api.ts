import { HttpClient } from '@angular/common/http';
import { inject, Injectable } from '@angular/core';
import { environment } from '../../environments/environment.development';
import { CarroModel } from '../models/carro-model';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class CarrosApi {

  private readonly httpClient: HttpClient = inject(HttpClient);
  private readonly url: string = `${environment.apiURL}/carros`;

  GetAll(): Observable<CarroModel[]>{
    return this.httpClient.get<CarroModel[]>(this.url);
  }

}
