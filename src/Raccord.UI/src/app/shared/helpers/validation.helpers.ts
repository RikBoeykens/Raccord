export class ValidationHelpers {

    public static isValidPassword(input: string): boolean {
        if (!this.passwordHasMinSixCharacters(input)) {
            return false;
        }
        if (!this.passwordHasLowercaseCharacter(input)) {
            return false;
        }
        if (!this.passwordHasUppercaseCharacter(input)) {
            return false;
        }
        if (!this.passwordHasDigit(input)) {
            return false;
        }
        if (!this.passwordHasSpecialCharacter(input)) {
            return false;
        }
        return true;
    }

    public static passwordHasMinSixCharacters(input: string): boolean {
        return input.length > 6;
    }

    public static passwordHasLowercaseCharacter(input: string): boolean {
        return !(input.toUpperCase() === input);
    }

    public static passwordHasUppercaseCharacter(input: string): boolean {
        return !(input.toLowerCase() === input);
    }

    public static passwordHasDigit(input: string): boolean {
        return /\d/.test(input);
    }

    public static passwordHasSpecialCharacter(input: string): boolean {
        return /[!@#$%^&*()_+\-=\[\]{};':"\\|,.<>\/?]+/.test(input);
    }
}
