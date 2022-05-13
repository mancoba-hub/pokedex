import { Component, Inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';

@Component({
    selector: 'app-home',
    templateUrl: './home.component.html',
})
export class HomeComponent {
    Pokemons: ModelPokemon[] = [];

    constructor(http: HttpClient, @Inject('BASE_URL') baseUrl: string) {
        http.get<ModelPokemon[]>(baseUrl).subscribe(results => {
            this.Pokemons = results;
        }, error => console.error(error));
    }
}

interface ModelPokemon {
    id: number;
    name: string;
    habitat: string;
    color: string;
    isBaby: boolean;
    isLegendary: boolean;
    isMythical: boolean;
}