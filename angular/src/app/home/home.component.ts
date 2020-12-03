import { Component, Injector, ChangeDetectionStrategy, OnInit } from '@angular/core';
import { AppComponentBase } from '@shared/app-component-base';
import { appModuleAnimation } from '@shared/animations/routerTransition';
import { Router } from '@angular/router';
import { DeviceDto, DeviceServiceProxy } from '@shared/service-proxies/service-proxies';

@Component({
  templateUrl: './home.component.html',
  animations: [appModuleAnimation()],
})
export class HomeComponent extends AppComponentBase implements OnInit {
  userId ;
  devices : DeviceDto[] = [];
  deviceIdTest;
  toggleValue;

  constructor(
    injector: Injector,
    private router : Router,
    public _deviceService: DeviceServiceProxy,
    ) {
    super(injector);
    
  }
  ngOnInit(): void {
    this.userId = this.appSession.userId;
    this._deviceService.getAllDevicesForUser(this.userId).subscribe((res)=>{
      this.devices = res;
      if(res.length == 0){
      this.router.navigate(['app/add-device']);
      }
    });

    
  }

  createDevice(){
    this.router.navigate(['app/add-device']);
  }
}
