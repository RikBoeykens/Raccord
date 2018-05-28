import { TokenHelpers } from '../../security/helpers/token.helpers';
import { HttpHeaders } from '@angular/common/http';
import { Headers } from '@angular/http';

export class HeaderHelpers {
    // for requesting secure data using json
    public static AuthJsonHeaders(): HttpHeaders {
        let header = new HttpHeaders();
        header = header.set('Content-Type', 'application/json');
        header = header.set('Accept', 'application/json');
        return header;
    }

    // for requesting secure data from a form post
    public static AuthFormHeaders(): HttpHeaders {
        let header = new HttpHeaders();
        header = header.set('Content-Type', 'application/json');
        header = header.set('Accept', 'application/json');
        return header;
    }

    public static FormDataHeaders(): HttpHeaders {
        let header = new HttpHeaders();
        return header;
    }

    public static AuthFormDataHeaders(): HttpHeaders {
        let header = new HttpHeaders();
        return header;
    }

    // for requesting unsecured data using json
    public static JsonHeaders(): HttpHeaders {
        let header = new HttpHeaders();
        header = header.set('Content-Type', 'application/json');
        header = header.set('Accept', 'application/json');
        return header;
    }

    // for requesting unsecured data using form post
    public static ContentHttpHeaders(): HttpHeaders {
        let header = new HttpHeaders();
        header = header.set('Content-Type', 'application/x-www-form-urlencoded');
        header = header.set('Accept', 'application/json');
        return header;
    }

    // for requesting unsecured data using form post
    public static ContentHeaders(): Headers {
        let header = new Headers();
        header.append('Content-Type', 'application/x-www-form-urlencoded');
        header.append('Accept', 'application/json');
        return header;
    }
}
