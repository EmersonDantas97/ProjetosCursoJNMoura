import { Component } from '@angular/core';
import { Header } from "../../shared/header/header";
import { Footer } from '../../shared/footer/footer';

@Component({
  selector: 'app-index',
  imports: [Footer, Header],
  templateUrl: './index.html',
  styleUrl: './index.css'
})
export class Index {

}
