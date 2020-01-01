import { Component, OnInit, Input, EventEmitter, Output  } from '@angular/core';
import { Jugador } from 'src/app/models/Jugador';
import { JugadorService} from 'src/app/services/jugador.service';
import { Router } from '@angular/router';


@Component({
  selector: 'app-jugador-item',
  templateUrl: './jugador-item.component.html',
  styleUrls: ['./jugador-item.component.css']
})
export class JugadorItemComponent implements OnInit {

  @Input() jugador=Jugador;
  @Output() deleteJugador:EventEmitter<Jugador> = new EventEmitter();
  @Output() editJugador:EventEmitter<Jugador> = new EventEmitter();

  constructor(private jugadorService:JugadorService, private router:  Router) { }

  ngOnInit() {
  }

  setClasses(){
    let classes = {
      jugador: true
    }
    return classes;
  }

  onEdit(jugador:Jugador){
    this.router.navigateByUrl(`equipos/${jugador.equipoId}/jugadores/${jugador.id}/edit`);
    // this.editJugador.emit(jugador);

  }
  onVer(jugador:Jugador){
    this.router.navigateByUrl(`/equipos/${jugador.equipoId}/jugadores/${jugador.id}`);
  }
  onDelete(jugador){
    this.deleteJugador.emit(jugador);
  }


}
