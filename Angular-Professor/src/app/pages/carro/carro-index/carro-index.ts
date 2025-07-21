import { Component, inject } from '@angular/core';
import { Footer } from "../../../shared/footer/footer";
import { Header } from "../../../shared/header/header";
import { Router, RouterLink } from '@angular/router';
import { CarrosApi } from '../../../services/carros-api';
import { CarroModel } from '../../../models/carro-model';
import { CommonModule } from '@angular/common';

@Component({
  selector: 'app-carro-index',
  imports: [Footer, Header, CommonModule, RouterLink],
  templateUrl: './carro-index.html',
  styleUrl: './carro-index.css'
})
export class CarroIndex {

  private readonly router: Router = inject(Router);
  private readonly carrosAPI: CarrosApi = inject(CarrosApi);
  carros: CarroModel[] = [];

  Search(){
    console.log("Search");
    this.carrosAPI.GetAll().subscribe({
      next: (jsonCarros: CarroModel[]) => {
        this.carros = jsonCarros;
      }
    })
  }

  GoToCreate(){    
    this.router.navigate(['/carro/create'], { skipLocationChange: true });
  }
}
