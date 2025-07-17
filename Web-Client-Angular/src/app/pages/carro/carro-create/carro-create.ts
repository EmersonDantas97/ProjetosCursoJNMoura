import { Component, inject } from '@angular/core';
import { Header } from "../../../shared/header/header";
import { Footer } from "../../../shared/footer/footer";
import { Router } from '@angular/router';
import { CommonModule } from '@angular/common';
import { CarrosApi } from '../../../services/carros-api';
import { FormsModule } from '@angular/forms';
import { CarroModel } from '../../../models/carro-model';
import { Observable } from 'rxjs';

@Component({
  selector: 'app-carro-create',
  imports: [Header, Footer, CommonModule, FormsModule],
  templateUrl: './carro-create.html',
  styleUrl: './carro-create.css'
})

export class CarroCreate {

  private readonly router: Router = inject(Router);
  private readonly CarrosApi$: CarrosApi = inject(CarrosApi); // $ indica observable no objeto.

  carro: CarroModel = { Id: 0, Nome: '', Valor: '' };

  Add() {
    this.CarrosApi$.Add(this.carro).subscribe({
      next: (carro: CarroModel) => {
        alert(`Carro ${carro.Id} incluído com sucesso!`)
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
