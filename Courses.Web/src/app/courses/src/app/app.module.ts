import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';

import { AppComponent } from './app.component';
import { CourseListComponent } from './course-list/course-list.component';
import { CourseDetailComponent } from './course-detail/course-detail.component';

const routes: Routes = [

  { path: '', component: CourseListComponent },
  { path: ':id', component: CourseDetailComponent }
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
    CourseDetailComponent
  ],
  imports: [
    BrowserModule,
    RouterModule.forRoot(routes)
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
