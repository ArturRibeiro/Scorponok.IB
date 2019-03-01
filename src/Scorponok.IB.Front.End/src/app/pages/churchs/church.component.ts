import { Component, OnInit } from '@angular/core';

import { ChurchService } from './church.service';

@Component({
  selector: 'ngx-churchs',
  templateUrl: './church.component.html',
  styleUrls: ['./church.component.scss']
})
export class ChurchComponent implements OnInit {

  constructor(private churchService : ChurchService) { 
    this.churchService.getChurch()
    .subscribe(result => {
      console.log(result);
    });
    
  }

  ngOnInit() {
  }

}
