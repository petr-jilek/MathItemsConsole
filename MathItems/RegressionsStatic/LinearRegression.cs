using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MathItems.ExceptionLibrary;
using MathItems.Models;

namespace MathItems.RegressionsStatic
{
    public static class LinearRegression
    {
        // Give Vector2 with coeficients of linear function, that aproximate points which is in values.
        // The function is f(x) = k1*x + k0
        // From returned vector like "vec", you can get koeficient k1 from vec.x and koeficient k0 form vec.y 
        public static Vector2 GetCoeficientsOfLinearRegressionSmallestSquaresTwoDimensions(List<Vector2> values) {
            int n = values.Count();
            double sumX = 0;
            double sumY = 0;
            double sumXY = 0;
            double sumXsquare = 0;
            foreach (Vector2 v in values) {
                sumX += v.x;
                sumY += v.y;
                sumXY += (v.x * v.y);
                sumXsquare += (v.x * v.x);
            }
            double down = (((double)n * sumXsquare) - (sumX * sumX));
            if (down == 0) throw new AuthException(AuthException.EList.DividingByZero, "dividing by zero");
            double k1 = (((double)n * sumXY) - (sumX * sumY)) / down;
            down = (((double)n * sumXsquare) - (sumX * sumX));
            if (down == 0) throw new AuthException(AuthException.EList.DividingByZero, "dividing by zero");
            double k0 = ((sumXsquare * sumY) - (sumX * sumXY)) / down;
            return new Vector2(k1, k0);
        }

    }
}
