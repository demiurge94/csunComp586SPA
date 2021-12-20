import { HttpClient } from '@angular/common/http';
import { Component } from '@angular/core';
import { MdbModalRef } from 'mdb-angular-ui-kit/modal';
import { Observable, Subscription } from 'rxjs';
import { NgbDatepickerKeyboardService } from '@ng-bootstrap/ng-bootstrap';
import { ModalService } from './modal.service';
import { MetalService } from 'src/app/fetchServices/metal.service';
import { tap } from 'rxjs/operators';
import { observable } from 'rxjs';
import { map } from 'rxjs/operators';
@Component({
  selector: 'app-artist-modal',
  templateUrl: './artist-modal.component.html',
})
export class ArtistModalComponent {
  title!: string;
  genreId = 0;
  artistsByGenre: GenreArtist[] = [];
  test : any ;
  constructor(public modalRef: MdbModalRef<ArtistModalComponent>, http: HttpClient, private modalService: ModalService
    , metalServ: MetalService) {
    this.genreId = this.modalService.getData();
    this.title = this.modalService.getTitle();
    

    

    /*metalServ.getArtistsByGenre().subscribe( g => {
      this.artistsByGenre = g; this.artistsByGenre.forEach(g => {this.artistsByGenre[0].genreId = g.genreId; 
      this.artistsByGenre[0].genreName = g.genreName; this.artistsByGenre[0].artists = g.artists});
    }); */
    metalServ.getArtistsByGenre(this.genreId).subscribe(g => {this.artistsByGenre = g});
  }
}
export interface artist{
  artistId: number;
  artistName: string;
}
export interface GenreArtist{
  genreId: number;
  genreName: string;
  artists: artist[];
}


