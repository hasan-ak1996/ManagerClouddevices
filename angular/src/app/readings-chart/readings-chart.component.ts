import { Component, forwardRef, Input, OnInit, TestabilityRegistry } from '@angular/core';
import { ControlValueAccessor, NG_VALUE_ACCESSOR} from '@angular/forms';
import { ControlServiceService } from '@app/control-service/control-service.service';
import { DeviceReadingDto, DeviceReadingServiceProxy } from '@shared/service-proxies/service-proxies';
import { ChartDataSets, ChartOptions } from 'chart.js';
import { Color, Label } from 'ng2-charts';

@Component({
  selector: 'readings-chart',
  templateUrl: './readings-chart.component.html',
  styleUrls: ['./readings-chart.component.css'],
  providers: [     
    {       provide: NG_VALUE_ACCESSOR, 
            useExisting: forwardRef(() => ReadingsChartComponent),
            multi: true     
    } 
  ]
})
export class ReadingsChartComponent implements ControlValueAccessor{
  readings :any [] = [];
  test3 : number [] =[];
  toggle;
  toggleVal = this.controlServiceService.toggleVal;
  public lineChartData: ChartDataSets[] = [
    { data: this.readings, label: 'value' },
  ];
  public lineChartLabels: Label[] = ['0', '10', '20', '30', '40', '50', '60','70','80','90','100'];

  public lineChartColors: Color[] = [
    {
      borderColor: 'black',
      backgroundColor: 'rgba(255,0,0,0.3)',
    },
  ];
  public lineChartLegend = true;
  public lineChartType = 'line';
  public lineChartPlugins = [];

  constructor(public deviceReadingServiceProxy : DeviceReadingServiceProxy,
    public controlServiceService : ControlServiceService) {
   }
  test : DeviceReadingDto [] = [];

  @Input() deviceId;
  @Input() readingName;
  onChange: any = () => {}
  onTouch: any = () => {}
  set value(val){
    if( val !== undefined && this.deviceId !== val && val !== null ){
      this.deviceId = val;
      this.onChange(val);
      this.onTouch(val);
      console.log(this.toggleVal)
    }
  }
  writeValue(value: any): void {
    this.value = value;
    
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
      this.deviceReadingServiceProxy.getAllReadingsByName(this.deviceId,this.readingName).subscribe((res)=>{
        if(this.toggleVal == false){
          res.forEach((i) => {
            if(i.valueType == 1){
              this.readings.push(i.valueAnalog)
            }
            
           })
        }else{
          res.forEach((i) => {
            if(i.valueType == 0)
            this.readings.push(i.valueDigital)
           })
        }
       
      })
      
  }

}


