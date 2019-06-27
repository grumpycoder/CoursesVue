import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { HttpClient } from '@angular/common/http';
import DataSource from 'devextreme/data/data_source';
import ArrayStore from 'devextreme/data/array_store';
import * as AspNetData from 'devextreme-aspnet-data-nojquery';

@Component({
  selector: 'app-course-detail',
  templateUrl: './course-detail.component.html',
  styleUrls: ['./course-detail.component.scss']
})
export class CourseDetailComponent implements OnInit {
  title: string;
  course: any;
  listData: any;
  programs: any[];

  constructor(private route: ActivatedRoute, private http: HttpClient) { }

  ngOnInit() {
    this.route.params.subscribe(params => {
      const id = params['id'];

      this.http.get<any>(`api/courses/${id}/full`).subscribe(data => {
        this.course = data;
        this.title = `${this.course.name} (${this.course.courseCode})`

        this.programs = data.programs;
        this.listData = new DataSource({
          store: new ArrayStore({
            data: this.programs,
            key: 'clusterId'
          }), group: 'clusterName'
        });

      })
    })
  }

}
