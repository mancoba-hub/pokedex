import { TestBed } from '@angular/core/testing';
import { Pokemon } from 'src/pokemon';

import { ApiService } from './api.service';
import { HttpClient, HttpHandler } from '@angular/common/http';
import { Observable } from 'rxjs';

describe('ApiService', () => {
  let service: ApiService;
  let pokemons: Pokemon[];
  
  beforeEach(() => { TestBed.configureTestingModule({
      providers: [ApiService, HttpClient, HttpHandler]
      });
    service = TestBed.inject(ApiService);
  });

  // it('should be created', () => {
  //   expect(service).toBeTruthy();
  // });

  it('should invoke http method and return data when getPokemons method is called', () => {
    //Arrange
    const pokemonList: Pokemon[] = [
      { id : 1, name : 'one', abilities : 'swim', weight : '400', imageFrontUrl : '', imageBackUrl : ''},
      { id : 2, name : 'two', abilities : 'fly', weight : '500', imageFrontUrl : '', imageBackUrl : ''},
      { id : 3, name : 'three', abilities : 'walk', weight : '600', imageFrontUrl : '', imageBackUrl : ''},
    ];

    const httpService = TestBed.get(HttpClient);
    
    spyOn(httpService, "getPokemons").and.returnValue(pokemonList);

    //Act
    const result = service.getPokemons();

    //Assert
    expect(httpService.get).toHaveBeenCalled();
    expect(result).not.toBeNull();
  });

  it('should invoke http method and return data when searchPokemons method is called', () => {
    //Arrange
    const name = 'two'
    const pokemonList: Pokemon[] = [
      { id : 2, name : 'two', abilities : 'fly', weight : '500', imageFrontUrl : '', imageBackUrl : ''},
    ];
    const httpService = TestBed.get(HttpClient);
    
    spyOn(httpService, "searchPokemons").and.returnValue(pokemonList);

    //Act
    const result = service.searchPokemons(name);

    //Assert
    expect(httpService.get).toHaveBeenCalled();
    expect(result).not.toBeNull();
  });

  it('should invoke http method and return data when getPokemon method is called', () => {
    //Arrange
    const name = 'one'
    const pokemon: Pokemon = { id : 1, name : 'one', abilities : 'swim', weight : '400', imageFrontUrl : '', imageBackUrl : ''};
    const httpService = TestBed.get(HttpClient);
    
    spyOn(httpService, "getPokemon").and.returnValue(pokemon);

    //Act
    const result = service.getPokemon(name);

    //Assert
    expect(httpService.get).toHaveBeenCalled();
    expect(result).not.toBeNull();
  });
});
