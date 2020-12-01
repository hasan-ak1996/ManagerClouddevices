import { Component, EventEmitter, Injector, OnInit, Output } from '@angular/core';
import { ControlServiceService } from '@app/control-service/control-service.service';
import { AppComponentBase } from '@shared/app-component-base';
import { CreateControlInputDto } from '@shared/service-proxies/service-proxies';
import { BsModalRef } from 'ngx-bootstrap/modal';

@Component({
  selector: 'app-edit-control',
  templateUrl: './edit-control.component.html',
  styleUrls: ['./edit-control.component.css']
})
export class EditControlComponent extends AppComponentBase  implements OnInit {
  saving = false;
  id: number;
  analogdisabled : boolean;
  digitaldisabled : boolean;
  serialdisabled : boolean ;
  control : CreateControlInputDto ;
  @Output() onSave = new EventEmitter<any>();
  constructor(injector: Injector,
    public controlServiceService : ControlServiceService,
    public bsModalRef: BsModalRef) {
      super(injector);
     }

  ngOnInit(): void {
    this.control  = this.controlServiceService.getItemByIndex(this.id);
    console.log(this.control.valueType)
    if(this.control.valueType.toString() == "Analog"){
      this.analogdisabled = false;
      this.digitaldisabled = true;
      this.serialdisabled = true;
    }else if(this.control.valueType.toString() == "Digital"){
      this.analogdisabled = true;
      this.digitaldisabled = false;
      this.serialdisabled = true;
    }else{
      this.analogdisabled = true;
      this.digitaldisabled = true;
      this.serialdisabled = false;
    }
  }

  selectValue(valType){
    if(valType == "Analog"){
      this.analogdisabled = false;
      this.digitaldisabled = true;
      this.serialdisabled = true;
    }else if(valType == "Digital"){
      this.analogdisabled = true;
      this.digitaldisabled = false;
      this.serialdisabled = true;
    }else{
      this.analogdisabled = true;
      this.digitaldisabled = true;
      this.serialdisabled = false;
    }
    console.log(valType);
  }


  



  
  save(): void {
    this.control.isAccessed = false;

    if( this.analogdisabled == true){
      this.control.valueAnalog = null
    }
    if(this.serialdisabled == true){
      this.control.valueString = null;
    }
    if(this.digitaldisabled == true){
      this.control.valueDigital = undefined;
    }
    console.log(this.control)
    this.saving = true;
    this.notify.info(this.l('SavedSuccessfully'));
    this.bsModalRef.hide();
    this.onSave.emit();
  }


}
