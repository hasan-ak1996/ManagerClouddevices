import { Component, EventEmitter, Injector, OnInit, Output } from '@angular/core';
import { ControlServiceService } from '@app/control-service/control-service.service';
import { AppComponentBase } from '@shared/app-component-base';
import { CreateControlInputDto } from '@shared/service-proxies/service-proxies';
import { BsModalRef } from 'ngx-bootstrap/modal';


@Component({
  selector: 'app-add-control',
  templateUrl: './add-control.component.html',
  styleUrls: ['./add-control.component.css']
})
export class AddControlComponent extends AppComponentBase  implements OnInit {
  saving = false;
  control = new CreateControlInputDto ();
  analogdisabled : boolean = true;
  digitaldisabled : boolean = true;
  serialdisabled : boolean = true;
  @Output() onSave = new EventEmitter<any>();
  constructor( 
    injector: Injector,
    public controlServiceService : ControlServiceService,
    public bsModalRef: BsModalRef

    ) {
    super(injector);
  }

  ngOnInit(): void {
    this.control.valueString;
    console.log(this.control.valueType)
    
  }
  save(): void {
    this.control.isAccessed = false;
    this.controlServiceService.addItem(this.control);
    this.saving = true;
    this.bsModalRef.hide();
    this.onSave.emit();
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
  }



}
