import { Component, OnInit } from "@angular/core";
import { HttpClient } from "@angular/common/http";
import { NgForm } from '@angular/forms';

@Component({
  selector: "app-root",
  templateUrl: "./app.component.html",
  styles: []
})
export class AppComponent implements OnInit {
  title = "clusters";
  clusters: any[];
  cluster: any;
  selectedCluster: any;
  clusterTypes: any[];
  schoolYears: { id: number; year: number; }[];

  constructor(private http: HttpClient) { }

  ngOnInit() {
    console.log("init");
    this.http.get<any[]>('api/ref/clustertypes').subscribe(data => {
      this.clusterTypes = data;
    })

    this.http.get<any[]>('api/ref/schoolyears').subscribe(data => {
      this.schoolYears = data;
    })
    this.http.get<any[]>("api/ref/clusters").subscribe(r => {
      this.clusters = r;
    });
  }

  onSelectionChanged(item) {
    if (item === null) {
      this.cluster = null;
    } else {
      this.http
        .get(`api/careertech/clusters/${item.clusterCode}/edit`)
        .subscribe(data => {
          this.cluster = data;
        });
    }
  }
}
