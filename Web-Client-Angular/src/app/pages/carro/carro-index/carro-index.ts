import { Component, inject } from '@angular/core';
import { Footer } from "../../../shared/footer/footer";
import { Header } from "../../../shared/header/header";
import { Router } from '@angular/router';
import { CarrosApi } from '../../../services/carros-api';
import { CarroModel } from '../../../models/carro-model';
import { CommonModule } from '@angular/common';

@Component({
  selector: 'app-carro-index',
  imports: [Footer, Header, CommonModule],
  templateUrl: './carro-index.html',
  styleUrl: './carro-index.css'
})

export class CarroIndex {

  // constructor(private readonly router: Router){
  // }

  private readonly router = inject(Router);
  private readonly carrosApi: CarrosApi = inject(CarrosApi);

  carros: CarroModel[] = [];

  Search(){

    this.carrosApi.GetAll().subscribe({
      next: (jsonCarros:CarroModel[]) => {
        this.carros = jsonCarros;
      }
    });
  }
  
  GoToCreate(){
    this.router.navigate(['/carros/create'], {skipLocationChange: true}); // por questao de seguranca, oculta a rota.
  }

}
// 