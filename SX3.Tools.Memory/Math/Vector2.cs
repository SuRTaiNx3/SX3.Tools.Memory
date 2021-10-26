using System;

namespace SX3.Tools.Memory.Maths
{
    public struct Vector2
    {
        #region Globals

        #endregion

        #region Properties

        public static Vector2 Zero
        {
            get { return new Vector2(0, 0); }
        }

        public static Vector2 UnitX
        {
            get { return new Vector2(1, 0); }
        }

        public static Vector2 UnitY
        {
            get { return new Vector2(0, 1); }
        }

        public float X { get; set; }

        public float Y { get; set; }

        #endregion

        #region Constructor

        public Vector2(Vector2 vec) : this(vec.X, vec.Y) { }

        public Vector2(float[] values) : this(values[0], values[1]) { }

        public Vector2(float x, float y)
        {
            this.X = x;
            this.Y = y;
        }

        #endregion

        #region Methods

        public float Length()
        {
            return (float)System.Math.Sqrt(System.Math.Pow(X, 2) + System.Math.Pow(Y, 2));
        }

        public float DistanceTo(Vector2 other)
        {
            return (this + other).Length();
        }


        public override bool Equals(object obj)
        {
            Vector2 vec = (Vector2)obj;
            return this.GetHashCode() == vec.GetHashCode();
        }

        public override int GetHashCode()
        {
            return this.X.GetHashCode() ^ this.Y.GetHashCode();
        }

        public override string ToString()
        {
            return string.Format("[X={0}, Y={1}]", this.X.ToString(), this.Y.ToString());
        }


        public static Vector2 operator +(Vector2 v1, Vector2 v2)
        {
            return new Vector2(v1.X + v2.X, v1.Y + v2.Y);
        }
        
        public static Vector2 operator -(Vector2 v1, Vector2 v2)
        {
            return new Vector2(v1.X - v2.X, v1.Y - v2.Y);
        }

        public static Vector2 operator *(Vector2 v1, float scalar)
        {
            return new Vector2(v1.X * scalar, v1.Y * scalar);
        }

        public static bool operator ==(Vector2 v1, Vector2 v2)
        {
            return v1.X == v2.X && v1.Y == v2.Y;
        }

        public static bool operator !=(Vector2 v1, Vector2 v2)
        {
            return !(v1 == v2);
        }

        public float this[int i]
        {
            get
            {
                switch (i)
                {
                    case 0:
                        return this.X;
                    case 1:
                        return this.Y;
                    default:
                        throw new IndexOutOfRangeException();
                }
            }
            set
            {
                switch (i)
                {
                    case 0:
                        this.X = value;
                        break;
                    case 1:
                        this.Y = value;
                        break;
                    default:
                        throw new IndexOutOfRangeException();
                }
            }
        }

        #endregion
    }
}
