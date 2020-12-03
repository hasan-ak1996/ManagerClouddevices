import { Component, forwardRef, OnInit, ViewChild } from '@angular/core';
import { ControlValueAccessor, NG_VALUE_ACCESSOR} from '@angular/forms';
import { DeviceReadingDto, DeviceReadingServiceProxy } from '@shared/service-proxies/service-proxies';
@Component({
  selector: 'last-status',
  templateUrl: './last-status.component.html',
  styleUrls: ['./last-status.component.css'],
  providers: [     
    {       provide: NG_VALUE_ACCESSOR, 
            useExisting: forwardRef(() => LastStatusComponent),
            multi: true     
    } 
  ]
})
export class LastStatusComponent  implements ControlValueAccessor{
  deviceId;
  onChange: any = () => {}
  onTouch: any = () => {}
  deviceReadings : DeviceReadingDto [] = [] ;
  toggle;
  constructor(
    public deviceReadingServiceProxy : DeviceReadingServiceProxy
    ) {

    }

  set value(val){
    if( val !== undefined && this.deviceId !== val && val !== null ){
      this.deviceId = val;
      this.onChange(val);
      this.onTouch(val);
      setInterval(() => {
        this.deviceReadingServiceProxy.getLastReadingForDevice(this.deviceId).subscribe((res)=>{
          this.deviceReadings = res;
        })
      },5000);


    }
  }
  writeValue(value: any): void {
     this.value = value
  }
  registerOnChange(fn: any): void {
    this.onChange = fn
  }
  registerOnTouched(fn: any): void {
    this.onTouch = fn
  }
  setDisabledState?(isDisabled: boolean): void {
    throw new Error('Method not implemented.');
  }

  ngOnInit(): void {
  }

}
