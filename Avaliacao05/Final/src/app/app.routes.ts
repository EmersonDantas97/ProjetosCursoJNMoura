import { Routes } from '@angular/router';
import { Home } from './pages/home/home';
import { FrutaIndex } from './pages/fruta/fruta-index/fruta-index';
import { FrutaCreate } from './pages/fruta/fruta-create/fruta-create';
import { FrutaEdit } from './pages/fruta/fruta-edit/fruta-edit';
import { Message404 } from './messages/message404/message404';

export const routes: Routes = [

    {path:'', redirectTo:'home', pathMatch:'full'},
    {path:'home', component:Home},
    {path:'frutas', component:FrutaIndex},
    {path:'frutas/create', component:FrutaCreate},
    {path:'frutas/edit/:id', component:FrutaEdit},
    {path:'**', component:Message404}

];
