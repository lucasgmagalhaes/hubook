import { Injectable, EventEmitter } from "@angular/core";

@Injectable({
  providedIn: "root"
})
export class SessionService {
  private _isAuthenticated = new EventEmitter<boolean>(true);
  constructor() {}

  isAuthenticated() {
    this._isAuthenticated.next(true);
    return this._isAuthenticated.asObservable();
  }

  login() {
    this._isAuthenticated.next(true);
  }
}
