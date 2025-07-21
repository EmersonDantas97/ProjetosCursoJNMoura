import { Component, inject } from '@angular/core';
import { Header } from '../../../shared/header/header';
import { Footer } from '../../../shared/footer/footer';
import { FormsModule } from '@angular/forms';
import { CarroModel } from '../../../models/carro-model';
import { ActivatedRoute, Router } from '@angular/router';
import { CarrosApi } from '../../../services/carros-api';

@Component({
  selector: 'app-carro-edit',
  imports: [Header, Footer, FormsModule],
  templateUrl: './carro-edit.html',
  styleUrl: './carro-edit.css'
})
export class CarroEdit {

  private readonly router: Router = inject(Router);
  private readonly activatedRouter: ActivatedRoute = inject(ActivatedRoute);
  private readonly carrosApi: CarrosApi = inject(CarrosApi);

  carro:CarroModel = {Id: 0, Nome: '', Valor: '' };

  constructor(){
    const id:number = Number (this.activatedRouter.snapshot.paramMap.get('id')); 
    this.SearchById(id);
  }

  SearchById(id: number): void{
    this.carrosApi.GetById(id).subscribe({
      next: (carro: CarroModel) => {
        this.carro = carro;
      }
    })
  }

  Update(): void{
     this.carrosApi.Update(this.carro).subscribe({
      next: (carro: CarroModel) => {
        alert(`Carro ${carro.Id} alterado com sucesso!`);
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
