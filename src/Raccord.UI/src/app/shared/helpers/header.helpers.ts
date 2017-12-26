import { TokenHelpers } from "../../security/helpers/token.helpers";
import { Headers } from '@angular/http';

export class HeaderHelpers {
    // for requesting secure data using json
    public static AuthJsonHeaders():Headers {
        let header = new Headers();
        header.append('Content-Type', 'application/json');
        header.append('Accept', 'application/json');
        header.append('Authorization', `Bearer ${TokenHelpers.getAcessToken()}`);
        return header;
    }
 
    // for requesting secure data from a form post
    public static AuthFormHeaders():Headers {
        let header = new Headers();
        header.append('Content-Type', 'application/json');
        header.append('Accept', 'application/json');
        header.append('Authorization', `Bearer ${TokenHelpers.getAcessToken()}`);
        return header;
    }

    public static FormDataHeaders(): Headers{
        let header = new Headers();
        return header;
    }

    public static AuthFormDataHeaders(): Headers{
        let header = new Headers();
        header.append('Authorization', `Bearer ${TokenHelpers.getAcessToken()}`);
        return header;
    }
 
    // for requesting unsecured data using json
    public static JsonHeaders():Headers {
        let header = new Headers();
        header.append('Content-Type', 'application/json');
        header.append('Accept', 'application/json');
        return header;
    }
 
    // for requesting unsecured data using form post
    public static ContentHeaders():Headers {
        let header = new Headers();
        header.append('Content-Type', 'application/x-www-form-urlencoded');
        header.append('Accept', 'application/json');
        return header;
    }
}