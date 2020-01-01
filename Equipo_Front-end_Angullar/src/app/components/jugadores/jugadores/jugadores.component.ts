import { Component, OnInit, Input } from '@angular/core';
import { Jugador } from 'src/app/models/Jugador';
import { JugadorService} from '../../../services/jugador.service'
import { Subscription } from 'rxjs';
import { ActivatedRoute } from '@angular/router';

@Component({
  selector: 'app-jugadores',
  templateUrl: './jugadores.component.html',
  styleUrls: ['./jugadores.component.css']
})
export class JugadoresComponent implements OnInit {
  jugadores:Jugador[];
  @Input() idEqipo:number;
  private routeSub: Subscription;


  constructor(private jugadorService:JugadorService, private route: ActivatedRoute ) { }

  ngOnInit() {
    this.routeSub = this.route.params.subscribe(params => {
      this.idEqipo=params.equipoId;
      
    });
    this.jugadorService.getJugadores(this.idEqipo).subscribe( j=>{
      this.jugadores = j;
      this.jugadores.forEach(jugador=>jugador.equipoId=this.idEqipo);

     });
  }

  
  deleteJugador(jugador:Jugador){
    this.jugadores=this.jugadores.filter(j => j.id !== jugador.id);
    this.jugadorService.deleteJugador(jugador).subscribe();
  }

  editJugador(jugador:Jugador){
    //this.jugadores=this.jugadores.filter(j => j.id !== jugador.id);
    this.jugadorService.editJugador(jugador).subscribe();
  }

  addJugador(jugador:Jugador){
    this.jugadorService.addJugador(jugador).subscribe(jugador => {
      this.jugadores.push(jugador);
    });
  } 

}
