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
  control = new CreateControlInputDto ();
  @Output() onSave = new EventEmitter<any>();
  constructor(injector: Injector,
    public controlServiceService : ControlServiceService,
    public bsModalRef: BsModalRef) {
      super(injector);
     }

  ngOnInit(): void {
    this.control  = this.controlServiceService.getItemByIndex(this.id)
  }

  
  save(): void {
    this.control.isAccessed = false;
    this.saving = true;
    this.notify.info(this.l('SavedSuccessfully'));
    this.bsModalRef.hide();
    this.onSave.emit();
  }

}
