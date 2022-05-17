import { Component, OnInit } from '@angular/core';
import { ApiService } from '../api.service';
import { Subscription } from 'rxjs';
import { Pokemon } from 'src/pokemon';
import { Observable } from 'rxjs';
import { Router } from '@angular/router';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.css']
})
export class HomeComponent implements OnInit {
  pokemons = new Array<Pokemon>();
  searchName: string = '';
  searchForm: FormGroup;
  pokemon: Pokemon = new Pokemon();
 
  constructor(private apiService: ApiService, 
              private router: Router,
              private fb: FormBuilder) { 
                this.searchForm = this.fb.group({
                  name: fb.control('bulbasaur', Validators.required)
                });
              }

  ngOnInit(): void {
    this.apiService.getPokemons().subscribe(response => {
      this.pokemons = response;
    });
    this.createForm(this.pokemon);
  }

  viewDetail(pokemon: Pokemon) {
    // var pokedetail = {
    //             'id': pokemon.id,
    //             'name': pokemon.name, 
    //             'imageFrontUrl': pokemon.imageFrontUrl, 
    //             'imageBackUrl': pokemon.imageBackUrl,
    //             'abilities': pokemon.abilities,
    //             'weight': pokemon.weight,
    //             'stats': pokemon.stats
    //           }
    this.router.navigate(['detail/', {'name': pokemon.name }]);
  }

  searchPokemon() {      
    var searchText = this.searchForm.controls['name'].value  
    this.apiService.searchPokemons(searchText).subscribe(response => {
      this.pokemons = response;
    });
  }

  listPokemon() {      
    this.apiService.getPokemons().subscribe(response => {
      this.pokemons = response;
    });
  }

  createForm(pokemon: Pokemon): void {
    this.searchForm = this.fb.group({
      name: pokemon.name
    });
  } 
}

