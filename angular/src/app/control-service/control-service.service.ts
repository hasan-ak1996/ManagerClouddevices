import { Injectable } from '@angular/core';
import { CreateControlInputDto } from '@shared/service-proxies/service-proxies';

@Injectable({
  providedIn: 'root'
})
export class ControlServiceService {
  controls  : CreateControlInputDto[] =[];
  toggleVal : boolean = false;
  iii : number;

addItem(item : CreateControlInputDto){
    this.controls.push(item);
}
deleteItem(index){
   this.controls.splice(index,1);
}
getItemByIndex(index){
  return this.controls[index];
}

  constructor() { }
}
