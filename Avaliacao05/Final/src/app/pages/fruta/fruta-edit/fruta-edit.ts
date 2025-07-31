import { Component, inject } from '@angular/core';
import { Header } from "../../../shared/header/header";
import { Footer } from "../../../shared/footer/footer";
import { FormsModule } from '@angular/forms';
import { FrutaApi } from '../../../services/fruta-api';
import { ActivatedRoute, Router } from '@angular/router';
import { FrutaModel } from '../../../models/fruta-model';


@Component({
  selector: 'app-fruta-edit',
  imports: [Header, Footer, FormsModule],
  templateUrl: './fruta-edit.html',
  styleUrl: './fruta-edit.css'
})
export class FrutaEdit {

  private readonly frutaApi = inject(FrutaApi);
  private readonly router = inject(Router); 
  private readonly activatedRoute = inject(ActivatedRoute);

  fruta: FrutaModel = {Id: 0, Nome: '', DataVenc: new Date()};

  dataVencFormatada :string = '';

  constructor(){
    const id:number = Number(this.activatedRoute.snapshot.paramMap.get("id"))
    this.SearchById(id);
  }

  SearchById(id: number) {
    this.frutaApi.GetById(id).subscribe({
      next: (fruta: FrutaModel) => {
        this.fruta = fruta;
        this.dataVencFormatada = this.formatDateForInput(fruta.DataVenc);
      },
      error: (erro) => {
        console.error(`Error ${erro} ao buscar fruta - contate o suporte técnico.`);
      }
    });
  }

  formatDateForInput(date: string | Date){
    const d = new Date(date);
    const year = d.getFullYear();
    const month = String(d.getMonth() + 1).padStart(2, '0');
    const day = String(d.getDate()).padStart(2, '0');
    return `${year}-${month}-${day}`;
  }

  Update() {

    this.fruta.DataVenc = new Date(this.dataVencFormatada);

    this.frutaApi.Update(this.fruta).subscribe({
      next: (fruta: FrutaModel) => {
        alert(`Fruta ${fruta.Nome} atualizada com sucesso!`);
        this.GoToIndex();
      },
      error: (erro) => {
        console.error(`Error ${erro} ao atualizar fruta - contate o suporte técnico.`);
      }
    });
  }

  GoToIndex() {
    this.router.navigate(['/frutas']);
  }

}
