import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { ChurchRoutingModule, routedComponents } from './church-routing.module';

@NgModule({
  declarations: [
    ...routedComponents
  ],
  imports: [
    CommonModule,
    ChurchRoutingModule
  ]
})
export class ChurchModule { }


