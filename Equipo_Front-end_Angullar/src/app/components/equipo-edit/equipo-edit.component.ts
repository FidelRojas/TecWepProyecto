import { Component, OnInit } from '@angular/core';
import { Equipo } from '../../models/Equipo';
import { ActivatedRoute, Router } from '@angular/router';
import { EquipoService } from 'src/app/services/equipo.service';

@Component({
  selector: 'app-equipo-edit',
  templateUrl: './equipo-edit.component.html',
  styleUrls: ['./equipo-edit.component.css']
})
export class EquipoEditComponent implements OnInit {
  equipo:Equipo;

  constructor(private equipoService:EquipoService, private route: ActivatedRoute,private router: Router) {
    this.equipo=new Equipo;
   }

  ngOnInit() {
    const equipoId = this.route.snapshot.paramMap.get("equipoId");
    this.equipoService.getEquipo(equipoId).subscribe(e => {
      this.equipo = e;
      this.equipo.id=parseInt(equipoId);

    });   
  }
  
  onSubmit(equipo:Equipo){

    this.equipoService.editEquipo(equipo).subscribe(t => {
      console.log(t);
      this.router.navigateByUrl(`/equipos/${equipo.id}`);
    });
  }

}
