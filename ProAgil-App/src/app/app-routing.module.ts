import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';

import { EventosComponent } from './eventos/eventos.component';
import { PalestrantesComponent } from './palestrantes/palestrantes.component';
import { DashboardComponent } from './dashboard/dashboard.component';
import { ContatosComponent } from './contatos/contatos.component';
import { UserComponent } from './user/user.component';
import { LoginComponent } from './user/login/login.component';
import { RegistrationComponent } from './user/registration/registration.component';
import { AuthGuard } from './auth/auth.guard';

// criar as rotas que podem ser acessadas no site.
const routes: Routes = [
  { path: 'user', component: UserComponent,

  // obtem as rotas dos filhos que estão dentro do component user.
    children: [
      { path: 'login', component: LoginComponent },
      { path: 'registration', component: RegistrationComponent },
    ] },

  // canActivate: [AuthGuard]  controla as paginas com autenticação.
  { path: 'eventos', component: EventosComponent, canActivate: [AuthGuard] },
  { path: 'palestrantes', component: PalestrantesComponent, canActivate: [AuthGuard]  },
  { path: 'dashboard', component: DashboardComponent, canActivate: [AuthGuard]  },
  { path: 'contatos', component: ContatosComponent, canActivate: [AuthGuard]  },

  // caso não seja informado nada na rota será enviada para rota abaixo.
  { path: '', redirectTo: 'dashboard', pathMatch: 'full'},
  { path: '**', redirectTo: 'dashboard', pathMatch: 'full' },
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
