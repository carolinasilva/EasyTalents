import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { CandidatesListComponent } from './candidates-list/candidates-list.component';
import { CandidateComponent } from './candidate/candidate.component';


const routes: Routes = [
  {
    path: '',
    redirectTo: 'candidates-list',
    pathMatch: 'full'
  },
  {
    path: 'candidates-list',
    component: CandidatesListComponent
  },
  {
    path: 'candidate',
    component: CandidateComponent
  },
  {
    path: 'candidate/:id',
    component: CandidateComponent
  },
  {
    path: '**',
    redirectTo: 'candidates-list',
  },
];

@NgModule({
  imports: [RouterModule.forRoot(routes, { onSameUrlNavigation: 'reload' })],
  exports: [RouterModule]
})
export class AppRoutingModule { }
