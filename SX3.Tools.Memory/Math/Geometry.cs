using System;

namespace SX3.Tools.Memory.Maths
{
    public static class Geometry
    {
        #region Methods

        public static float GetDistanceToPoint(Vector3 pointA, Vector3 pointB)
        {
            return (float)Math.Abs((pointA - pointB).Length());
        }

        public static W2SNStruct[] WorldToScreen(Matrix4x4 viewMatrix, Size2 screenSize, params Vector3[] points)
        {
            W2SNStruct[] worlds = new W2SNStruct[points.Length];
            for (int i = 0; i < worlds.Length; i++)
                worlds[i] = WorldToScreen(viewMatrix, screenSize, points[i]);
            return worlds;
        }

        public static W2SNStruct WorldToScreen(Matrix4x4 viewMatrix, Size2 screenSize, Vector3 point)
        {
            W2SNStruct w2sn = new W2SNStruct();
            Vector2 returnVector = Vector2.Zero;

            float w = viewMatrix.M41 * point.X + viewMatrix.M42 * point.Y + viewMatrix.M43 * point.Z + viewMatrix.M44;
            if (w >= 0.01f)
            {
                float inverseWidth = 1f / w;
                returnVector.X =
                    (screenSize.Width / 2f) +
                    (0.5f * ((viewMatrix.M11 * point.X + viewMatrix.M12 * point.Y + viewMatrix.M13 * point.Z + viewMatrix.M14) * inverseWidth)
                    * screenSize.Width + 0.5f);
                returnVector.Y =
                    (screenSize.Height / 2f) -
                    (0.5f * ((viewMatrix.M21 * point.X + viewMatrix.M22 * point.Y + viewMatrix.M23 * point.Z + viewMatrix.M24) * inverseWidth)
                    * screenSize.Height + 0.5f);

                w2sn.OnScreen = true;
            }
            else
            {
                w2sn.OnScreen = false;
            }

            w2sn.Coords = returnVector;
            return w2sn;
        }


        public static Vector3[] Create3DFlatCircle(Vector3 center, float radius, int segments)
        {
            Vector3[] points = new Vector3[segments];
            float angle = 0f;
            for (int i = 0; i < points.Length; i++)
            {
                angle = DegToRad(360f / ((float)segments) * (float)i);

                points[i] = new Vector3(
                    center.X + radius * (float)Math.Cos(angle),
                    center.Y + radius * (float)Math.Sin(angle),
                    center.Z);
            }
            return points;
        }

        public static Vector3[] OffsetVectors(Vector3 offset, params Vector3[] points)
        {
            for (int i = 0; i < points.Length; i++)
                points[i] += offset;
            return points;
        }

        public static Vector3[] CopyVectors(Vector3[] source)
        {
            Vector3[] ret = new Vector3[source.Length];
            for (int i = 0; i < ret.Length; i++)
                ret[i] = new Vector3(source[i].X, source[i].Y, source[i].Z);
            return ret;
        }

        public static Vector2 RotatePoint(Vector2 pointToRotate, Vector2 centerPoint, float angleInDegrees)
        {
            float angleInRadians = (float)(angleInDegrees * (Math.PI / 180f));
            float cosTheta = (float)Math.Cos(angleInRadians);
            float sinTheta = (float)Math.Sin(angleInRadians);
            return new Vector2
            {
                X =
                    (int)
                    (cosTheta * (pointToRotate.X - centerPoint.X) -
                    sinTheta * (pointToRotate.Y - centerPoint.Y) + centerPoint.X),
                Y =
                    (int)
                    (sinTheta * (pointToRotate.X - centerPoint.X) +
                    cosTheta * (pointToRotate.Y - centerPoint.Y) + centerPoint.Y)
            };
        }


        private static Vector2 RotatePoint(Vector3 pointToRotate, Vector3 centerPoint, float rotationDeg)
        {
            return RotatePoint(
                new Vector2(pointToRotate.X, pointToRotate.Y),
                new Vector2(centerPoint.X, centerPoint.Y),
                rotationDeg);
        }

        public static bool PointSeesPoint(float degree, float fovDegree)
        {
            degree = (float)Math.Abs(degree);
            return degree >= 90 - fovDegree / 2f && degree <= 90 + fovDegree / 2f;
        }

        public static float DegreeBetweenVectors(Vector2 playerA, Vector2 playerB)
        {
            return (float)(Math.Atan2(playerB.Y - playerA.Y, playerB.X - playerA.X) * 180f / Math.PI);
        }

        public static float DegToRad(float deg) { return (float)(deg * (Math.PI / 180f)); }

        public static float RadToDeg(float deg) { return (float)(deg * (180f / Math.PI)); }

        public static float DotProduct(Vector2 v1, Vector2 v2) { return (v1.X * v2.X) + (v1.Y * v2.Y); }

        public static bool PointInCircle(Vector2 point, Vector2 circleCenter, float radius)
        {
            return Math.Sqrt(((circleCenter.X - point.X) * (circleCenter.X - point.X)) + ((circleCenter.Y - point.Y) * (circleCenter.Y - point.Y))) < radius;
        }

        public static Vector3 ClampAngle(Vector3 qaAng)
        {

            if (qaAng.X > 89.0f && qaAng.X <= 180.0f)
                qaAng.X = 89.0f;

            while (qaAng.X > 180.0f)
                qaAng.X = qaAng.X - 360.0f;

            if (qaAng.X < -89.0f)
                qaAng.X = -89.0f;

            while (qaAng.Y > 180.0f)
                qaAng.Y = qaAng.Y - 360.0f;

            while (qaAng.Y < -180.0f)
                qaAng.Y = qaAng.Y + 360.0f;

            return qaAng;
        }

        public static Vector3 CalcAngle(Vector3 src, Vector3 dst)
        {
            Vector3 ret = new Vector3();
            Vector3 vDelta = src - dst;
            float fHyp = (float)Math.Sqrt((vDelta.X * vDelta.X) + (vDelta.Y * vDelta.Y));

            ret.X = RadToDeg((float)Math.Atan(vDelta.Z / fHyp));
            ret.Y = RadToDeg((float)Math.Atan(vDelta.Y / vDelta.X));

            if (vDelta.X >= 0.0f)
                ret.Y += 180.0f;
            return ret;
        }

        #endregion
    }
}
