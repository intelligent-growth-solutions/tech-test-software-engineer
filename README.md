# IGS Software Engineer Tech Test
One of the core functions of the IGS software is to automate the growing of plants. Our plant scientists come up with come up with **Recipes** that are a sort of a blueprint for how plants should be grown - when to expose them to light, when to water them etc.

The growing process happens in, what we call, a Tower. An IGS Tower has a number of trays, stacked vertically. Each tray is equipped with lights and has the ability to be watered.

# Objective
Given the list of recipe names, start dates and tray numbers outlined below, create an application that queries the Recipe API (see info below) and generates a JSON file with a schedule. The schedule should outline at exactly what time light and water commands should be sent to the Tower, and what the light intensity or amount to water should be.

The dates in the schedule should be in UTC.

```typescript
{
  input: [
    {
      trayNumber: 1,
      recipeName: "Basil",
      startDate: "2022-01-24T12:30:00.0000000Z"
    },
    {
      trayNumber: 2,
      recipeName: "Strawberries",
      startDate: "2021-13-08T17:33:00.0000000Z"
    },
    {
      trayNumber: 3,
      recipeName: "Basil",
      startDate: "2030-01-01T23:45:00.0000000Z"
    }
  ]
}
```

# Recipes
In an IGS tower, we control all weather conditions normally associated with the growth process. A recipe has Phases for each growth stage of a plant during which we cycle through a repeated set of operations for each tower function (e.g. watering & lighting).

A simple example would be that Phase 1 has a cycle that is 24 hours long and is repeated 7 times. This would translate into exactly 1 week. A Phase's cycle however, can be as many hours as is specified in the recipe, meaning you could have 36 hour phases where lights are on for longer, effectively making each "day" longer.

Within each recipe there can be 1 or more phases. This is in order to balance the amount of light and water a plant needs for optimal growth within each stage of it's development.

## Lighting Phases
Each lighting phase contains 0 or more Operations.

The Operations within each phase essentially mimic the rising and setting sun.

Each Operation specifies an offset time for when it should be executed relative to the beginning of the phase. It also specifies the intensity.

Light intensity is represented by a number 0-3:
Number | Intensity
------ | --------
0      | Off
1      | Low
2      | Medium
3      | High



## Watering Phases
Watering Phases work in a similar way but instead of a set of Operations within each cycle, they just have a number of litres of water to deliver on each repetition.

# Recipes API
Start the Recipes API by running the following command

```
docker-compose up
```
That should let you access it at `localhost:8080/swagger` or `localhost:8080/recipe`.

Refer to the Swagger page for examples of the structure.

You shouldn't need to look at the implementation of the Recipe API but feel free to do so if that helps you in any way.

# Requirements
- Solution should be done using the latest version of C# & dotnet.
- The solution should be accompanied by a README file containing your thought process, any shortcuts you've taken and why, assumptions that had to be made as well as how you would evolve your solution to make it ready for a production environment.
- The solution should be delivered as a git repository with instructions for how to run it.

# Bonus Points
- Unit tests
- Dockerised solution


