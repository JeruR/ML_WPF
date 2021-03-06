﻿// This file was auto-generated by ML.NET Model Builder. 
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.ML.Data;
using Microsoft.ML.Trainers;
using Microsoft.ML;

namespace ML_WPF
{
    public partial class MLModel_4_A
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
            var pipeline = mlContext.Transforms.ReplaceMissingValues(new []{new InputOutputColumnPair(@"HS", @"HS"),new InputOutputColumnPair(@"AS", @"AS")})      
                                    .Append(mlContext.Transforms.Text.FeaturizeText(inputColumnName:@"Date",outputColumnName:@"Date"))      
                                    .Append(mlContext.Transforms.Text.FeaturizeText(inputColumnName:@"HomeTeam",outputColumnName:@"HomeTeam"))      
                                    .Append(mlContext.Transforms.Text.FeaturizeText(inputColumnName:@"AwayTeam",outputColumnName:@"AwayTeam"))      
                                    .Append(mlContext.Transforms.Concatenate(@"Features", new []{@"HS",@"AS",@"Date",@"HomeTeam",@"AwayTeam"}))      
                                    .Append(mlContext.Transforms.Conversion.MapValueToKey(outputColumnName:@"FTAG",inputColumnName:@"FTAG"))      
                                    .Append(mlContext.Transforms.NormalizeMinMax(@"Features", @"Features"))      
                                    .Append(mlContext.MulticlassClassification.Trainers.SdcaMaximumEntropy(new SdcaMaximumEntropyMulticlassTrainer.Options(){L1Regularization=0.141172F,L2Regularization=0.03125F,LabelColumnName=@"FTAG",FeatureColumnName=@"Features"}))      
                                    .Append(mlContext.Transforms.Conversion.MapKeyToValue(outputColumnName:@"PredictedLabel",inputColumnName:@"PredictedLabel"));

            return pipeline;
        }
    }
}
