import { Component, inject } from '@angular/core';
import { Footer } from "../../../shared/footer/footer";
import { Header } from "../../../shared/header/header";
import { Router, RouterLink } from '@angular/router';
import { CarrosApi } from '../../../services/carros-api';
import { CarroModel } from '../../../models/carro-model';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';

@Component({
  selector: 'app-carro-index',
  imports: [Footer, Header, FormsModule, CommonModule, RouterLink],
  templateUrl: './carro-index.html',
  styleUrl: './carro-index.css'
})
export class CarroIndex {

  /*
  constructor(private readonly router: Router){}
  */

  private readonly router: Router = inject(Router);
  private readonly carrosApi: CarrosApi = inject(CarrosApi);

  carros: CarroModel[] = [];
  id: number | string = '';
  nome: string = '';

  Search(): void {

    //this.carros = [];

    if (this.id !== '' && this.id !== null) {
      this.SearchById(this.id);
      return;
    }

    if (this.nome !== '') {
      this.SearchByName(this.nome);
      return;
    }

    this.SearchAll();
  }

  SearchById(id: number | string): void {
    this.carrosApi.GetById(id).subscribe({
      next: (carro: CarroModel) => {
        this.carros = [carro];
      }
    })
  }

  SearchByName(nome: string): void {
    this.carrosApi.GetByName(nome).subscribe({
      next: (carros: CarroModel[]) => {
        this.carros = carros;
      }
    });
  }

  SearchAll(): void {
    this.carrosApi.GetAll().subscribe({
      next: (carros: CarroModel[]) => {
        this.carros = carros;
      }
    });
  }

  GoToCreate(): void {
    this.router.navigate(['/carros/create']);
    //this.router.navigate(['/carro/create'], { skipLocationChange: true });
  }

  ConfirmDelete(id: number): void {
    if (confirm(`Deseja excluir o carro ${id}?`)) {
      this.Delete(id);
    }
  }

  Delete(id: number): void {
    this.carrosApi.Delete(id).subscribe({
      next: () => {
        this.Search();
        alert('Carro excluído com sucesso!');
      }
    })
  }
}
