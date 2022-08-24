import { Component } from '@angular/core';
import { Router } from '@angular/router';
import { defineCustomElements } from '@ionic/pwa-elements/loader';


@Component({
  selector: 'app-root',
  templateUrl: 'app.component.html',
  styleUrls: ['app.component.scss'],
})
export class AppComponent {
  constructor(private router: Router) {
    defineCustomElements(window);
  }

  addPost() {
    this.router.navigate(['add-post'], { replaceUrl: true })
  }
}
