export class TokenHelpers {
  public static setTokens(accessToken: string, expiresIn: number) {
    sessionStorage.setItem('access_token', accessToken);
    sessionStorage.setItem('bearer_token', accessToken);
    // TODO: implement meaningful refresh, handle expiry 
    sessionStorage.setItem('expires_in', expiresIn.toString());
  }

  public static getAcessToken(): string {
    return sessionStorage.getItem('bearer_token');
  }

  public static removeTokens(){
    sessionStorage.removeItem('access_token');
    sessionStorage.removeItem('bearer_token');
    sessionStorage.removeItem('expires_in');
  }
}