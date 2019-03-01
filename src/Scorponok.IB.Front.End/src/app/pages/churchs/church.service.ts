
//import { HttpService } from '@services/http.service';
import { HttpServiceClient } from '../../@core/utils/http-client-service';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { Environment as environment  } from '../../../environments/environment';


@Injectable({ providedIn: 'root' })
export class ChurchService {
    constructor(private httpServiceClient: HttpServiceClient) {

    }

    public getChurch(): string // Observable<any>
    {
        return "teste";
    }
}

// {
//     "name": null,
//     "telephoneFixed": null,
//     "email": null,
//     "id": null,
//     "photo": null,
//     "region": 0,
//     "prefix": 0,
//     "mobileTelephone": null
//   }