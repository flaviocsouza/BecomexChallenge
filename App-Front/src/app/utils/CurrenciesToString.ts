import { Pipe, PipeTransform } from '@angular/core'

@Pipe({ name: 'CurrenciesToString' })
export class CurrenciesToString implements PipeTransform {
    transform(currencies:any[]): string{        
        if(currencies.length == 0) return '';
        let strReturn = currencies.shift().code;
        currencies.forEach( currency => strReturn +=`,  ${currency.code}`)
        return strReturn;
    }
}
