import { Injectable } from '@angular/core';

@Injectable({
    providedIn: 'root'
})
export class BgImgRefreshService {

    private imagePath = 'assets/images/bg/';
    private imageBaseName = 'bg';
    private imageExtension = '.jpg';
    private fileCount = 5;

    /**
     * Url of Image
     */
    imageUrl(): string {
        const number = this.randomNumber();
        return `url(${this.randomImagePath(number)})`;
    }

    /**
     * Random Path of Image
     * @param random
     */
    randomImagePath(random: Number): string {
        return this.imagePath.concat(this.imageBaseName, random.toString(), this.imageExtension);
    }

    /**
     * Generate Random Number between 1 and 5
     */
    randomNumber(): number {
        return Math.ceil(Math.random() * this.fileCount);
    }

}
