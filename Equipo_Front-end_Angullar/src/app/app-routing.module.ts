import { NgModule, Component } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import{ContactoComponent}from './components/pages/contacto/contacto.component';
//equipos
import { EquiposComponent } from './components/equipos/equipos.component';
import { GoleadoresComponent } from './components/jugadores/goleadores/goleadores.component';

import{AddEquipoComponent}from './components/add-equipo/add-equipo.component';
import{EquipoDetalleComponent}from './components/equipo-detalle/equipo-detalle.component';
import{EquipoEditComponent} from './components/equipo-edit/equipo-edit.component'
//jugadores
import{JugadoresComponent} from './components/jugadores/jugadores/jugadores.component'
import{JugadorEditComponent} from './components/jugadores/jugador-edit/jugador-edit.component'
import{DetalleJugadorComponent} from './components/jugadores/detalle-jugador/detalle-jugador.component'


import { from } from 'rxjs';



const routes: Routes = [
  {path: '',component: EquiposComponent},
  {path: 'Contacto',component: ContactoComponent},
  {path: 'AddEquipo',component: AddEquipoComponent},
  {path: 'Top',component: GoleadoresComponent},

  {path:'equipos/:equipoId',component:EquipoDetalleComponent},
  {path:'equipos/:equipoId/edit',component:EquipoEditComponent},
  {path:'equipos/:equipoId/jugadores',component:JugadoresComponent},
  {path:'equipos/:equipoId/jugadores/:idJugador/edit',component:JugadorEditComponent},
  {path:'equipos/:equipoId/jugadores/:idJugador',component:DetalleJugadorComponent}
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
