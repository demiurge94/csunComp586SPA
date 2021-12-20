import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { GenreArtist } from '../modals/modal/artist-modal.component';
import { ModalService } from '../modals/modal/modal.service';
@Injectable({
  providedIn: 'root'
})
export class MetalService {

  constructor(private http: HttpClient, private modalServe: ModalService) { 
  }

  getArtistsByGenre(genreId: number): Observable<GenreArtist[]>{
    return this.http.get<GenreArtist[]>(`https://localhost:44358/api/Genres/${genreId}`);
  }
}
