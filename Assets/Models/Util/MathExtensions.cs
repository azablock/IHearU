using System;

namespace Models.Util {
  
  public class MathExtensions {
   
    public static float NextFloat(Random random) {
      var mantissa = (random.NextDouble() * 2.0) - 1.0;
      // choose -149 instead of -126 to also generate subnormal floats (*)
      var exponent = Math.Pow(2.0, random.Next(-126, 128));

      return (float)(mantissa * exponent);
    }
  }
}