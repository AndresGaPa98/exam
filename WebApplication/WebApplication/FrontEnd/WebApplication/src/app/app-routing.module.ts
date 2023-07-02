import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';

const routes: Routes = [
  {
    path: '',
    loadChildren: () => import('../app/Modules/Store/store/store.module')
                        .then(m => m.StoreModule)
  },
  {
    path: 'Auth',
    loadChildren: () => import('../app/Modules/Auth/auth/auth.module')
                        .then(m => m.AuthModule)
  },

  {
    path: '**',
    redirectTo: '',
    pathMatch: 'full'
  }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
