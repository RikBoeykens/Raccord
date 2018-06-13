import { OpenIdDictToken } from '..';
import { SaveToken } from '../model/save-token';

export class TokenHelpers {
  public static setTokens(openIdDictToken: OpenIdDictToken) {
    const now = new Date();
    const expiryDate =
      new Date(now.getTime() + openIdDictToken.expires_in * 1000).getTime();
    let tokens = this.getTokens();
    if (!tokens) {
      tokens = new SaveToken({
        accessToken: openIdDictToken.access_token,
        expiryDate,
        refreshToken: openIdDictToken.refresh_token
      });
    }
    tokens.accessToken = openIdDictToken.access_token;
    tokens.expiryDate = expiryDate;
    sessionStorage.setItem('auth-tokens', JSON.stringify(tokens));
  }

  public static getTokens(): SaveToken {
    const tokensString = sessionStorage.getItem('auth-tokens');
    return tokensString == null ? null : JSON.parse(tokensString);
  }

  public static removeTokens() {
    sessionStorage.clear();
  }
}
