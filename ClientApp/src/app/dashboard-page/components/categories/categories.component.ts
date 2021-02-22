import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-categories',
  templateUrl: './categories.component.html',
  styleUrls: ['./categories.component.scss']
})
export class CategoriesComponent implements OnInit {
  imgUrls:string[] = [
    "https://static.centro.org.uk/img/wmca/favicons/android-chrome-192x192.png",
    "https://static.centro.org.uk/img/wmca/favicons/android-chrome-192x192.png",
    "https://static.centro.org.uk/img/wmca/favicons/android-chrome-192x192.png",
    "https://static.centro.org.uk/img/wmca/favicons/android-chrome-192x192.png",
    "https://static.centro.org.uk/img/wmca/favicons/android-chrome-192x192.png",
    "https://static.centro.org.uk/img/wmca/favicons/android-chrome-192x192.png",
    "https://static.centro.org.uk/img/wmca/favicons/android-chrome-192x192.png",
    "https://static.centro.org.uk/img/wmca/favicons/android-chrome-192x192.png",
    "https://static.centro.org.uk/img/wmca/favicons/android-chrome-192x192.png",

  ]
  constructor() { }

  ngOnInit(): void {
  }

}
