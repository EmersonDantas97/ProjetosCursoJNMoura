import { Component } from '@angular/core';
import { Menu } from "../menu/menu";

@Component({
  selector: 'app-header',
  imports: [Menu],
  templateUrl: './header.html',
  styleUrl: './header.css'
})
export class Header {

}
