import { Component, forwardRef, Injector, OnInit } from '@angular/core';
import { ControlValueAccessor, NG_VALUE_ACCESSOR} from '@angular/forms';
import { ControlServiceService } from '@app/control-service/control-service.service';
import { PagedListingComponentBase, PagedRequestDto } from '@shared/paged-listing-component-base';
import { DeviceReadingDto, DeviceReadingDtoPagedResultDto, DeviceReadingServiceProxy } from '@shared/service-proxies/service-proxies';
import { finalize } from 'rxjs/operators';
class PagedReadingsRequestDto extends PagedRequestDto {
  deviceId : number;
}
@Component({
  selector: 'full-data-reading',
  templateUrl: './full-data-reading.component.html',
  styleUrls: ['./full-data-reading.component.css'],
  providers: [     
    {       provide: NG_VALUE_ACCESSOR, 
            useExisting: forwardRef(() => FullDataReadingComponent),
            multi: true     
    } 
  ]
})
export class FullDataReadingComponent extends PagedListingComponentBase<DeviceReadingDto> implements ControlValueAccessor {
  protected delete(entity: DeviceReadingDto): void {
    throw new Error('Method not implemented.');
  }
  deviceId = 0 ;
  readings : DeviceReadingDto[] = [];
  onChange: any = () => {}
  onTouch: any = () => {}
  constructor(
    injector: Injector ,
    public deviceReadingServiceProxy : DeviceReadingServiceProxy,
    public controlServiceService : ControlServiceService,) {
    super(injector);
  }

  set value(val){
    if( val !== undefined && this.deviceId !== val && val !== null ){
      this.deviceId = val;
      this.onChange(val);
      this.onTouch(val);
    }
  }

  protected list(
    request: PagedReadingsRequestDto,
    pageNumber: number,
    finishedCallback: Function
    ): void {

      request.deviceId = this.controlServiceService.iii;

      this.deviceReadingServiceProxy.getAllReadingForDevice(
        request.deviceId,
        request.maxResultCount,
        request.skipCount,
        ).pipe(
          finalize(() => {
            finishedCallback();
          })
        )
        .subscribe((res : DeviceReadingDtoPagedResultDto) =>{
        this.readings = res.items;
        this.showPaging(res, pageNumber);
        console.log(this.readings)
      })

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
    this.deviceId = this.controlServiceService.iii;
    this.getDataPage(1);
  }

}
