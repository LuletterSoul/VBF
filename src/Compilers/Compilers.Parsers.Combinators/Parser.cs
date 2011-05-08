﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using VBF.Compilers.Scanners;
using System.Diagnostics;

namespace VBF.Compilers.Parsers.Combinators
{
    public delegate Func<ForkableScanner, ParserContext, Result<TFuture>> Future<T, TFuture>(T value);

    public abstract class Parser<T>
    {
        public abstract Func<ForkableScanner, ParserContext, Result<TFuture>> Run<TFuture>(Future<T, TFuture> future);

        public static Parser<T> operator |(Parser<T> p1, Parser<T> p2)
        {
            return new AlternationParser<T>(p1, p2);
        }
    }
}
