using MathItems.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace MathItems.Extremes.LagrangeMultiplicators
{
    public static class EquationForRegression
    {
        public static Vector2 XYLograitmicRegressionBiggestSquareUnderFunction(Vector2 coeficients) {
            double power = -1 * ((coeficients.x + coeficients.y) / coeficients.x);
            double x = Math.Pow(Math.E, power);
            double y = coeficients.x * Math.Log(x) + coeficients.y;
            return new Vector2(x, y);
        }

    }
}
