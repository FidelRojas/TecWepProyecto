import { Component, OnInit } from '@angular/core';
import { EquipoService} from '../../services/equipo.service'
import { Equipo } from 'src/app/models/Equipo';
import { Router } from '@angular/router';

@Component({
  selector: 'app-add-equipo',
  templateUrl: './add-equipo.component.html',
  styleUrls: ['./add-equipo.component.css']
})
export class AddEquipoComponent implements OnInit {
  
  nombre:string;
  info:string;
  entrenador:string;
  estadio:string;
  fundacion:string;
  e:Equipo=new Equipo;

  
  constructor(private equipoService: EquipoService, private router: Router) { }

  ngOnInit() {
  }

  
  onSubmit(){
   
    this.e.nombre=this.nombre;
    this.e.info=this.info;
    this.e.entrenador=this.entrenador;
    this.e.estadio=this.estadio;
    this.e.fundacion=this.fundacion;
    this.equipoService.addEquipo(this.e).subscribe(
      
      equipo => {this.router.navigateByUrl(`/equipos/${equipo.id}`);});
      
    
  };

  }

