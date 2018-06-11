export class ValidationHelpers {

    public static isValidPassword(input: string): boolean {
        if (input.length < 6) {
            return false;
        }
        if (input.toUpperCase() === input) {
            return false;
        }
        if (input.toLowerCase() === input ) {
            return false;
        }
        if (!/\d/.test(input)) {
            return false;
        }
        if (!/[!@#$%^&*()_+\-=\[\]{};':"\\|,.<>\/?]+/.test(input)) {
            return false;
        }
        return true;
    }
}
