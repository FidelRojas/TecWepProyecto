import { Component, OnInit,Input, EventEmitter,Output } from '@angular/core';
import { JugadorService} from '../../../services/jugador.service'
import { Jugador } from 'src/app/models/Jugador';
import { Router, ActivatedRoute } from '@angular/router';
import { Subscription } from 'rxjs';

import * as $ from 'jquery';
@Component({
  selector: 'app-add-jugador',
  templateUrl: './add-jugador.component.html',
  styleUrls: ['./add-jugador.component.css']
})
export class AddJugadorComponent implements OnInit {
  
  nombre:string;
  pais:string;
  altura:number;
  numero:number;
  posicion:string;
  j:Jugador=new Jugador;
  @Input() idEquipo:number;
  @Output() addJugador:EventEmitter<Jugador> = new EventEmitter();

  private routeSub: Subscription;
  
  constructor(private jugadorService: JugadorService, private router: Router,  private route: ActivatedRoute ) { }

  ngOnInit() {
    this.routeSub = this.route.params.subscribe(params => {
      this.idEquipo=params.equipoId;

    });
   
  }

  
  onSubmit(){
    this.j.altura=this.altura;
    this.j.nombre=this.nombre;
    this.j.pais=this.pais;
    this.j.numero=this.numero;
    this.j.posicion=this.posicion;
    this.j.equipoId=this.idEquipo;
    this.addJugador.emit(this.j);
    $(document).ready(function(){
      $("#addModal").click();
  });
    this.nombre="";
    this.pais="";
    this.altura=null;
    this.numero=null;
    this.posicion="";


  };

  }

