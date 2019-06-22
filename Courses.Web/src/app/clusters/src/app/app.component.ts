import { Component, OnInit } from "@angular/core";
import { HttpClient } from "@angular/common/http";
import { NgForm } from '@angular/forms';

@Component({
  selector: "app-root",
  templateUrl: "./app.component.html",
  styles: []
})
export class AppComponent implements OnInit {
  title = "Career Tech Clusters";
  clusters: any;
  cluster: any;
  cacheCluster: any;
  programs: any;
  selectedCluster: any;
  clusterTypes: any;
  schoolYears: any;

  constructor(private http: HttpClient) { }

  ngOnInit() {
    console.log("init");

    this.clusterTypes = this.http.get('api/ref/clustertypes');
    this.schoolYears = this.http.get('api/ref/schoolyears');
    this.http.get("api/ref/clusters").subscribe(data => {
      this.clusters = data;
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
          this.cacheCluster = Object.assign({}, this.cluster);
          this.http.get(`api/careertech/clusters/${this.cluster.clusterCode}/programs`).subscribe(data => {
            this.programs = data;
          });
        });

    }
  }

  onSubmit(formValues) {

    if (this.cluster.id == null) {
      this.http.post('api/careertech/clusters', this.cluster).subscribe(resp => {
        this.clusters.push(resp);
        this.cluster = resp;
        this.cacheCluster = Object.assign({}, this.cluster);
      })
    } else {
      this.http.put('api/careertech/clusters', this.cluster).subscribe(resp => {
        this.cacheCluster = Object.assign({}, this.cluster);
      })
    }
  }

  cancel(form) {
    form.reset(this.cacheCluster);
    this.cluster = Object.assign({}, this.cacheCluster)
  }

  create() {
    this.cluster = {
      id: null
    };
  }
}
