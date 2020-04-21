using MathItems.ExceptionLibrary;
using MathItems.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MathItems.RegressionsStatic
{
    public static class LogaritmicRegression
    {
        // Give Vector2 with coeficients of logaritmic function, that aproximate points which is in values.
        // The function is f(x) = k1*ln(x) + k0
        // From returned vector like "vec", you can get koeficient k1 from vec.x and koeficient k0 form vec.y 
        public static Vector2 GetCoeficientsOfLogaritmicRegressionTwoDimensions(List<Vector2> values) {
            int n = values.Count();
            double sumY = 0;
            double sumLnX = 0;
            double sumYlnX = 0;
            double sumLnSquareX = 0;
            double lnX = 0;
            foreach (Vector2 v in values) {
                if (v.x <= 0) throw new AuthException(AuthException.EList.LogaritmicError, "logaritmic error");
                lnX = Math.Log(v.x);
                sumY += v.y;
                sumLnX += lnX;
                sumYlnX += v.y * lnX;
                sumLnSquareX += lnX * lnX;
            }
            double down = (((double)n * sumLnSquareX) - (sumLnX * sumLnX));
            if (down == 0) throw new AuthException(AuthException.EList.DividingByZero, "dividing by zero");
            double k1 = (((double)n * sumYlnX) - (sumY * sumLnX)) / down;
            down = (double)n;
            if (down == 0) throw new AuthException(AuthException.EList.DividingByZero, "dividing by zero");
            double k0 = (sumY - (k1 * sumLnX)) / down;
            return new Vector2(k1, k0);
        }

    }
}
