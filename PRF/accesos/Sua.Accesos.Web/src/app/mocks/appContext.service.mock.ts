import { Injectable } from '@angular/core';
import { Observable, of } from 'rxjs';
import { AppContext } from '../models/appContext';

/**
 * @description
 * @class
 */
@Injectable()
export class AppContextServiceMock {
  private appContext: AppContext;

  constructor() {}

  setActualContext(context: AppContext) {
      this.appContext = context;
  }

  getActualContext() {
      return of(this.appContext);
  }
}
