import { Component } from '@angular/core';
import { RouterOutlet } from '@angular/router';
import { Menu } from "./menu/menu";
import { Footer } from "./footer/footer";

@Component({
  selector: 'app-root',
  imports: [Menu, Footer]
  templateUrl: './app.html',
  styleUrl: './app.css'
})
export class App {
  protected title = 'my-first-angular-app';
}
