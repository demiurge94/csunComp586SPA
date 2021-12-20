import { Component, OnInit } from '@angular/core';
import { ModalService } from '../modals/modal/modal.service';
import { MetalService } from 'src/app/fetchServices/metal.service';
import { HttpClient } from '@angular/common/http';
import { MdbModalRef } from 'mdb-angular-ui-kit/modal';
@Component({
  selector: 'app-artist-detail-modal',
  templateUrl: './artist-detail-modal.component.html',
  styleUrls: ['./artist-detail-modal.component.css']
})
export class ArtistDetailModalComponent implements OnInit {
  title!: string;
  artistName!: string;
  artistDetail: ArtistDetail[] = []; 
  constructor(public modalRef: MdbModalRef<ArtistDetailModalComponent> 
    , http: HttpClient, private modalService: ModalService, metalServ: MetalService) { 
      this.title = this.modalService.getArtistData();
      this.artistName = this.modalService.getArtistData(); 

      metalServ.getArtistByName(this.artistName).subscribe(
        a => {this.artistDetail = a});
      
    }

  ngOnInit(): void {
  }

}
export interface albums{
  albumVmId: number;
  albumName: string;
  albumArtist: string;
}
export interface ArtistDetail{
  artistId: number;
  artistName: string;
  artistBio: string;
  albums: albums[]; 
  genre: string; 
}