import { Component } from '@angular/core';
import { Footer } from '../../shared/footer/footer';
import { Header } from "../../shared/header/header";

@Component({
  selector: 'app-index',
  imports: [Footer, Header],
  templateUrl: './index.html',
  styleUrl: './index.css'
})
export class Index {

}
