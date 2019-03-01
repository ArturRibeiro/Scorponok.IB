import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { ChurchComponent } from './church.component';

const routes: Routes = [{
  path: '',
  component: ChurchComponent,
}];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class ChurchRoutingModule { }

export const routedComponents = [
  ChurchComponent  
];
