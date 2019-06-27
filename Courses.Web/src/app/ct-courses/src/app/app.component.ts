import { Component, OnInit } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import * as AspNetData from 'devextreme-aspnet-data-nojquery';
import DataSource from 'devextreme/data/data_source';
import ArrayStore from "devextreme/data/array_store";

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styles: []
})
export class AppComponent implements OnInit {
  title = 'Career Tech Courses';
  courses: any;
  programCourses: any;
  programs: any;
  course: any;

  constructor(private http: HttpClient) {

  }

  ngOnInit(): void {

    this.http.get("api/ref/programs").subscribe(data => {
      this.programs = data;
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
    this.http.get<any>(`api/careertech/courses/${item.courseCode}/programs`).subscribe(data => {
      this.programCourses = data;
      this.course = item;
    })
  }

  addProgram(list) {
    console.log('list', list);
    var url = `api/careertech/programs/${list.selectedItem.programCode}/course/${this.course.courseCode}`;
    this.http.post(url, null).subscribe(data => {
      this.programCourses.push(data['programDto'])
    })
  }

  removeProgram(item) {
    console.log('item', item);

    var url = `api/careertech/programs/${item.itemData.programCode}/course/${this.course.courseCode}`;
    this.http.delete(url).subscribe(data => {
    })
  }

}
