import { Component, OnInit } from '@angular/core';
import { FormGroup, Validators, FormBuilder } from '@angular/forms';
import { BsModalService } from 'ngx-bootstrap/modal';
import { defineLocale, BsLocaleService, ptBrLocale } from 'ngx-bootstrap';
import { ToastrService } from 'ngx-toastr';
defineLocale('pt-br', ptBrLocale);

import { EventoService } from '../_services/evento.service';
import { Evento } from '../_models/Evento';

@Component({
  selector: 'app-eventos',
  templateUrl: './eventos.component.html',
  styleUrls: ['./eventos.component.css']
})
export class EventosComponent implements OnInit {
  eventos: Evento[];
  evento: Evento;
  dataEvento: string;
  modoSalvar = 'post';
  bodyDeletarEvento = '';
  // tslint:disable: no-inferrable-types
  imagemLargura: number = 50;
  imagemAltura: number = 30;
  imagemMargem: number = 2;
  mostrarImagem: boolean = false;
  registerForm: FormGroup;
  titulo = 'Eventos';

  // tslint:disable-next-line: variable-name
  _FiltroLista: string;
  eventosFiltrados: Evento[];

  file: File;
  fileNameToUpdate: string;

  constructor(private eventoService: EventoService
            , private modalService: BsModalService
            , private fb: FormBuilder
            , private localeService: BsLocaleService
            , private toastr: ToastrService ) {
      this.localeService.use('pt-br');
    }

  get filtroLista() {
    return this._FiltroLista;
  }
  set filtroLista(value: string) {
    this._FiltroLista = value;
    this.eventosFiltrados = this.filtroLista ? this.filtrarEventos(this.filtroLista) : this.eventos;
  }

  editarEvento(evento: Evento, template: any) {
    this.modoSalvar = 'put';
    this.openModal(template);
    this.evento = evento;
    this.registerForm.patchValue(evento);
  }

  novoEvento(template: any) {
    this.modoSalvar = 'post';
    this.openModal(template);
  }

  excluirEvento(evento: Evento, template: any) {
    this.openModal(template);
    this.evento = evento;
    this.bodyDeletarEvento = `Tem certeza que deseja excluir o Evento: ${evento.tema}, Código: ${evento.id}`;
  }

  confirmeDelete(template: any) {
    this.eventoService.deleteEvento(this.evento.id).subscribe(
      () => {
          template.hide();
          this.getEventos();
          this.toastr.success('Deletado com sucesso!');
        }, error => {
          console.log(error);
          this.toastr.error(`Erro ao delatar, ${error}`);
        }
    );
  }

  openModal(template: any) {
    this.registerForm.reset();
    template.show(template);
  }

  ngOnInit() {
    this.validation();
    this.getEventos();
  }

  alternarImagem() {
    this.mostrarImagem = !this.mostrarImagem;
  }

  filtrarEventos(filtrarPor: string): Evento[] {
    filtrarPor = filtrarPor.toLocaleLowerCase();
    return this.eventos.filter(
      evento => evento.tema.toLocaleLowerCase().indexOf(filtrarPor) !== -1
    );
  }

  salvarAlteracao(template: any) {
    if (this.registerForm.valid) {
      if (this.modoSalvar === 'post') {
        this.evento = Object.assign({}, this.registerForm.value);
        this.eventoService.postEvento(this.evento).subscribe(
          (novoEvento: Evento) => {
            console.log(novoEvento);
            template.hide();
            this.getEventos();
            this.toastr.success('Evento adicionado com sucesso!');
          }, error => {
            console.log(error);
            this.toastr.error(`Erro ao adicionar o evento, ${error}`);
          }
        );
      } else {
        // Object.assign concartena o objeto com mais campos...
        // no caso os campos do formulario com o id do evento
        this.evento = Object.assign({id: this.evento.id}, this.registerForm.value);
        this.eventoService.putEvento(this.evento).subscribe(
          () => {
            template.hide();
            this.getEventos();
            this.toastr.success('Evento alterado com sucesso!');
          }, error => {
            console.log(error);
            this.toastr.error(`Erro ao adicionar o evento, ${error}`);
          }
        );
      }
    }
  }

  validation() {
    this.registerForm = this.fb.group({
      tema: ['', [Validators.required, Validators.minLength(4), Validators.maxLength(50)]],
      local: ['', Validators.required],
      dataEvento: ['', Validators.required],
      qtdPessoas: ['', [Validators.required, Validators.maxLength(1000)]],
      imagemUrl: ['', Validators.required],
      telefone: ['', Validators.required],
      email: ['', [Validators.required, Validators.email]],
    });
  }

  onFileChange(event) {
    const reader = new FileReader();

    if (event.target.files && event.target.files.length) {
      this.file = event.target.files;
      console.log(this.file);
    }
  }

  getEventos() {
    this.eventoService.getAllEvento().subscribe(
      // tslint:disable-next-line: variable-name
      (_eventos: Evento[]) => {
      this.eventos = _eventos;
      this.eventosFiltrados = this.eventos;
    }, error => {
      this.toastr.error(`Erro ao tenta carregar eventos, ${error}`);
    });
  }
}
