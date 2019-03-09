﻿namespace dk.lashout.LARPay.Administration
{
    public sealed class Result
    {
        public string ErrorMessage { get; }

        public bool Success => ErrorMessage == null;

        public Result() { }

        public Result(string errorMessage)
        {
            ErrorMessage = errorMessage ?? throw new System.ArgumentNullException(nameof(errorMessage));
        }
    }
}