import { Component } from '@angular/core';
import { Footer } from '../../../shared/footer/footer';
import { Header } from "../../../shared/header/header";

@Component({
  selector: 'app-moto-index',
  imports: [Footer, Header],
  templateUrl: './moto-index.html',
  styleUrl: './moto-index.css'
})
export class MotoIndex {


  Search(){
  }

  GoToCreate(){
  }

}
