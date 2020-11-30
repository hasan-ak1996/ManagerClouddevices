import { Component, Injector, OnInit } from '@angular/core';
import { ActivatedRoute, Params, Router } from '@angular/router';
import { AddControlComponent } from '@app/add-control/add-control.component';
import { ControlServiceService } from '@app/control-service/control-service.service';
import { EditControlComponent } from '@app/edit-control/edit-control.component';
import { AppComponentBase } from '@shared/app-component-base';
import { CreateControlInputDto, DeviceControlServiceProxy, DeviceDto, DeviceReadingDto, DeviceReadingServiceProxy, DeviceServiceProxy } from '@shared/service-proxies/service-proxies';
import { BsModalRef, BsModalService } from 'ngx-bootstrap/modal';

@Component({
  selector: 'app-add-connection',
  templateUrl: './add-connection.component.html',
  styleUrls: ['./add-connection.component.css']
})
export class AddConnectionComponent extends AppComponentBase implements OnInit {
  id: number;
  device = new DeviceDto ();
  secretkey;
  status;
  conrols : CreateControlInputDto[] = [];
  readings : DeviceReadingDto[] = [];
  constructor(njector: Injector,
    private _router: Router,
    private _activatedRoute: ActivatedRoute,
    public _deviceService: DeviceServiceProxy,
    public _deviceControlService: DeviceControlServiceProxy,
    private _modalService: BsModalService,
    public controlServiceService : ControlServiceService,
    public deviceReadingServiceProxy : DeviceReadingServiceProxy,
    private router: Router,
    )
     {
    super(njector);
  }

  ngOnInit(): void {
    this._activatedRoute.params.subscribe((params: Params) => {
      this.id = params['id']; });
      this._deviceService.getDeviceById(this.id).subscribe((res) => {
        this.device = res ;
        if(res.status == 0){
          this.status = "Disabled"
        }else{
          this.status = "Active"
        }
      });
    this.secretkey = this.appSession.user.secretKey;
    this.deviceReadingServiceProxy.getAllReadingForDevice(this.id).subscribe((res) =>{
      this.readings = res;
      console.log(this.readings)
    })
  }

  createControl(): void {
    this.showCreateItemDialog();
  }
  private showCreateItemDialog(): void {
    let createOrEditItemDialog: BsModalRef;
      createOrEditItemDialog = this._modalService.show(
        AddControlComponent,
        {
          class: 'modal-lg',
        }
      );
    
    createOrEditItemDialog.content.onSave.subscribe(() => {
       this.conrols =  this.controlServiceService.controls;
       this.conrols.forEach((i) => {
        console.log(i)
      })
    });
  }
  editControl(id :number): void {
    this.showEditItemDialog(id);
  }

  private showEditItemDialog(id: number): void {
    let createOrEditItemDialog: BsModalRef;
      createOrEditItemDialog = this._modalService.show(
        EditControlComponent,
        {
          class: 'modal-lg',
          initialState: {
            id: id,
          },
        }
      );
    
    createOrEditItemDialog.content.onSave.subscribe(() => {
      this.conrols =  this.controlServiceService.controls;
    });
    

  }

  protected delete(index){
    abp.message.confirm(
      this.l('ItemDeleteWarningMessage'),
      undefined,
      (result: boolean) => {
        if (result) {
          this.controlServiceService.deleteItem(index);
            abp.notify.success(this.l('SuccessfullyDeleted'));
            this.conrols =  this.controlServiceService.controls;
        }
      }
    );
  }

  save(){
    this.conrols.forEach((control) => {
      control.deviceId = this.id;
      
      this._deviceControlService.createControl(control).subscribe(()=>{
        console.log("ok")
      })
      abp.notify.success(this.l('SuccessfullySaved'));
      this.controlServiceService.controls = [];
    });
    this.router.navigate(['app/home']);

  }

}
