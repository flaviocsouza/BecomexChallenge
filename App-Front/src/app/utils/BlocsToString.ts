import { Pipe, PipeTransform } from '@angular/core'

@Pipe({ name: 'BlocsToString' })
export class BlocsToString implements PipeTransform {
    transform(blocs:any[]): string{
        if(blocs.length == 0) return '';
        let strReturn = blocs.shift().name;
        blocs.forEach( bloc => strReturn +=`,  ${bloc.name}`);
        return strReturn;
    }
}
