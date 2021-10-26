using System;

namespace SX3.Tools.Memory.Maths
{
    public class Matrix
    {
        #region Globals

        private float[] _data;
        private int _rows;
        private int _columns;

        #endregion

        #region Properties

        public float this[int i]
        {
            get { return _data[i]; }
            set { _data[i] = value; }
        }

        public float this[int row, int column]
        {
            get { return _data[row * _columns + column]; }
            set { _data[row * _columns + column] = value; }
        }

        #endregion

        #region Constructor

        public Matrix(int rows, int columns)
        {
            this._rows = rows;
            this._columns = columns;
            this._data = new float[rows * columns];
        }

        #endregion

        #region Methods

        public void Read(byte[] data)
        {
            for (int y = 0; y < _rows; y++)
                for (int x = 0; x < _columns; x++)
                    this[y, x] = BitConverter.ToSingle(data, sizeof(float) * ((y * _columns) + x));
        }

        public byte[] ToByteArray()
        {
            int sof = sizeof(float);
            byte[] data = new byte[this._data.Length * sof];
            for (int i = 0; i < this._data.Length; i++)
                Array.Copy(BitConverter.GetBytes(this._data[i]), 0, data, i * sof, sof);

            return data;
        }

        #endregion
    }
}
