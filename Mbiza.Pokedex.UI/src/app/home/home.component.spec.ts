import { ComponentFixture, TestBed } from '@angular/core/testing';
import { HomeComponent } from './home.component';
import { Router } from '@angular/router';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { ApiService } from '../api.service';
import { Pokemon } from 'src/pokemon';

describe('HomeComponent', () => {
  let component: HomeComponent;
  let fixture: ComponentFixture<HomeComponent>;
  let pokemon: Pokemon;
  let pokemons: Pokemon[] = [
    { id : 1, name : 'one', abilities : 'swim', weight : '400', imageFrontUrl : '', imageBackUrl : '', stats: ''},
    { id : 2, name : 'two', abilities : 'fly', weight : '500', imageFrontUrl : '', imageBackUrl : '', stats: ''},
    { id : 3, name : 'three', abilities : 'walk', weight : '600', imageFrontUrl : '', imageBackUrl : '', stats: ''},
  ];

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [Router, FormBuilder, FormGroup, Validators],
      declarations: [ HomeComponent ],
      providers: [ApiService, Router, FormBuilder]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(HomeComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();

    component.pokemons.push(
      { id : 1, name : 'one', abilities : 'swim', weight : '400', imageFrontUrl : '', imageBackUrl : '', stats: ''},
      { id : 2, name : 'two', abilities : 'fly', weight : '500', imageFrontUrl : '', imageBackUrl : '', stats: ''},
      { id : 3, name : 'three', abilities : 'walk', weight : '600', imageFrontUrl : '', imageBackUrl : '', stats: ''}
    );

    //Assert
    expect(component.pokemons.length).toBe(3);
    expect(component.pokemons).toBe(pokemons);
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });

  it('should set the pokemons when getPokemon method is called', () => {
    pokemon = { id : 1, name : 'one', abilities : 'swim', weight : '400', imageFrontUrl : '', imageBackUrl : '', stats: ''};
    component.pokemon.id = 1;
    component.pokemon.name = 'one';
    component.pokemon.abilities = 'swim';
    component.pokemon.weight = '40';
    component.pokemon.imageBackUrl = '';
    component.pokemon.imageFrontUrl = '';
    component.pokemon.stats = '';
    component.viewDetail(pokemon);
    expect(component.pokemon).toHaveClass;
  });
});
