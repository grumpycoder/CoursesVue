import { Component, OnInit } from '@angular/core';
import * as AspNetData from "devextreme-aspnet-data-nojquery";

@Component({
  selector: 'app-course-list',
  templateUrl: './course-list.component.html',
  styleUrls: ['./course-list.component.scss']
})
export class CourseListComponent implements OnInit {
  title: string = 'Courses';
  courses: any;
  currentFilter: any;

  constructor() { }

  ngOnInit() {
    this.courses = this.GetCourseData();
  }

  GetCourseData(): any[] {
    let data: any = AspNetData.createStore({
      key: "id",
      loadUrl: 'api/courses'
    });
    return data;
  }

}
