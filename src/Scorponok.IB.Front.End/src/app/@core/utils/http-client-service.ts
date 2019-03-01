import { Injectable, Injector } from '@angular/core';
import { map } from 'rxjs/operators';
import { Observable } from 'rxjs';
import { Environment as environment  } from '../../../environments/environment';
import { HttpClientModule } from '@angular/common/http'; 
import { HttpModule } from '@angular/http';

class Data {
    success: boolean;
    data?: any;
    errors?: string[];
}

@Injectable({ providedIn: 'root' })
export class HttpServiceClient {
    private http = this.injector.get(HttpServiceClient);

    constructor(private injector: Injector) {

    }

    // public handleResponse(response: Data | any) {
    //     return (response.success) ? response.data : null;
    // }

    // public get(url: string, body?): Observable<any> {
    //     return this.http.get(this.environment.baseBackEndUri + url)
    //         .pipe(map((response: Response) => this.handleResponse(response)));
    // }

    // public post(url: string, body): Observable<any> {
    //     return this.http.post(this.environment.baseBackEndUri + url, body)
    //         .pipe(map((response: Response) => this.handleResponse(response)));
    // }

    // public put(url: string, body): Observable<any> {
    //     return this.http.put(this.environment.baseBackEndUri + url, body)
    //         .pipe(map(response => this.handleResponse(response)));
    // }

    // public delete(url: string): Observable<any> {
    //     return this.http.delete(this.environment.baseBackEndUri + url)
    //         .pipe(map(response => this.handleResponse(response)));
    // }
}