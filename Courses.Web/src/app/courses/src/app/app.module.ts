import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { RouterModule, Routes } from '@angular/router';
import {
  DxDataGridModule,
  DxBulletModule,
  DxTemplateModule,
  DxListModule,
  DxSelectBoxModule
} from 'devextreme-angular';
import DataSource from 'devextreme/data/data_source';

import { AppComponent } from './app.component';
import { CourseListComponent } from './course-list/course-list.component';
import { CourseDetailComponent } from './course-detail/course-detail.component';
import { HttpClientModule } from '@angular/common/http';
import { CourseEditComponent } from './course-edit/course-edit.component';

const routes: Routes = [

  { path: '', component: CourseListComponent },
  { path: ':id', component: CourseDetailComponent },
  { path: ':id/edit', component: CourseEditComponent }
  // {
  //   path: ':id', component: CourseDetailComponent, resolve: { resolvedData: CourseResolver },
  //   children: [
  //     { path: '', component: CourseInfoComponent },
  //     { path: 'info', component: CourseInfoComponent },
  //     { path: 'programs', component: CourseProgramComponent }
  //   ]
  // },
  // {
  //   path: ':id/edit', component: CourseEditComponent,
  //   children: [
  //     { path: '', component: CourseInfoEditComponent },
  //     { path: 'info', component: CourseInfoEditComponent },
  //     { path: 'programs', component: CourseProgramEditComponent }
  //   ]
  // }
];

@NgModule({
  declarations: [
    AppComponent,
    CourseListComponent,
    CourseDetailComponent,
    CourseEditComponent
  ],
  imports: [
    BrowserModule,
    RouterModule.forRoot(routes),
    FormsModule,
    HttpClientModule,
    DxDataGridModule,
    DxTemplateModule,
    DxBulletModule,
    DxListModule,
    DxSelectBoxModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
