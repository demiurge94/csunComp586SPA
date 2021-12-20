import { HttpClient } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';
import { MdbModalRef, MdbModalService } from 'mdb-angular-ui-kit/modal';
import { ModalService } from 'src/app/modals/modal/modal.service';
import { ArtistDetailModalComponent } from 'src/app/artist-detail-modal/artist-detail-modal.component';
@Component({
  selector: 'app-artist-view',
  templateUrl: './artist-view.component.html',
  styleUrls: ['./artist-view.component.css']
})
export class ArtistViewComponent implements OnInit {
  listOfArtists: artist[] = []; 
  modalRef!: MdbModalRef<ArtistDetailModalComponent>;

  constructor(http: HttpClient, private modalService: MdbModalService, private modalServ: ModalService) { 
    http.get<artist[]>("https://demiapi20211220010523.azurewebsites.net/api/Artists").subscribe(
      a => {
        this.listOfArtists = a;
      }, error => console.error(error)
    );
    let token = localStorage.getItem("jwt"); 
  }

  ngOnInit(): void {
  }
  openModal(genre: string){
    this.modalServ.setArtistData(genre); 
    this.modalRef = this.modalService.open(ArtistDetailModalComponent,{data: {},
    modalClass: 'modal-fullscreen'});

  }
}
interface artist{
  artistId: number;
  artistName: string;
  artistBio: string;
  genre: string;
}