import { Component, OnInit } from '@angular/core';
import { Jugador } from 'src/app/models/Jugador';
import { JugadorService } from 'src/app/services/jugador.service';
import { ActivatedRoute, Router } from '@angular/router';

@Component({
  selector: 'app-jugador-edit',
  templateUrl: './jugador-edit.component.html',
  styleUrls: ['./jugador-edit.component.css']
})
export class JugadorEditComponent implements OnInit {
  jugador:Jugador;
  constructor(private jugadorSevice:JugadorService, private route: ActivatedRoute,private router: Router) { 
    this.jugador=new Jugador;
  }

  onSubmitEdit(jugador:Jugador){
    this.jugadorSevice.editJugador(jugador).subscribe(t => {
      console.log(t);
      this.router.navigateByUrl(`/equipos/${jugador.equipoId}`);
    });
  }
  ngOnInit() {
    const jugadorId = this.route.snapshot.paramMap.get("idJugador");
    const equipoId = this.route.snapshot.paramMap.get("equipoId");
     
    this.jugadorSevice.getJugador(jugadorId,equipoId).subscribe(j => {
      this.jugador = j;
      this.jugador.id=parseInt(jugadorId);
      this.jugador.equipoId=parseInt(equipoId);
    });   
  }
  
  
  alturaCal(){
    $(document).ready(function(){
      // Read value on page load
      var b=$("#altura").val().toString();
      $("#alturadiv b").html(b);
        // Read value on change
        $("#customRange").change(function(){
          var a=$(this).val().toString(); 
            $("#alturadiv b").html(a);
        });
    });
  }

}
