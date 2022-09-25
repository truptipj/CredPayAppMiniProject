import { Pipe, PipeTransform } from '@angular/core';

@Pipe({
  name: 'maskCard',
})
export class MaskPipe implements PipeTransform {

  transform(card: any): string {
    let cardNum = card.toString();
    if (!(cardNum.length === 3)) {
      const visibleDigits = 4;
      let maskedSection = cardNum.slice(0, -visibleDigits);
      let visibleSection = cardNum.slice(-visibleDigits);
      return maskedSection.replace(/./g, '*') + visibleSection;
    } else {
      return 'CVV';
    }
    // let input = card.toString();
    // return input = input.substring(0,4)+' '+input.substring(4,8)+'  '+input.substring(8,12)+'  '+input.substring(12,16);
  }
}
