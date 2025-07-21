import { Routes } from '@angular/router';
import { Index } from './pages/index';
import { CarroIndex } from './pages/carro/carro-index/carro-index';
import { Message404 } from './pages/messages/message-404/message-404';
import { CarroCreate } from './pages/carro/carro-create/carro-create';

export const routes: Routes = [
    {path:'', redirectTo:'home', pathMatch: 'full'},
    {path:'home', component:Index},
    {path:'carro', component:CarroIndex},
    {path:'carro/create', component:CarroCreate},
    {path:'**', component:Message404}
];
