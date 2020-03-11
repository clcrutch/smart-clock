import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { ReplaySubject, Observable } from 'rxjs';

interface InfoModel {
  version: string;
}

@Injectable({
  providedIn: 'root'
})
export class InfoService {

  private infoSubject: ReplaySubject<InfoModel> = new ReplaySubject();
  private infoObservable: Observable<InfoModel>;

  constructor(httpClient: HttpClient) {
    this.infoObservable = this.infoSubject.asObservable();

    httpClient.get('/api/info').subscribe(x => this.infoSubject.next(x as InfoModel));
  }

  public getVersion(): Observable<InfoModel> {
    return this.infoObservable;
  }
}
