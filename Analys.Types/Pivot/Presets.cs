﻿using System;
using Analys.Types;

namespace Analys.Pivot {
  public static class PivotExt {
    public static (dynamic init, dynamic accum) ModeToPreset(this PivotMode mode) {
      switch (mode) {
        case PivotMode.Accum: return Presets.Accum<dynamic>();
        case PivotMode.Merge: return Presets.Accum<dynamic>();
        case PivotMode.Count: return Presets.Count();
        case PivotMode.Incre: return Presets.Incre();
        case PivotMode.Max: return Presets.Max();
        case PivotMode.Min: return Presets.Min();
        case PivotMode.First: return Presets.First();
        case PivotMode.Last: return Presets.Last();
        case PivotMode.Average: return Presets.Average();
        default: throw new ArgumentOutOfRangeException(nameof(mode), mode, "Invalid PivotMode");
      }
    }
  }

  public static class Presets {
    public static (Func<T[]> init, Func<T[], T[], T[]> accum) Merge<T>() => (Inits.Merge<T>(), Accumulators.Merge<T>());
    public static (Func<T[]> init, Func<T[], T, T[]> accum) Accum<T>() => (Inits.Accum<T>(), Accumulators.Accum<T>());
    public static (Func<int> init, Func<int, int, int> accum) Count() => (Inits.Count(), Accumulators.Count());
    public static (Func<double> init, Func<double, double, double>accum) Incre() => (Inits.Incre(), Accumulators.Incre());
    public static (Func<double> init, Func<double, double, double>accum) Max() => (Inits.Max(), Accumulators.Max());
    public static (Func<double> init, Func<double, double, double>accum) Min() => (Inits.Min(), Accumulators.Min());
    public static (Func<object> init, Func<object, object, object>accum) First() => (Inits.First(), Accumulators.First());
    public static (Func<object> init, Func<object, object, object>accum) Last() => (Inits.Last(), Accumulators.Last());
    public static (Func<Average> init, Func<Average, double, Average>accum) Average() => (Inits.Average(), Accumulators.Average());
  }
}