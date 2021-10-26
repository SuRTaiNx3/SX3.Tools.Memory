using System;

namespace SX3.Tools.Memory.Maths
{
    public class Size2 : IEquatable<Size2>
    {
        #region Globals

        #endregion

        #region Properties

        public static Size2 Zero { get; } = new Size2(0, 0);

        public static Size2 Empty { get; } = Zero;

        public int Width { get; set; }

        public int Height { get; set; }

        #endregion

        #region Constructor

        public Size2(int width, int height)
        {
            Width = width;
            Height = height;
        }

        #endregion

        #region Methods

        public bool Equals(Size2 other)
        {
            return other.Width == Width && other.Height == Height;
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (obj.GetType() != typeof(Size2)) return false;
            return Equals((Size2)obj);
        }

        public override int GetHashCode()
        {
            unchecked { return (Width * 397) ^ Height; }
        }

        public override string ToString()
        {
            return string.Format("({0},{1})", Width, Height);
        }


        public static bool operator ==(Size2 left, Size2 right)
        {
            return left.Equals(right);
        }

        public static bool operator !=(Size2 left, Size2 right)
        {
            return !left.Equals(right);
        }

        #endregion
    }
}
