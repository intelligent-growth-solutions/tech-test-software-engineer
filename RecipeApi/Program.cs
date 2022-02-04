using IgsSoftwareTechTest;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI();

app.MapGet("/recipe", () =>
{
    var recipe1 = new Recipe("Basil");
    recipe1.LightingPhases.Add(new LightingPhase("LightingPhase 1", 0, 24, 0, 5)
    {
        Operations = new List<LightingPhaseOperation>
        {
            new LightingPhaseOperation(0, 0, LightIntensity.Low),
            new LightingPhaseOperation(6, 0, LightIntensity.Medium),
            new LightingPhaseOperation(12, 0, LightIntensity.High),
            new LightingPhaseOperation(16, 0, LightIntensity.Off),
        }
    });
    
    recipe1.WateringPhases.Add(
        new WateringPhase("Watering Phase 1", 0, 24, 0, 5, 100));

    var recipe2 = new Recipe("Strawberries");
    recipe2.LightingPhases.Add(new LightingPhase("Phase 3", 0, 24, 0, 5)
    {
        Operations = new List<LightingPhaseOperation>
        {
            new LightingPhaseOperation(0, 0, LightIntensity.High),
            new LightingPhaseOperation(20, 0, LightIntensity.Off),
        }
    });
    recipe2.LightingPhases.Add(new LightingPhase("Phase 2", 1, 36, 30, 10)
    {
        Operations = new List<LightingPhaseOperation>
        {
            new LightingPhaseOperation(0, 0, LightIntensity.Low),
            new LightingPhaseOperation(6, 0, LightIntensity.Medium),
            new LightingPhaseOperation(12, 0, LightIntensity.High),
            new LightingPhaseOperation(16, 30, LightIntensity.Medium),
            new LightingPhaseOperation(24, 30, LightIntensity.Low),
            new LightingPhaseOperation(30, 0, LightIntensity.Off),
        }
    });
    recipe2.LightingPhases.Add(new LightingPhase("Phase 3", 0, 24, 0, 2)
    {
        Operations = new List<LightingPhaseOperation>
        {
            new LightingPhaseOperation(0, 0, LightIntensity.Low),
            new LightingPhaseOperation(6, 0, LightIntensity.Medium),
            new LightingPhaseOperation(12, 0, LightIntensity.Off),
        }
    });
    recipe2.WateringPhases.Add(
        new WateringPhase("Phase 1", 0, 24, 0, 5, 0));
    recipe2.WateringPhases.Add(
        new WateringPhase("Phase 2", 1, 24, 0, 6, 55));
    recipe2.WateringPhases.Add(
        new WateringPhase("Phase 3", 3, 24, 0, 2, 30));
    recipe2.WateringPhases.Add(
        new WateringPhase("Phase 4", 2, 12, 30, 4, 30));

    var recipes = new List<Recipe>
    {
        recipe1, recipe2
    };

    var rootObject = new { recipes = recipes };
    
    return Results.Ok(rootObject);
});

app.Run();