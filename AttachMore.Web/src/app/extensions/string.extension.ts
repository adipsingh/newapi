interface String {
    random: (length: number) => string;
}


String.prototype.random = function (length: number): string {
    let randomString = '';
    const alphaNumericCharcters = 'ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789';
    for (let index = 0; index < length; index++) {
        randomString += alphaNumericCharcters.charAt(Math.floor(Math.random() * alphaNumericCharcters.length));
    }
    return `${this}${randomString}`;
};

