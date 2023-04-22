const avengers = [ 
  { 
     "name": "Iron Man", 
     "alter_ego": "Tony Stark", 
     "primary_power": 
     "Powered Armor", "universe": 
     "Marvel Cinematic Universe", "age": 48 
  },
  {
      "name": "Captain America", 
      "alter_ego": "Steve Rogers", 
      "primary_power": "Super Soldier Serum", 
      "universe": "Marvel Cinematic Universe", "age": 105 
  }, 
  { 
      "name": "Thor", 
      "alter_ego": "Thor Odinson",
      "primary_power": "Super Strength", 
      "universe": "Marvel Cinematic Universe", 
      "age": 1500 
  },
  {
      "name": "The Hulk", 
      "alter_ego": "Bruce Banner",
      "primary_power": "Super Strength",
      "universe": "Marvel Cinematic Universe",
      "age": 49 
  },
  { 
      "name": "Black Widow",
       "alter_ego": "Natasha Romanoff",
      "primary_power": "Expert Spy and Assassin",
      "universe": "Marvel Cinematic Universe",
      "age": 37
  },
  {
      "name": "Hawkeye", 
      "alter_ego": "Clint Barton",
      "primary_power": "Expert Marksman",
      "universe": "Marvel Cinematic Universe",
      "age": 51
   }
];

// Each loop is started with a console line that explains what each section is.
console.log("All Avengers:");
// A for...of loop is used to iterate through each array and its values.
for (let hero of avengers) {
    console.log(hero.name);
}

console.log("Avengers with Super Strength as primary ability:");
for (let hero of avengers) {
    // The if condition checks if the primary strength value of the hero is "Super Strength" and adds it to the list
    if (hero.primary_power == "Super Strength") {
        console.log(hero.name);
        // There is no else condition because there is no need to do anything if the value does not match.
    }
}

console.log("Avengers older than or equal to the age of 50:");
for (let hero of avengers) {
    // The same thing is repeated here, where any hero over or equal to age 50 is written on the console and the others are ignored.
    if (hero.age >= 50) {
        // String interpolation is used to write out the values cleanly into the console.
        console.log(`${hero.name}: ${hero.age}`);
    }
}