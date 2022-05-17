import { ComponentFixture, TestBed } from '@angular/core/testing';
import { Pokemon } from 'src/pokemon';
import { PokemonDetailComponent } from './pokemon-detail.component';
import { ActivatedRoute, Router } from '@angular/router';
import { ApiService } from '../api.service';

describe('PokemonDetailComponent', () => {
  let component: PokemonDetailComponent;
  let fixture: ComponentFixture<PokemonDetailComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [ActivatedRoute],
      declarations: [ PokemonDetailComponent ],
      providers: [ApiService, Router]
    })
    .compileComponents();
  });

  beforeEach(() => {
    //Arrange
    const pokemon: Pokemon = { id : 1, name : 'one', abilities : 'swim', weight : '400', imageFrontUrl : '', imageBackUrl : '', stats: ''};

    fixture = TestBed.createComponent(PokemonDetailComponent);
    component = fixture.componentInstance;
    component.pokemon = pokemon;

    //Act
    fixture.detectChanges();

    //Assert
    expect(component.pokemon).toBe(pokemon);
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
