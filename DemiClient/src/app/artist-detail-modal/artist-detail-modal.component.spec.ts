import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ArtistDetailModalComponent } from './artist-detail-modal.component';

describe('ArtistDetailModalComponent', () => {
  let component: ArtistDetailModalComponent;
  let fixture: ComponentFixture<ArtistDetailModalComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ ArtistDetailModalComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(ArtistDetailModalComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
