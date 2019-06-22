import { Component, OnInit } from "@angular/core";
import { HttpClient } from "@angular/common/http";
import ArrayStore from "devextreme/data/array_store";
import DataSource from "devextreme/data/data_source";

@Component({
  selector: "app-root",
  templateUrl: "./app.component.html",
  styles: []
})
export class AppComponent implements OnInit {
  title = "clusters";
  // data: DataSource;
  clusters: any;
  cluster: any;
  selectedCluster: any;

  constructor(private http: HttpClient) {}

  ngOnInit() {
    console.log("init");
    this.http.get("api/ref/clusters").subscribe(r => {
      this.clusters = r;
    });
  }

  onSelectionChanged(item) {
    if (item === null) {
      this.cluster = null;
    } else {
      this.http
        .get(`/api/careertech/clusters/${item.clusterCode}/edit`)
        .subscribe(data => {
          console.log("data", data);
          this.cluster = data;
        });
      // this.careerTech.ClusterEdit(cluster).subscribe(data => {
      //   this.cluster = data;
      // });
    }
  }
}
