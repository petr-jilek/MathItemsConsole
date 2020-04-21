using MathItems.ExceptionLibrary;
using System;
using System.Collections.Generic;
using System.Text;

namespace MathItems.Models
{
    public class Vector2
    {
        public double x;
        public double y;
        public Vector2(double x, double y) {
            this.x = x;
            this.y = y;
        }

        public Vector2 Parse(object obj) {
            if (obj is Vector) {
                Vector buf = (Vector)obj;
                if (buf.dimension != 2) throw new AuthException(AuthException.EList.InvalidVectorParse, "invalid parse");
                return new Vector2(buf.values[0], buf.values[1]);
            }
            else throw new AuthException(AuthException.EList.InvalidVectorParse, "invalid parse");
        }

        public override bool Equals(object obj) {
            return ((obj is Vector2) && (this == (Vector2)obj));
        }
        public override int GetHashCode() {
            return x.GetHashCode() ^ y.GetHashCode();
        }
        public static bool operator ==(Vector2 a, Vector2 b) {
            if (a.x == b.x && a.y == b.y) return true;
            else return false;
        }
        public static bool operator !=(Vector2 a, Vector2 b) {
            if (a.x != b.x && a.y != b.y) return true;
            else return false;
        }
        public static Vector2 operator +(Vector2 a, Vector2 b) {
            return new Vector2(a.x + b.x, a.y + b.y);
        }
        public static Vector2 operator -(Vector2 a, Vector2 b) {
            return new Vector2(a.x - b.x, a.y - b.y);
        }
        public static Vector2 operator *(double skalar, Vector2 vector) {
            return new Vector2(vector.x * skalar, vector.y * skalar);
        }
        public static double operator |(Vector2 a, Vector2 b) {
            return (a.x * b.x + a.y * b.y);
        }

    }
}
