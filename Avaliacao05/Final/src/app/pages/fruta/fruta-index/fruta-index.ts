import { Component, inject } from '@angular/core';
import { Header } from "../../../shared/header/header";
import { Footer } from "../../../shared/footer/footer";
import { FormsModule } from '@angular/forms';
import { Router, RouterLink } from '@angular/router';
import { FrutaApi } from '../../../services/fruta-api';
import { FrutaModel } from '../../../models/fruta-model';
import { CommonModule } from '@angular/common';

@Component({
  selector: 'app-fruta-index',
  imports: [Header, Footer, FormsModule, RouterLink, CommonModule],
  templateUrl: './fruta-index.html',
  styleUrl: './fruta-index.css'
})

export class FrutaIndex {

  private readonly router: Router = inject(Router);
  private frutaApi : FrutaApi = inject(FrutaApi);

  frutas:FrutaModel[] = [];

  id:number | string = '';
  nome:string = '';
  dataVenc:Date = new Date();


  Search(){

    if (this.id !== '' && this.id !== null){
        this.SearchById(this.id);
        return;
      }
      
      if (this.nome !== ''){
        this.SearchByName(this.nome);
        return;
      }

      this.SearchAll();

  }

  SearchByName(nome:string): void{
    this.frutaApi.GetByName(nome).subscribe({
      next: (carros:FrutaModel[]) => {
        this.frutas = carros;
      }
    });
  }  

  SearchById(id: number | string): void{
    this.frutaApi.GetById(id).subscribe({
      next: (fruta: FrutaModel) => {
        this.frutas = [fruta];
      }
    })
  }

  SearchAll():void {
      this.frutaApi.GetAll().subscribe({
        next: (jsonFrutas:FrutaModel[]) => {
          this.frutas = jsonFrutas;
          console.log(this.frutas);
        }
    })
  }

  GoToCreate(): void{    
    this.router.navigate(['/frutas/create']);
  }

  ConfirmDelete(id:number): void{
      if (confirm(`Deseja excluir a Fruta ${id}?`)){
        this.Delete(id);
    }
  }

  Delete(id:number): void{
      this.frutaApi.Delete(id).subscribe({
        next: () => {
          this.Search();  
          alert("Fruta excluída com sucesso!");        
        }
    })
  }

}
