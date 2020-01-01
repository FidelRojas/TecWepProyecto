import { Component, OnInit } from '@angular/core';
import { Equipo } from 'src/app/models/Equipo';
import { EquipoService} from '../../services/equipo.service'
@Component({
  selector: 'app-equipos',
  templateUrl: './equipos.component.html',
  styleUrls: ['./equipos.component.css']
})
export class EquiposComponent implements OnInit {
  equipos:Equipo[];
  constructor(private equipoService: EquipoService) { }

  ngOnInit() {
    this.equipoService.getEquipos().subscribe( equipos=>{
      this.equipos = equipos;
    });
  }
  deleteEquipo(equipo:Equipo){
    this.equipos=this.equipos.filter(e => e.id !== equipo.id);
    this.equipoService.deleteEquipo(equipo).subscribe();
  }

  addEquipo(equipo:Equipo){
    this.equipoService.addEquipo(equipo).subscribe(equipo => {
      this.equipos.push(equipo);
    });
  }
  

}
