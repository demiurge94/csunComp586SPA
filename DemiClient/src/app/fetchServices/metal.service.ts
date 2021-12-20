import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { GenreArtist } from '../modals/modal/artist-modal.component';
import { ModalService } from '../modals/modal/modal.service';
import { ArtistDetail } from '../artist-detail-modal/artist-detail-modal.component'
@Injectable({
  providedIn: 'root'
})
export class MetalService {

  constructor(private http: HttpClient, private modalServe: ModalService) { 
  }

  getArtistsByGenre(genreId: number): Observable<GenreArtist[]>{
    return this.http.get<GenreArtist[]>(`https://demiapi20211220010523.azurewebsites.net/api/Genres/${genreId}`);
  }

  getArtistByName(artistName: string) {
    return this.http.get<ArtistDetail[]>(`https://demiapi20211220010523.azurewebsites.net/api/Artists/${artistName}/albums`);
  }
}
