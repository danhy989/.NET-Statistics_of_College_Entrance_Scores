using MathNet.Numerics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Statistics_College_Entrance_Scores.Common
{
    public class LinearRegressionHelper
    {
        public static double LinearRegression(
            double[] xVals,
            double[] yVals,
            int year)
        {
			
            if (xVals.Length != yVals.Length)
            {
                throw new Exception("Input values should be with the same length.");
            }
			
			Tuple<double, double> p = Fit.Line(xVals, yVals);
			double intercept = p.Item1;
			double slope = p.Item2;

			var predictedValue = (slope * year) + intercept;
			return predictedValue;
        }
    }
}
