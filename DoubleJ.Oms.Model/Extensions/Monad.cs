using System;

namespace DoubleJ.Oms.Model.Extensions
{
    public static class Monad
    {
        public static TOut With<TIn, TOut>(this TIn source, Func<TIn, TOut> func)
            where TIn : class
            where TOut : class
        {
            return source == null ? null : func(source);
        }

        public static TResult With<TInput, TResult>(this TInput? o, Func<TInput, TResult> evaluator)
            where TResult : class
            where TInput : struct
        {
            return o.HasValue ? evaluator(o.Value) : null;
        }

        public static TResult? With<TInput, TResult>(this TInput o, Func<TInput, TResult?> evaluator)
            where TResult : struct
            where TInput : class
        {
            return o == null ? null : evaluator(o);
        }

        public static TOut Return<TIn, TOut>(this TIn source, Func<TIn, TOut> func)
            where TIn : class
            where TOut : class
        {
            return source == null ? default(TOut) : func(source);
        }
    }
}
