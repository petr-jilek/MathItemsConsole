using System;
using System.Collections.Generic;
using System.Text;

namespace MathItems.Models
{
    class Matrix
    {
        public Vector[] vectors;
        public int Rows {
            get {
                if (vectors == null) return -1;
                if (vectors.Length >= 1) return vectors.Length;
                return -1;
            }
            set { }
        }
        public int Columns {
            get {
                if (vectors == null) return -1;
                if (vectors.Length >= 1) {
                    if (vectors[0].dimension >= 1) {
                        return vectors[0].dimension;
                    }
                }
                return -1;
            }
            set { }
        }
        public bool regular;
        public bool singular;

        public Matrix(Vector[] vectors) {
            if (vectors == null) {
                vectors = null;
            }
            else {
                this.vectors = vectors;
            }
        }

        
    }
}
