import { Component, inject } from '@angular/core';
import { Header } from "../../../shared/header/header";
import { Footer } from "../../../shared/footer/footer";
import { Router } from '@angular/router';

@Component({
  selector: 'app-carro-create',
  imports: [Header, Footer],
  templateUrl: './carro-create.html',
  styleUrl: './carro-create.css'
})

export class CarroCreate {

  private router = inject(Router);

  Add(){
    this.router.navigate(['/carro']);
  }
  
  GoToIndex(){
    this.router.navigate(['/carro']);
  }
}
