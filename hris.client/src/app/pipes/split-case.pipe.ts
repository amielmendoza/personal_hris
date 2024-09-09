import { Pipe, PipeTransform } from '@angular/core';

@Pipe({
  name: 'splitCase'
})
export class SplitCasePipe implements PipeTransform {

  transform(value: string): string {
    if (!value) return value;

    // Split the CamelCase/PascalCase words and capitalize the first letter of each word
    return value
      .replace(/([a-z0-9])([A-Z])/g, '$1 $2')
      .replace(/([A-Z])([A-Z][a-z])/g, '$1 $2')
      .replace(/\b\w/g, char => char.toUpperCase());
  }
}
