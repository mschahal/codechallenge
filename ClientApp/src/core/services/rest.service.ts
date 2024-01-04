import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable, throwError } from 'rxjs';
import { catchError } from 'rxjs/operators';
import { environment } from '../../environment/environment';

@Injectable({
  providedIn: 'root',
})
export class RestService {
  baseUrl = '';

  constructor(
    private http: HttpClient
  ) {
    this.baseUrl = `${environment.apiBaseUrl}/`;
  }

  public get<T>(
    relativeUrl: string,
    params: { [param: string]: string | string[] } = {}
  ): Observable<T> {
    return this.http.get<T>(`${this.baseUrl}${relativeUrl}`, { params });
  }

  public post<T>(relativeUrl: string, data: any = null): Observable<T> {
    return this.http
      .post<T>(`${this.baseUrl}${relativeUrl}`, data)
      .pipe(catchError(this.handleError<T>('error')));
  }

  public put<T>(relativeUrl: string, data: any = null): Observable<T> {
    return this.http
      .put<T>(`${this.baseUrl}${relativeUrl}`, data)
      .pipe(catchError(this.handleError<T>('error')));
  }

  public delete<T>(relativeUrl: string): Observable<T> {
    return this.http
      .delete<T>(`${this.baseUrl}${relativeUrl}`)
      .pipe(catchError(this.handleError<T>('error')));
  }

  protected handleError<T>(operation = 'operation', result?: T) {
    return (error: { error: any }): Observable<T> => {
      const resp = result || error.error || error;
      return throwError(resp as T);
    };
  }
}
