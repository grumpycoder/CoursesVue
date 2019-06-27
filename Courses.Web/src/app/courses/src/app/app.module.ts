import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';

import { AppComponent } from './app.component';

const routes: Routes = [

  // { path: '', component: CourseListComponent },
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
    AppComponent
  ],
  imports: [
    BrowserModule,
    RouterModule.forChild(routes),
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
