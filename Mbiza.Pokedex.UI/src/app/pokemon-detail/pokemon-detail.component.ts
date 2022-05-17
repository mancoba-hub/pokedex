import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { Pokemon } from 'src/pokemon';
import { ApiService } from '../api.service';

@Component({
  selector: 'app-pokemon-detail',
  templateUrl: './pokemon-detail.component.html',
  styleUrls: ['./pokemon-detail.component.css']
})
export class PokemonDetailComponent implements OnInit {
  id: number = 0;
  name: string = '';
  imageFrontUrl: string = '';
  imageBackUrl: string = '';
  weight: string = '';
  stats: string = '';
  abilities: string = '';
  pokemon: Pokemon;

  constructor(private route: ActivatedRoute, 
              private apiService: ApiService,
              private router: Router) {
    this.pokemon = new Pokemon();
   }

  ngOnInit(): void {
    this.route.paramMap.subscribe(params => {
      this.name = String(params.get('name'));     
    });
    // this.pokemon = {id: this.id, name : this.name, imageFrontUrl: this.imageFrontUrl, imageBackUrl: this.imageBackUrl, abilities: this.abilities, weight: this.weight, stats: this.stats};
    this.apiService.getPokemon(this.name).subscribe(pokemon => {
      this.pokemon = pokemon;
    });
  }

  back() {
    this.router.navigate(['/']);
  }
}
