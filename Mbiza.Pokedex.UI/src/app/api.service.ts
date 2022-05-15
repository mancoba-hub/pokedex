import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { environment } from './../environments/environment';
import { Observable } from 'rxjs';
import { Pokemon } from 'src/pokemon';

@Injectable({
  providedIn: 'root'
})

export class ApiService {

  private SERVER_URL = environment.apiSecure;

  constructor(private httpClient: HttpClient) { 
  }

  public getPokemons(): Observable<Pokemon[]> {
    return this.httpClient.get<Pokemon[]>(this.SERVER_URL + "pokedex");
  }

  public searchPokemons(name: string): Observable<Pokemon[]> {
    return this.httpClient.get<Pokemon[]>(this.SERVER_URL + "search/" + name);
  }

  public getPokemon(name: string): Observable<Pokemon> {
    return this.httpClient.get<Pokemon>(this.SERVER_URL + "pokedex/"+ name);
  }
}
