import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { HttpClient } from '@angular/common/http';
import DataSource from 'devextreme/data/data_source';
import ArrayStore from 'devextreme/data/array_store';

@Component({
  selector: 'app-course-edit',
  templateUrl: './course-edit.component.html',
  styleUrls: ['./course-edit.component.scss']
})
export class CourseEditComponent implements OnInit {
  title: string;
  course: any;
  cachedCourse: any;
  schoolYears: any;
  grades: any;
  courseTypes: any;
  classTypes: any;
  creditTypes: any;
  subjectAreas: any;
  assignedPrograms: any;
  //programList: DataSource;
  programList: ArrayStore;

  constructor(private route: ActivatedRoute, private http: HttpClient) { }

  ngOnInit() {

    this.schoolYears = this.http.get('api/ref/schoolyears');
    this.grades = this.http.get('api/ref/grades');
    this.courseTypes = this.http.get('api/ref/coursetypes');
    this.classTypes = this.http.get('api/ref/classtypes');
    this.creditTypes = this.http.get('api/ref/credittypes');
    this.subjectAreas = this.http.get('api/ref/subjectareas');

    this.http.get("api/ref/programs").subscribe(data => {
      this.programList = new DataSource({
        store: new ArrayStore({
          data: data,
          key: 'id'
        }), group: 'clusterName'
      });
    });

    this.route.params.subscribe(params => {
      const id = params['id'];

      this.http.get<any>(`api/courses/${id}/edit`).subscribe(data => {
        this.course = data;
        this.cachedCourse = Object.assign({}, this.course)
        this.title = `${this.course.name} (${this.course.courseCode})`


        this.http.get<any>(`api/careertech/courses/${this.course.courseCode}/programs`).subscribe(data => {
          this.assignedPrograms = new DataSource({
            reshapeOnPush: true,
            store: new ArrayStore({
              data: data,

              key: 'id'
            }), group: 'clusterName'
          });

        })
      })
    })
  }

  onSubmit(form) {
    this.http.put('/api/courses/', this.course).subscribe(data => {
      this.cachedCourse = Object.assign({}, this.course)
      form.reset(this.course);
    })
  }

  cancel(form) {
    form.reset(this.cachedCourse);
    this.course = Object.assign({}, this.cachedCourse)
  }

  addProgram(list) {
    console.log('list', list);
    //this.programList.reload();
    // let item = {
    //   beginYear: 2017,
    //   clusterCode: "001",
    //   clusterId: 1,
    //   clusterName: "Agriculture, Food & Natural Resources",
    //   endYear: 2018,
    //   isNonTraditionalForFemales: false,
    //   isNonTraditionalForMales: false,
    //   programCode: "001",
    //   programId: 1,
    //   programName: "7th/8th Grade Agriscience",
    // }
    this.programList.store().push(list.selectedItem);
    this.programList.reload();

    // var url = `api/careertech/programs/${list.selectedItem.programCode}/course/${this.course.courseCode}`;
    // this.http.post(url, null).subscribe(data => {
    //   this.programList.store().push(data['programDto'])
    // })
  }
}
