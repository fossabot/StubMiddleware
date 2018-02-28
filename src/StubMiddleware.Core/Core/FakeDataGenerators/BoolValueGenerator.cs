﻿using System;

namespace StubGenerator.Core.FakeDataGenerators
{
    public class BoolValueGenerator : IValueGenerator
    {
        private static readonly Random _random;
        static BoolValueGenerator() => _random = new Random();
        public object Generate()
        {
            return _random.NextDouble() >= 0.5;
        }
    }
}
