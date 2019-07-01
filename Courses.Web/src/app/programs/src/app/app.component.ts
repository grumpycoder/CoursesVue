import { Component, OnInit } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import * as AspNetData from 'devextreme-aspnet-data-nojquery';
import DataSource from 'devextreme/data/data_source';
import ArrayStore from "devextreme/data/array_store";

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styles: [`
    em {float:right; color:#E05C65; padding-left:10px;}
    .error input, .error select, .error textarea {background-color:#E3C3C5;}
    .error ::-webkit-input-placeholder { color: #999; }
    .error :-moz-placeholder { color: #999; }
    .error ::-moz-placeholder {color: #999; }
    .error :ms-input-placeholder { color: #999; }
  `]
})
export class AppComponent implements OnInit {

  title = 'Career Tech Programs';
  programs: any;
  program: any;
  schoolYears: any;
  programTypes: any;
  clusters: any;
  cachedProgram: any;
  programCreds: any;
  courses: any;
  programCourses: any;
  credentials: any;
  selectedCredential: any;
  courseData: any;
  dataSource: any;

  constructor(private http: HttpClient) {

  }

  ngOnInit() {
    this.http.get("api/ref/programs").subscribe(data => {
      this.programs = data;
    });
    this.http.get('api/ref/programtypes').subscribe(data => {
      this.programTypes = data;
    });
    this.http.get('api/ref/schoolyears').subscribe(data => {
      this.schoolYears = data;
    });

    this.http.get("api/ref/clusters").subscribe(data => {
      this.clusters = data;
    });

    this.http.get("api/ref/credentials").subscribe(data => {
      this.credentials = data;
    });

    this.courses = new DataSource({
      store: AspNetData.createStore({
        loadUrl: "/api/courses"
      }),
      paginate: true,
      pageSize: 1,
    });

  }

  onSelectionChanged(item) {

    this.http.get(`api/careertech/programs/${item.programCode}/edit`).subscribe(data => {
      this.program = data;
      this.cachedProgram = Object.assign({}, this.program);

      this.http.get(`api/careertech/programs/${item.programCode}/credentials`).subscribe(data => {
        this.programCreds = data;
      })

      this.http.get(`api/careertech/programs/${item.programCode}/courses`).subscribe(data => {
        this.programCourses = data;
      })
    })

  }

  onSubmit(form) {
    if (this.program.id == null) {
      this.http.post('api/careertech/programs', this.program).subscribe(data => {
        this.program = data;
        this.cachedProgram = data;
      })
    } else {
      this.http.put('api/careertech/programs', this.program).subscribe(data => {
        this.cachedProgram = data;
      })
    }
  }

  cancel(form) {
    form.reset(this.cachedProgram);
    this.program = Object.assign({}, this.cachedProgram)
  }

  create() {
    this.program = {
      id: null
    };
  }

  addCred(list) {
    var url = `api/careertech/programs/${this.program.programCode}/credential/${list.selectedItem.credentialCode}`;

    this.http.post(url, null).subscribe(data => {
      this.programCreds.push(data)
    })
  }

  removeCred(item) {
    var url = `api/careertech/programs/${this.program.programCode}/credential/${item.itemData.credentialCode}`;

    this.http.delete(url).subscribe(data => {
    })

  }

  addCourse(list) {
    var url = `api/careertech/programs/${this.program.programCode}/course/${list.selectedItem.courseCode}`;
    this.http.post(url, null).subscribe(data => {
      this.programCourses.push(data)
    })
  }

  removeCourse(item) {
    var url = `api/careertech/programs/${this.program.programCode}/course/${item.itemData.courseCode}`;

    this.http.delete(url).subscribe(data => {
    })

  }
}
