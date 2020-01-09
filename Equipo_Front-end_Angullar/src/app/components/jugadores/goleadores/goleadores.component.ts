import { Component, OnInit } from '@angular/core';
import { JugadorService } from 'src/app/services/jugador.service';
import { Jugador } from 'src/app/models/Jugador';

@Component({
  selector: 'app-goleadores',
  templateUrl: './goleadores.component.html',
  styleUrls: ['./goleadores.component.css']
})
export class GoleadoresComponent implements OnInit {
  jugadores:Jugador[];
  constructor(private jugadorService: JugadorService) { }

  ngOnInit() {
    this.jugadorService.getTop().subscribe( jugadores=>{
      this.jugadores = jugadores;
    });
  }

}
