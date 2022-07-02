﻿// This file was auto-generated by ML.NET Model Builder. 
using Microsoft.ML;
using Microsoft.ML.Data;
using System;
using System.Linq;
using System.IO;
using System.Collections.Generic;
namespace MLModel_4_A_ConsoleApp1
{
    public partial class MLModel_4_A
    {
        /// <summary>
        /// model input class for MLModel_4_A.
        /// </summary>
        #region model input class
        public class ModelInput
        {
            [ColumnName(@"Div")]
            public float Div { get; set; }

            [ColumnName(@"Date")]
            public string Date { get; set; }

            [ColumnName(@"HomeTeam")]
            public string HomeTeam { get; set; }

            [ColumnName(@"AwayTeam")]
            public string AwayTeam { get; set; }

            [ColumnName(@"FTAG")]
            public float FTAG { get; set; }

            [ColumnName(@"HS")]
            public float HS { get; set; }

            [ColumnName(@"AS")]
            public float AS { get; set; }

        }

        #endregion

        /// <summary>
        /// model output class for MLModel_4_A.
        /// </summary>
        #region model output class
        public class ModelOutput
        {
            [ColumnName(@"Div")]
            public float Div { get; set; }

            [ColumnName(@"Date")]
            public float[] Date { get; set; }

            [ColumnName(@"HomeTeam")]
            public float[] HomeTeam { get; set; }

            [ColumnName(@"AwayTeam")]
            public float[] AwayTeam { get; set; }

            [ColumnName(@"FTAG")]
            public uint FTAG { get; set; }

            [ColumnName(@"HS")]
            public float HS { get; set; }

            [ColumnName(@"AS")]
            public float AS { get; set; }

            [ColumnName(@"Features")]
            public float[] Features { get; set; }

            [ColumnName(@"PredictedLabel")]
            public float PredictedLabel { get; set; }

            [ColumnName(@"Score")]
            public float[] Score { get; set; }

        }

        #endregion

        private static string MLNetModelPath = Path.GetFullPath("MLModel_4_A.zip");

        public static readonly Lazy<PredictionEngine<ModelInput, ModelOutput>> PredictEngine = new Lazy<PredictionEngine<ModelInput, ModelOutput>>(() => CreatePredictEngine(), true);

        /// <summary>
        /// Use this method to predict on <see cref="ModelInput"/>.
        /// </summary>
        /// <param name="input">model input.</param>
        /// <returns><seealso cref=" ModelOutput"/></returns>
        public static ModelOutput Predict(ModelInput input)
        {
            var predEngine = PredictEngine.Value;
            return predEngine.Predict(input);
        }

        private static PredictionEngine<ModelInput, ModelOutput> CreatePredictEngine()
        {
            var mlContext = new MLContext();
            ITransformer mlModel = mlContext.Model.Load(MLNetModelPath, out var _);
            return mlContext.Model.CreatePredictionEngine<ModelInput, ModelOutput>(mlModel);
        }
    }
}