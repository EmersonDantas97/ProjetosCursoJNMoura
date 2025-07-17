import { Component, inject, numberAttribute } from '@angular/core';
import { Footer } from '../../../shared/footer/footer';
import { Header } from '../../../shared/header/header';
import { CarroModel } from '../../../models/carro-model';
import { CarrosApi } from '../../../services/carros-api';
import { ActivatedRoute, Router, RouterLink } from '@angular/router';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';

@Component({
  selector: 'app-carro-edit',
  imports: [Header, Footer, FormsModule],
  templateUrl: './carro-edit.html',
  styleUrl: './carro-edit.css'
})
export class CarroEdit {

  private readonly router: Router = inject(Router);
  private readonly activatedRouter: ActivatedRoute = inject(ActivatedRoute);
  private readonly carrosApi$: CarrosApi = inject(CarrosApi); // $ indica observable no objeto.

  carro: CarroModel = { Id: 0, Nome: '', Valor: '' };

  constructor(){
    const id: number = Number(this.activatedRouter.snapshot.paramMap.get('id'));
    this.SearchById(id);
  }

  SearchById(id: number | string): void {
    this.carrosApi$.GetById(id).subscribe({
      next: (carro: CarroModel) => {
        this.carro = carro;
      }
    })
  }

  Update(): void{
    this.carrosApi$.Update(this.carro).subscribe({
      next: (carro: CarroModel) => {
        alert(`Carro ${carro.Id} alterado com sucesso!`)
        this.GoToIndex();
      },
      error: (erro: any) => {
        alert(`Erro ${erro} - Contate o suporte!`);
      } 
    });
  }

  GoToIndex() {
    this.router.navigate(['/carros']);
  }
}
