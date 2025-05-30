using NUnit.Framework;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using UnityEngine;

public class PokemonParty : MonoBehaviour
{

 
    
    [SerializeField] List<Pokemon> pokemons;

    public List<Pokemon> Pokemons
    { get { return pokemons; } }


    private void Start()
    {
        foreach (var pokemon in pokemons)
        {
            pokemon.Init();
        }
    }

    public Pokemon GetHealthyPokemon()
    {
        return pokemons.Where(x => x.HP > 0).FirstOrDefault();
    }

}