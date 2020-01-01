import { Component, OnInit } from '@angular/core';
import { Equipo } from '../../models/Equipo';
import { ActivatedRoute } from '@angular/router';
import { EquipoService } from 'src/app/services/equipo.service';
import { Router } from '@angular/router';
import { from, Subscription } from 'rxjs';

@Component({
  selector: 'app-equipo-detalle',
  templateUrl: './equipo-detalle.component.html',
  styleUrls: ['./equipo-detalle.component.css']
})
export class EquipoDetalleComponent implements OnInit {
  equipo:Equipo;
  private routeSub: Subscription;
  equipoId:number;


  constructor(private equipoService:EquipoService, private route: ActivatedRoute, private router:  Router) {
    this.equipo=new Equipo;
   }

  ngOnInit() {
    const equipoId = this.route.snapshot.paramMap.get("equipoId");
    this.equipoService.getEquipo(equipoId).subscribe(e => {
      this.equipo = e;
    });   
    this.routeSub = this.route.params.subscribe(params => {
      this.equipoId=params.equipoId;
      
    });


  }
  onEdit(){ 
    this.router.navigateByUrl(`/equipos/${this.equipo.id}/edit`);
  }

  onDelete(equipo:Equipo){
    this.equipoService.deleteEquipo(equipo).subscribe();
    
    this.router.navigateByUrl(`/`);

  }
  ngOnDestroy() {
    this.routeSub.unsubscribe();
  }

}
