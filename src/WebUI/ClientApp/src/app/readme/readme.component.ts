import { Component } from '@angular/core';

@Component({
  selector: 'app-readme-component',
  templateUrl: './readme.component.html'
})
export class ReadmeComponent {
  public currentCount = 0;

  public incrementReadme() {
    this.currentCount++;
  }
}
