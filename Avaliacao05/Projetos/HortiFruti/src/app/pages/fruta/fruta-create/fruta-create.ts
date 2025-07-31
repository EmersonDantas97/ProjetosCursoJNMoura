import { Component, inject } from '@angular/core';
import { Router } from '@angular/router';
import { FrutaApi } from '../../../services/fruta-api';
import { FrutaModel } from '../../../models/fruta-model';
import { Header } from "../../../shared/header/header";
import { Footer } from "../../../shared/footer/footer";
import { FormsModule } from '@angular/forms';

@Component({
  selector: 'app-fruta-create',
  imports: [Header, Footer, FormsModule],
  templateUrl: './fruta-create.html',
  styleUrl: './fruta-create.css'
})

export class FrutaCreate {

  private readonly router: Router = inject(Router);
  private frutaApi : FrutaApi = inject(FrutaApi);

  fruta: FrutaModel = {Id : 0, Nome : '', DataVenc : new Date()};

  Add(){
    this.frutaApi.Add(this.fruta).subscribe({
      next: (fruta: FrutaModel) => {
        alert(`Fruta ${fruta.Id} incluída com sucesso!`);
        this.GoToIndex(); 
      },
      error: (erro: any) => {
        alert(`Erro: ${erro}  - contate o suporte!`);
      }
    });
  }
  
  GoToIndex(){
    this.router.navigate(['/frutas']);
  }
}
