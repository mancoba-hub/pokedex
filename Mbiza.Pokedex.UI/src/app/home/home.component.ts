import { Component, OnInit } from '@angular/core';
import { ApiService } from '../api.service';
import { Subscription } from 'rxjs';
import { Pokemon } from 'src/pokemon';
import { Observable } from 'rxjs';
import { Router } from '@angular/router';
import { FormGroup } from '@angular/forms';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.css']
})
export class HomeComponent implements OnInit {
  pokemons = new Array<Pokemon>();
  searchName: string = '';
  
 
  constructor(private apiService: ApiService, private router: Router) { }

  ngOnInit(): void {
    this.apiService.getPokemons().subscribe(response => {
      this.pokemons = response;
    })
  }

  viewDetail(name: string) {
    this.router.navigate(['detail/', {name: name }]);
  }

  searchPokemon(searchName: string) {        
    this.apiService.searchPokemons(searchName).subscribe(response => {
      this.pokemons = response;
    })
  }
}

