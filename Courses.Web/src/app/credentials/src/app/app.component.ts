import { Component, OnInit } from '@angular/core';
import { HttpClient } from '@angular/common/http';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styles: []
})
export class AppComponent implements OnInit {
  title = 'Career Tech Credentials';
  credentials: any;
  credential: any;
  selectedCredential: any;
  cacheCredential: any;
  credentialTypes: any;
  schoolYears: any;
  isNew: boolean;

  constructor(private http: HttpClient) {

  }
  ngOnInit(): void {
    this.http.get<any>('api/ref/credentials').subscribe(data => {
      this.credentials = data;
    })

    this.schoolYears = this.http.get('api/ref/schoolyears');

    this.http.get<any>('api/ref/credentialtypes').subscribe(data => {
      this.credentialTypes = data;
    })
  }

  onSelectionChanged(item) {
    if (item === null) {
      this.credential = null;
    } else {
      this.http
        .get(`api/careertech/credentials/${item.credentialCode}/edit`)
        .subscribe(data => {
          this.credential = data;
          this.cacheCredential = Object.assign({}, this.credential);
          // this.http.get(`api/careertech/clusters/${this.credential.credentialCode}/programs`).subscribe(data => {
          //   this.programs = data;
          // });
        });

    }
  }

  onSubmit(formValues) {

    if (this.credential.id == null) {
      this.http.post('api/careertech/credentials', this.credential).subscribe(resp => {
        this.credentials.push(resp);
        this.credential = resp;
        this.cacheCredential = Object.assign({}, this.credential);
        this.selectedCredential = resp;
      })
    } else {
      this.http.put('api/careertech/credentials', this.credential).subscribe(resp => {
        this.cacheCredential = Object.assign({}, this.credential);
      })
    }
  }

  cancel(form) {
    form.reset(this.cacheCredential);
    this.credential = Object.assign({}, this.cacheCredential)
  }

  create() {
    let credential = {
      "id": null,
      "credentialCode": null,
      "name": null,
      "credentialTypeId": null,
      "beginYear": null,
      "endYear": null
    };

    this.credential = Object.assign({}, credential);
    // this.selectedCredential = {};
    // this.isNew = true;
  }

}
