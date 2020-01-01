import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import {HttpClient, HttpHeaders} from '@angular/common/http'
import { Jugador } from '../models/Jugador';

const httpOptions = {
  headers: new HttpHeaders({
    'Content-Type': 'application/json'
  })
}
@Injectable({
  providedIn: 'root'
})
export class JugadorService {

  jugadorUrl: string = 'http://localhost:64498/api/equipos/';
  constructor(private http:HttpClient) { }
  //okGetJugadores
  getJugadores(equipoId:number):Observable<Jugador[]>{
    return this.http.get<Jugador[]>(this.jugadorUrl+equipoId+"/jugadores");
  }

  //deleteJugador
  deleteJugador(jugador:Jugador):Observable<Jugador>{
    console.log("Se elimino el jugador con nombre: ",jugador.nombre);

    const url =`${this.jugadorUrl}${jugador.equipoId}/jugadores/${jugador.id}`;
    return this.http.delete<Jugador>(url, httpOptions);
  }

  addJugador(jugador:Jugador):Observable<Jugador>{
    console.log("Se aniadio ",jugador.nombre);
    let body = JSON.stringify(jugador);
    return this.http.post<Jugador>(this.jugadorUrl+jugador.equipoId+"/jugadores", body, httpOptions);
  }
  getJugador(id:string,idEquipo:string):Observable<Jugador> {
    return this.http.get<Jugador>(`${this.jugadorUrl}${idEquipo}/jugadores/${id}`);
  }
  editJugador(jugador:Jugador):Observable<any>{
    console.log("Se edito el jugador ",jugador.id);
    
    const url=`${this.jugadorUrl}${jugador.equipoId}/jugadores/${jugador.id}`;
    return this.http.put(url,jugador,httpOptions)
  }
}
