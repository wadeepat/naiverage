-> main

=== main ===
Hello
1
2
3
which pokemon do you choose?
    +[Charmander]
        -> chosen("Charmander")
    +[Bulbasaur]
        -> chosen("Bulbasaur")
    +[Squirtle]
        -> chosen("Squirtle")
=== chosen(pokemon) ===
Your chose {pokemon}!
->END