import { Component, OnInit } from '@angular/core';
import { HttpClient } from '@angular/common/http';

@Component({
  selector: 'app-eventos',
  templateUrl: './eventos.component.html',
  styleUrls: ['./eventos.component.css']
})
export class EventosComponent implements OnInit {

  _FiltroLista: string;

  get filtroLista() {
    return this._FiltroLista;
  }
  set filtroLista(value: string) {
    this._FiltroLista = value;
    this.eventosFiltrados = this.filtroLista ? this.filtrarEventos(this.filtroLista) : this.eventos;
  }

  eventosFiltrados: any = [];

  eventos: any = [];
  imagemLargura: number = 50;
  imagemAltura: number = 30;
  imagemMargim: number = 2;
  mostrarImagem: boolean = false;

  constructor(private http: HttpClient) { }

  ngOnInit() {
    this.obterEvento();
  }

  alternarImagem() {
    this.mostrarImagem = !this.mostrarImagem;
  }

  filtrarEventos(filtrarPor: string): any {
    filtrarPor = filtrarPor.toLocaleLowerCase();
    return this.eventos.filter(
      evento => evento.tema.toLocaleLowerCase().indexOf(filtrarPor) !== -1
    );
  }

  obterEvento() {
    this.http.get('http://localhost:5000/api/values').subscribe(response => {
      this.eventos = response;
    }, error => {
      console.log(error);
    });
  }
}
