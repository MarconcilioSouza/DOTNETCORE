import { Component, OnInit } from '@angular/core';
import { EventoService } from 'src/app/_services/evento.service';
import { BsLocaleService } from 'ngx-bootstrap';
import { FormBuilder, FormGroup, Validators, FormArray } from '@angular/forms';
import { ToastrService } from 'ngx-toastr';
import { Evento } from 'src/app/_models/Evento';
import { ActivatedRoute } from '@angular/router';
import { Constants } from 'src/app/util/Constants';

@Component({
  selector: 'app-evento-edit',
  templateUrl: './eventoEdit.component.html',
  styleUrls: ['./eventoEdit.component.css']
})
export class EventoEditComponent implements OnInit {

  titulo = 'Editar Evento';
  evento: Evento = new Evento();
  imagemURL = '../../../assets/img/upload.png';
  registerForm: FormGroup;
  file: File;
  fileNameToUpdate: string;
  baseURL = Constants.baseURL;
  dataAtual = '';

  // usado dentro do html para obter os lotes
  // *ngFor="let lote of lotes.controls;
  get lotes(): FormArray {
    return this.registerForm.get('lotes') as FormArray;
  }

  get redesSociais(): FormArray {
    return  this.registerForm.get('redesSociais') as FormArray;
  }

  constructor(private eventoService: EventoService
            , private fb: FormBuilder
            , private localeService: BsLocaleService
            , private toastr: ToastrService
            , private router: ActivatedRoute
          ) {
            this.localeService.use('pt-br');
          }

  ngOnInit() {
    this.validation();
    this.carregarEvento();
  }

  carregarEvento() {
    // obtem o id passado na rota configurado nas rotas.
    // { path: 'evento/:id/edit', component: EventoEditComponent, canActivate: [AuthGuard] },
    // o sinal de + (+this.) converte a string para number.
    const idEvento = +this.router.snapshot.paramMap.get('id');
    this.dataAtual = new Date().getMilliseconds().toString();

    this.eventoService.getEventoById(idEvento)
      .subscribe(
        (evento: Evento) => {
          // carregar os dados na tela do edit
          this.evento = Object.assign({}, evento);
          this.fileNameToUpdate = evento.imagemUrl.toString();

          this.imagemURL = `${this.baseURL}/resources/images/${this.evento.imagemUrl}?_ts=${this.dataAtual}`;

          this.evento.imagemUrl = '';
          this.registerForm.patchValue(this.evento);

          // carregar os lotes na tela
          this.evento.lotes.forEach(lote => {
            // preencher no get lotes(): FormArray {
            // os dados dos lotes.
            this.lotes.push(this.criaLote(lote));
          });
          // carregar as redes sociais
          this.evento.redesSociais.forEach(redeSocial => {
            this.redesSociais.push(this.criaRedeSocial(redeSocial));
          });
        }
      );
  }

  /// criar a validação dos eventos
  validation() {
    this.registerForm = this.fb.group({
      id: [],
      tema: ['', [Validators.required, Validators.minLength(4), Validators.maxLength(50)]],
      local: ['', Validators.required],
      dataEvento: ['', Validators.required],
      imagemURL: [''],
      qtdPessoas: ['', [Validators.required, Validators.max(120000)]],
      telefone: ['', Validators.required],
      email: ['', [Validators.required, Validators.email]],
      lotes: this.fb.array([]),
      redesSociais: this.fb.array([])
    });
  }

  criaLote(lote: any): FormGroup {
    return this.fb.group({
      id: [lote.id],
      nome: [lote.nome, Validators.required],
      quantidade: [lote.quantidade, Validators.required],
      preco: [lote.preco, Validators.required],
      dataInicio: [lote.dataInicio],
      dataFim: [lote.dataFim]
    });
  }

  criaRedeSocial(redeSocial: any): FormGroup {
    return this.fb.group({
      id: [redeSocial.id],
      nome: [redeSocial.nome, Validators.required],
      url: [redeSocial.url, Validators.required]
    });
  }

  // adicionar o lote para o evento get Lotes.
  adicionarLote() {
    // o id é 0 para um novo
    this.lotes.push(this.criaLote({ id: 0 }));
  }

  adicionarRedeSocial() {
    this.redesSociais.push(this.criaRedeSocial({ id: 0 }));
  }

  removerLote(id: number) {
    this.lotes.removeAt(id);
  }

  removerRedeSocial(id: number) {
    this.redesSociais.removeAt(id);
  }

  onFileChange(evento: any, file: FileList) {
    const reader = new FileReader();

    reader.onload = (event: any) => this.imagemURL = event.target.result;

    this.file = evento.target.files;
    reader.readAsDataURL(file[0]);
  }

  salvarEvento() {
    this.evento = Object.assign({ id: this.evento.id }, this.registerForm.value);
    this.evento.imagemUrl = this.fileNameToUpdate;

    this.uploadImagem();

    this.eventoService.putEvento(this.evento).subscribe(
      () => {
        this.toastr.success('Editado com Sucesso!');
      }, error => {
        this.toastr.error(`Erro ao Editar: ${error}`);
      }
    );
  }

  uploadImagem() {
    if (this.registerForm.get('imagemURL').value !== '') {
      this.eventoService.postUpload(this.file, this.fileNameToUpdate)
        .subscribe(
          () => {
            this.dataAtual = new Date().getMilliseconds().toString();
            this.imagemURL = `${this.baseURL}/resources/images/${this.evento.imagemUrl}?_ts=${this.dataAtual}`;
          }
        );
    }
  }
}
