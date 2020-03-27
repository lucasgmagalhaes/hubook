import { Injectable, EventEmitter } from "@angular/core";

@Injectable({
  providedIn: "root"
})
export class SessionService {
  private _isAuthenticated = new EventEmitter<boolean>(false);
  constructor() {}

  isAuthenticated() {
    return this._isAuthenticated.asObservable();
  }

  login() {
    this._isAuthenticated.next(true);
  }
}
