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
  view: any[] = [700, 300];
    single = [
  {
    "name": "Germany",
    "value": 8940000
  },
  {
    "name": "USA",
    "value": 5000000
  },
  {
    "name": "France",
    "value": 7200000
  }
];

  
  constructor(
    public deviceReadingServiceProxy : DeviceReadingServiceProxy
    ) {
      Object.assign(this, { this: this.single });
    }

    onSelect(event) {
      console.log(event);
    }

    // options
    showXAxis = true;
    showYAxis = true;
    gradient = false;
    showLegend = true;
    showXAxisLabel = true;
    xAxisLabel = 'Country';
    showYAxisLabel = true;
    yAxisLabel = 'Population';

  colorScheme = {
    domain: ['#5AA454', '#E44D25', '#CFC0BB', '#7aa3e5', '#a8385d', '#aae3f5']
  };

    

    



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
