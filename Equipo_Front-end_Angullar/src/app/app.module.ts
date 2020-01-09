import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import {HttpClientModule} from '@angular/common/http'
import { FormsModule} from '@angular/forms'

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { EquiposComponent } from './components/equipos/equipos.component';
import { EquipoItemComponent } from './components/equipo-item/equipo-item.component';
import { HeaderComponent } from './components/layout/header/header.component';
import { FooterComponent } from './components/layout/footer/footer.component';
import { AddEquipoComponent } from './components/add-equipo/add-equipo.component';
import { from } from 'rxjs';
import { ContactoComponent } from './components/pages/contacto/contacto.component';
import { EquipoDetalleComponent } from './components/equipo-detalle/equipo-detalle.component';
import { EquipoEditComponent } from './components/equipo-edit/equipo-edit.component';
import { CarouselComponent } from './components/layout/carousel/carousel.component';
import { JugadorItemComponent } from './components/jugadores/jugador-item/jugador-item.component';
import { JugadoresComponent } from './components/jugadores/jugadores/jugadores.component';
import { JugadorEditComponent } from './components/jugadores/jugador-edit/jugador-edit.component';
import { AddJugadorComponent } from './components/jugadores/add-jugador/add-jugador.component';
import { DetalleJugadorComponent } from './components/jugadores/detalle-jugador/detalle-jugador.component';
import { GoleadoresComponent } from './components/jugadores/goleadores/goleadores.component';

@NgModule({
  declarations: [
    AppComponent,
    EquiposComponent,
    EquipoItemComponent,
    HeaderComponent,
    FooterComponent,
    AddEquipoComponent,
    ContactoComponent,
    EquipoDetalleComponent,
    EquipoEditComponent,
    CarouselComponent,
    JugadorItemComponent,
    JugadoresComponent,
    JugadorEditComponent,
    AddJugadorComponent,
    DetalleJugadorComponent,
    GoleadoresComponent
    ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    HttpClientModule,
    FormsModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
