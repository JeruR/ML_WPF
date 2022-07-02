﻿﻿// This file was auto-generated by ML.NET Model Builder. 
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.ML.Data;
using Microsoft.ML.Trainers.LightGbm;
using Microsoft.ML.Trainers;
using Microsoft.ML;

namespace Footbal_predict
{
    public partial class MLModel1
    {
        /// <summary>
        /// Retrains model using the pipeline generated as part of the training process. For more information on how to load data, see aka.ms/loaddata.
        /// </summary>
        /// <param name="mlContext"></param>
        /// <param name="trainData"></param>
        /// <returns></returns>
        public static ITransformer RetrainPipeline(MLContext mlContext, IDataView trainData)
        {
            var pipeline = BuildPipeline(mlContext);
            var model = pipeline.Fit(trainData);

            return model;
        }

        /// <summary>
        /// build the pipeline that is used from model builder. Use this function to retrain model.
        /// </summary>
        /// <param name="mlContext"></param>
        /// <returns></returns>
        public static IEstimator<ITransformer> BuildPipeline(MLContext mlContext)
        {
            // Data process configuration with pipeline data transformations
            var pipeline = mlContext.Transforms.ReplaceMissingValues(new []{new InputOutputColumnPair(@"FTHG", @"FTHG"),new InputOutputColumnPair(@"FTAG", @"FTAG"),new InputOutputColumnPair(@"HS", @"HS"),new InputOutputColumnPair(@"AS", @"AS")})      
                                    .Append(mlContext.Transforms.Text.FeaturizeText(inputColumnName:@"Date",outputColumnName:@"Date"))      
                                    .Append(mlContext.Transforms.Text.FeaturizeText(inputColumnName:@"HomeTeam",outputColumnName:@"HomeTeam"))      
                                    .Append(mlContext.Transforms.Text.FeaturizeText(inputColumnName:@"AwayTeam",outputColumnName:@"AwayTeam"))      
                                    .Append(mlContext.Transforms.Text.FeaturizeText(inputColumnName:@"Referee",outputColumnName:@"Referee"))      
                                    .Append(mlContext.Transforms.Concatenate(@"Features", new []{@"FTHG",@"FTAG",@"HS",@"AS",@"Date",@"HomeTeam",@"AwayTeam",@"Referee"}))      
                                    .Append(mlContext.Transforms.Conversion.MapValueToKey(outputColumnName:@"FTR",inputColumnName:@"FTR"))      
                                    .Append(mlContext.MulticlassClassification.Trainers.LightGbm(new LightGbmMulticlassTrainer.Options(){NumberOfLeaves=4,NumberOfIterations=4,MinimumExampleCountPerLeaf=30,LearningRate=0.999999776672986,LabelColumnName=@"FTR",FeatureColumnName=@"Features",ExampleWeightColumnName=null,Booster=new GradientBooster.Options(){SubsampleFraction=0.999999776672986,FeatureFraction=0.99999999,L1Regularization=2E-10,L2Regularization=0.0256202574162605},MaximumBinCountPerFeature=194}))      
                                    .Append(mlContext.Transforms.Conversion.MapKeyToValue(outputColumnName:@"PredictedLabel",inputColumnName:@"PredictedLabel"));

            return pipeline;
        }
    }
}
