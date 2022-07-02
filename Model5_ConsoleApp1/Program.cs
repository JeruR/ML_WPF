﻿
// This file was auto-generated by ML.NET Model Builder. 

using Model5_ConsoleApp1;

// Create single instance of sample data from first line of dataset for model input
Model5.ModelInput sampleData = new Model5.ModelInput()
{
    Date = @"13/08/16",
    HomeTeam = @"Crystal Palace",
    AwayTeam = @"West Brom",
    FTHG = 0F,
    FTAG = 1F,
    Referee = @"C Pawson",
};

// Make a single prediction on the sample data and print results
var predictionResult = Model5.Predict(sampleData);

Console.WriteLine("Using model to make single prediction -- Comparing actual FTR with predicted FTR from sample data...\n\n");


Console.WriteLine($"Date: {@"13/08/16"}");
Console.WriteLine($"HomeTeam: {@"Crystal Palace"}");
Console.WriteLine($"AwayTeam: {@"West Brom"}");
Console.WriteLine($"FTHG: {0F}");
Console.WriteLine($"FTAG: {1F}");
Console.WriteLine($"FTR: {@"A"}");
Console.WriteLine($"Referee: {@"C Pawson"}");


Console.WriteLine($"\n\nPredicted FTR: {predictionResult.PredictedLabel}\n\n");
Console.WriteLine("=============== End of process, hit any key to finish ===============");
Console.ReadKey();

