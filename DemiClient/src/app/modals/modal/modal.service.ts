import { Injectable, Input } from '@angular/core';
import { FetchDataComponent } from 'src/app/fetch-data/fetch-data.component';
@Injectable({
  providedIn: 'root'
})
export class ModalService {
  private data!: number;
  private titl!: string;
  constructor() { }
  setData(data:number, title: string){
    this.data = data; 
    this.titl = title;
  }
  getData(){
    let temp = this.data;
    console.log(temp);
    return temp;
  }
  getTitle(){
    let temp = this.titl;
    console.log("title: " + temp);
    return temp;
  }
  clearData(){
    this.data = 0;
  }
}
