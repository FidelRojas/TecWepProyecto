import { Component, OnInit } from '@angular/core';
import { Jugador } from 'src/app/models/Jugador';
import { ActivatedRoute, Router } from '@angular/router';
import { JugadorService } from 'src/app/services/jugador.service';
import { Subscription } from 'rxjs';

@Component({
  selector: 'app-detalle-jugador',
  templateUrl: './detalle-jugador.component.html',
  styleUrls: ['./detalle-jugador.component.css']
})
export class DetalleJugadorComponent implements OnInit {
  jugador:Jugador; 


  private routeSub: Subscription;
  constructor(private jugadorService:JugadorService, private route: ActivatedRoute, private router:  Router) {
    this.jugador=new Jugador;
   }

  ngOnInit() {
    this.jugador.equipoId = Number(this.route.snapshot.paramMap.get("equipoId"));
    this.jugador.id= Number(this.route.snapshot.paramMap.get("idJugador"));
    this.jugadorService.getJugador(this.jugador.id.toString(),this.jugador.equipoId.toString()).subscribe(e => {
      this.jugador.nombre = e.nombre;
      this.jugador.altura = e.altura;
      this.jugador.numero = e.numero;
      this.jugador.pais = e.pais;
      this.jugador.posicion = e.posicion;      
    });   
    // this.routeSub = this.route.params.subscribe(params => {
    //   this.jugadorId=params.idJugador;
    //   this.equipoId=params.equipoId;

    // });

  }
  onEdit(){ 
    this.router.navigateByUrl(`/equipos/${this.jugador.equipoId}/jugadores/${this.jugador.id}/edit`);
  }

  onDelete(jugador:Jugador){

    this.jugadorService.deleteJugador(jugador).subscribe();
    this.router.navigate([`/equipos/${jugador.equipoId}`])
  .then(() => {
    window.location.reload();
  });
  }
}
