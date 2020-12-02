import { Component, EventEmitter, Injector, OnInit, Output } from '@angular/core';
import { Router } from '@angular/router';
import { AppComponentBase } from '@shared/app-component-base';
import { DeviceInputDto, DeviceServiceProxy } from '@shared/service-proxies/service-proxies';
import { BsModalService } from 'ngx-bootstrap/modal';
import { finalize } from 'rxjs/operators';

@Component({
  selector: 'app-add-device',
  templateUrl: './add-device.component.html',
  styleUrls: ['./add-device.component.css']
})
export class AddDeviceComponent extends AppComponentBase  implements OnInit {
  device = new DeviceInputDto ();
  saving = false;
  deviceId: number;
  @Output() onSave = new EventEmitter<any>();
  
  constructor(
    injector: Injector,
    public _deviceService: DeviceServiceProxy,
    private _modalService: BsModalService,
    private router: Router,
  ) {
    super(injector);
   }

  ngOnInit(): void {
  }
  save(): void {
    
    this.saving = true;
    this.device.userId = this.appSession.userId;
    this._deviceService
      .createDevice(this.device)
      .pipe(
        finalize(() => {
          this.saving = false;
        })
      )
      .subscribe((res) => {
        console.log(res);
        this.notify.info(this.l('SavedSuccessfully'));
        this.onSave.emit();
        this._deviceService.getDeviceForView(this.appSession.userId).subscribe((res)=>{
          this.deviceId = res.id;
          console.log(this.deviceId)
          this.router.navigate(['app/add-connection',  this.deviceId]);
        });
        
        //this.dataItemsService.lines =[];
      });
  }

}
