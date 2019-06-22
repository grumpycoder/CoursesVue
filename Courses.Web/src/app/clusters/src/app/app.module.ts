import { BrowserModule } from "@angular/platform-browser";
import { NgModule } from "@angular/core";
import { HttpClientModule } from "@angular/common/http";
import {
  DxSelectBoxModule,
  DxListModule,
  DxTextBoxModule,
  DxTemplateModule
} from "devextreme-angular";
import { AppComponent } from "./app.component";

@NgModule({
  declarations: [AppComponent],
  imports: [
    BrowserModule,
    HttpClientModule,
    DxSelectBoxModule,
    DxListModule,
    DxTextBoxModule,
    DxTemplateModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule {}
