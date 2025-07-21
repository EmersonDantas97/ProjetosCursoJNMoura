import { Component, inject } from '@angular/core';
import { Header } from "../../../shared/header/header";
import { Footer } from "../../../shared/footer/footer";
import { Router } from '@angular/router';
import { FormsModule } from '@angular/forms';
import { CarroModel } from '../../../models/carro-model';
import { CarrosApi } from '../../../services/carros-api';

@Component({
  selector: 'app-carro-create',
  imports: [Header, Footer, FormsModule],
  templateUrl: './carro-create.html',
  styleUrl: './carro-create.css'
})

export class CarroCreate {

  private readonly router:Router = inject(Router);
  private readonly carrosApi: CarrosApi = inject(CarrosApi);

  carro:CarroModel = {Id: 0, Nome: '', Valor: '' };

  Add(){
    this.carrosApi.Add(this.carro).subscribe({
      next: (carro: CarroModel) => {
        alert(`Carro ${carro.Id} incluído com sucesso!`);
        this.GoToIndex(); 
      },
      error: (erro: any) => {
        alert(`Erro: ${erro}  - contate o suporte!`);
      }
    });
  }
  
  GoToIndex(){
    this.router.navigate(['/carros']);
  }
}
