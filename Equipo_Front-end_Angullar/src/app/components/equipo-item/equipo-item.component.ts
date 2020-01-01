import { Component, OnInit, Input, EventEmitter, Output } from '@angular/core';
import { Equipo } from 'src/app/models/Equipo';
import { EquipoService} from 'src/app/services/equipo.service';
import { Router } from '@angular/router';


@Component({
  selector: 'app-equipo-item',
  templateUrl: './equipo-item.component.html',
  styleUrls: ['./equipo-item.component.css']
})
export class EquipoItemComponent implements OnInit {
  @Input() equipo=Equipo;
  @Output() deleteEquipo:EventEmitter<Equipo> = new EventEmitter();
  constructor(private equipoService:EquipoService, private router:  Router) { }

  ngOnInit() {
  }

  setClasses(){
    let classes = {
      equipo: true
    }
    return classes;
  }

  onEdit(equipo:Equipo){
    this.router.navigateByUrl(`/equipos/${equipo.id}/edit`);

  }
  onVer(equipo:Equipo){
    this.router.navigateByUrl(`/equipos/${equipo.id}`);

  }
  onDelete(equipo){
    this.deleteEquipo.emit(equipo);
  }

}
