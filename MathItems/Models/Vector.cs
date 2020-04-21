using System;
using System.Collections.Generic;
using System.Text;

namespace MathItems.Models
{
    public class Vector
    {
        public readonly int dimension;
        public double[] values;

        public Vector(int dimension, double[] values) {
            if (dimension < 1) {
                dimension = -1;
                values = null;
            }
            else {
                this.dimension = dimension;
                if (values.Length == dimension)
                    this.values = values;
                else {
                    dimension = -1;
                    values = null;
                }
            }
        }

        public override bool Equals(object obj) {
            return ((obj is Vector) && (this == (Vector)obj));
        }
        public override int GetHashCode() {
            return dimension.GetHashCode() ^ values.GetHashCode();         
        }
        public static bool operator ==(Vector a, Vector b) {
            if (a.dimension != b.dimension) return false;
            for (int i = 0; i < a.dimension; i++) {
                if (a.values[i] != b.values[i]) return false;
            }
            return true;
        }
        public static bool operator !=(Vector a, Vector b) {
            if (a.dimension == b.dimension) return false;
            for (int i = 0; i < a.dimension; i++) {
                if (a.values[i] != b.values[i]) return true;
            }
            return false;
        }
        public static Vector operator +(Vector a, Vector b) {
            if (IsVectorOk(a) == false || IsVectorOk(b) == false) return new Vector(-1, null);
            double[] newValues = new double[a.dimension];
            for (int i = 0; i < a.dimension; i++) {
                newValues[i] = a.values[i] + b.values[i];
            }
            return new Vector(a.dimension, newValues);
        }
        public static Vector operator -(Vector a, Vector b) {
            if (IsVectorOk(a) == false || IsVectorOk(b) == false) return new Vector(-1, null);
            double[] newValues = new double[a.dimension];
            for (int i = 0; i < a.dimension; i++) {
                newValues[i] = a.values[i] - b.values[i];
            }
            return new Vector(a.dimension, newValues);
        }
        public static Vector operator *(double skalar, Vector vector) {
            if (IsVectorOk(vector) == false) return new Vector(-1, null);
            double[] newValues = new double[vector.dimension];
            for (int i = 0; i < vector.dimension; i++) {
                newValues[i] = vector.values[i] * skalar;
            }
            return new Vector(vector.dimension, newValues);
        }
        public static double operator |(Vector a, Vector b) {
            if (IsVectorOk(a) == false || IsVectorOk(b) == false) return -1;
            double value = 0;
            for (int i = 0; i < a.dimension; i++) {
                value += a.values[i] * b.values[i];
            }
            return value;
        }

        public static bool IsVectorOk(Vector vector) {
            if (vector.dimension == -1 || vector.values == null) return false;
            return true;
        }

    }
}
