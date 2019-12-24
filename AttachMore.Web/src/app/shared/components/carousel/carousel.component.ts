import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'am-carousel',
  templateUrl: './carousel.component.html',
  styleUrls: ['./carousel.component.scss']
})
export class CarouselComponent implements OnInit {

  images: string[];
  config: any = {
    pagination: '.swiper-pagination',
    paginationClickable: true,
    spaceBetween: 30,
    slidesPerView: 3,
    centeredSlides: true,
    autoplay: 10000,
  };

  constructor() { }

  ngOnInit() {
  }

}
