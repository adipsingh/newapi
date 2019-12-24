import { Injectable } from '@angular/core';
import { AuthService } from './auth.service';

@Injectable({
    providedIn: 'root'
})
export class PhraseGeneratorService {

    private phrases = [
        `Hi ${this.authService.userInfo.user.firstName}, Know any good jokes? Wait! Clean ones please.`,
        `Hi ${this.authService.userInfo.user.firstName}, You are such a data slinger.`,
        `Hi ${this.authService.userInfo.user.firstName}, Do you like action movies or romantic comedies?`,
        `Hi ${this.authService.userInfo.user.firstName}, If you just had one wish, you would?`,
        `Hi ${this.authService.userInfo.user.firstName}, How did you ever survive with out us?`,
        `Hi ${this.authService.userInfo.user.firstName}, We think transferring large files is cool. Is that nerdy?`,
        `Hi ${this.authService.userInfo.user.firstName}, Do you think the Mona Lisa is an overrated painting?`,
        `Hi ${this.authService.userInfo.user.firstName}, I think this is the beginning of a beautiful friendship.`,
        `Hi ${this.authService.userInfo.user.firstName}, Sometimes everything works out just like you planned it.`,
        `Hi ${this.authService.userInfo.user.firstName}, When are we going to lunch. It’s our treat, right?`,
        `Hi ${this.authService.userInfo.user.firstName}, Did you see that game last night? I can’t believe they won.`,
        `Hi ${this.authService.userInfo.user.firstName}, It’s really cool that your socks match your shirt. Snappy.`,
        `Hi ${this.authService.userInfo.user.firstName}, We are so glad you are with us today. Thanks for uploading.`,
        `Hi ${this.authService.userInfo.user.firstName}, I am really good at jumping rope, but just on the first jump.`
    ];

    constructor(public authService: AuthService) { }

    /**
     * Random Phrase
     */
    randomPhrase(): string {
        return this.phrases[this.randomNumber()];
    }

    /**
     * Generate Random Number between 1 and 5
     */
    randomNumber(): number {
        return Math.ceil(Math.random() * this.phrases.length);
    }
}
