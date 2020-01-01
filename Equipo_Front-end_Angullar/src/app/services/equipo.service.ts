import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import {HttpClient, HttpHeaders} from '@angular/common/http'
import { Equipo } from '../models/Equipo';
import { EquipoDetalleComponent } from '../components/equipo-detalle/equipo-detalle.component';

const httpOptions = {
  headers: new HttpHeaders({
    'Content-Type': 'application/json'
  })
}
@Injectable({
  providedIn: 'root'
})
export class EquipoService {

  equiposUrl: string = 'http://localhost:64498/api/equipos';
  constructor(private http:HttpClient) { }

  getEquipos():Observable<Equipo[]>{
    return this.http.get<Equipo[]>(this.equiposUrl);
  }

  //deleteEquipo
  deleteEquipo(equipo:Equipo):Observable<Equipo>{
    console.log("Se elimino ",equipo.nombre);

    const url =`${this.equiposUrl}/${equipo.id}`;
    return this.http.delete<Equipo>(url, httpOptions);
  }

  addEquipo(equipo:Equipo):Observable<Equipo>{
    console.log("Se aniadio ",equipo.nombre);
    let body = JSON.stringify(equipo);

    return this.http.post<Equipo>(this.equiposUrl, body, httpOptions);
  }
  getEquipo(id:string):Observable<Equipo> {
    return this.http.get<Equipo>(`${this.equiposUrl}/${id}`);
  }
  editEquipo(equipo:Equipo):Observable<any>{
    console.log("Se edito el equipo ",equipo.id);
    
    const url=`${this.equiposUrl}/${equipo.id}`;
    return this.http.put(url,equipo,httpOptions)
  }
}
