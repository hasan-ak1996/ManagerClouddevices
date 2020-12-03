import { Component, forwardRef, OnInit } from '@angular/core';
import { ControlValueAccessor, NG_VALUE_ACCESSOR} from '@angular/forms';
import { ControlServiceService } from '@app/control-service/control-service.service';

@Component({
  selector: 'toggle-button',
  templateUrl: './toggle-button.component.html',
  styleUrls: ['./toggle-button.component.css'],
  providers: [     
    {       provide: NG_VALUE_ACCESSOR, 
            useExisting: forwardRef(() => ToggleButtonComponent),
            multi: true     
    } 
  ]
})
export class ToggleButtonComponent implements ControlValueAccessor {

  onChange: any = () => {}
  onTouch: any = () => {}
  toggle;

  constructor( public controlServiceService : ControlServiceService) { }
  set value(val){
    if( val !== undefined && this.toggle !== val && val !== null ){
      this.toggle = val;
      this.controlServiceService.toggleVal =  val
      this.onChange(val);
      this.onTouch(val);
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
