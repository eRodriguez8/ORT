import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders, HttpErrorResponse } from '@angular/common/http';
import { Observable, of } from 'rxjs';
import { catchError, map, tap } from 'rxjs/operators';
import { environment } from '../../environments/environment';
import { NgbModal } from '@ng-bootstrap/ng-bootstrap';
import { HandleErrorComponent } from '../handle-error/handle-error.component';


@Injectable()
export class HttpManagerService {

    public url: string;
    public urlExt: string;

    constructor(private http: HttpClient,
        private modalService: NgbModal) {
        this.url = `${environment.server}${environment.prefix}${environment.version}`;
        this.urlExt = `${environment.server}`;
    }

    public get<T>(route: string): Observable<T> {
        return this.http.get<T>(this.url + route, { withCredentials: true})
            .pipe(
                catchError(this.handleError<T>())
            );
    }

    public getWithoutNotification<T>(route: string): Observable<T> {
      return this.http.get<T>(this.url + route, { withCredentials: true })
          .pipe( );
    }

    public post<T>(route: string, objeto: any): Observable<T> {
          return this.http.post<T>(this.url + route, objeto, { withCredentials: true})
          .pipe(
              catchError(this.handleError<T>())
          );
    }

    public getExt<T>(route: string): Observable<T> {
      return this.http.get<T>(this.url + route, { withCredentials: true })
          .pipe(
              catchError(this.handleError<T>())
          );
    }

    public getUrl(route: string): string {
        return this.url + route;
    }

    public delete<T>(route: string, legajo: string):  Observable<T> {
      return this.http.delete<T>(this.url + route + legajo, { withCredentials: true })
      .pipe(
          catchError(this.handleError<T>())
      );
    }

    public put<T>(route: string, objeto: any): Observable<T> {
      return this.http.put<T>(this.url + route, objeto, { withCredentials: true})
      .pipe(
          catchError(this.handleError<T>())
      );
}

    private handleError<T>(result?: T) {
        return (error: any): Observable<T> => {
            console.error(error);

            if (error.status === 400) {
                console.log('Not Found!!');
                this.ShowNotification('Error', 'Ups algo salió mal, revisar la información enviada y reintentar. En caso ' +
                    'de persitir el error contacte el administrador', error.message, error.status, null);
            } else if (error.status === 409) {
              this.ShowNotification('Legajo existente', 'El legajo ya se encuentra activo',
                error.message, error.status, null);
              console.log('Legajo existente');
            } else if (error.status === 401) {
                this.ShowNotification('No autorizado', 'Usted no tiene permisos para realizar la operación solicitada',
                  error.message, error.status, null);
                console.log('Unauthorized');
            } else if (error.status === 404) {
                  console.log('Not Found!!');
                  this.ShowNotification('No encontrado', 'No se encontro el servicio solicitado', error.message, error.status, null);
            } else if (error.status === 403) {
              console.log('Not Found!!');
              this.ShowNotification('No autorizado', 'No tiene permisos', error.message, error.status, 'assets/images/permisos.gif');
            }  else if (error.status === 500) {
                this.ShowNotification(error.statusText,
                  'Ocurrió un error al conectarse al servidor, vuelva a intentar.', error.error.exceptionMessage, error.status, null);
            } else {
                // this.ShowNotification(error.statusText, error.name, error.message, error.status);
            }

            return of(result as T);
        };
    }

    public ShowNotification(title, message, exceptionMessage, statusCode, imagen) {
        const error_design = statusCode === 404 ? 'modal-404' : statusCode === 401 ? 'modal-401' : 'modal-500';

          const modalRef = this.modalService.open(HandleErrorComponent, {
              windowClass: 'animated bounce modal-500',
              keyboard: false,
              backdrop: 'static'
            });
          modalRef.componentInstance.title = title;
          modalRef.componentInstance.message = message;
          modalRef.componentInstance.exceptionMessage = exceptionMessage;
          modalRef.componentInstance.statusCode = statusCode;
          modalRef.componentInstance.imagen = imagen;
          modalRef.result.then((data) => {
           console.log(data);
          });

      }
}
