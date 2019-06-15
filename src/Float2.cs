// ----------------------------------------------------------------------------
// The MIT License
// Types for Entity Component System framework https://github.com/Leopotam/ecs
// Copyright (c) 2017-2019 Leopotam <leopotam@gmail.com>
// ----------------------------------------------------------------------------

using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace Leopotam.Ecs.Types {
    /// <summary>
    /// Vector with 2 float components.
    /// </summary>
    [Serializable]
    [StructLayout (LayoutKind.Sequential)]
    public struct Float2 {
        public float X;
        public float Y;

        /// <summary>
        /// Returns vector with (0,0) values.
        /// </summary>
        public static readonly Float2 Zero = new Float2 ();

        /// <summary>
        /// Returns vector with (1,1) values.
        /// </summary>
        public static readonly Float2 One = new Float2 (1f, 1f);

        /// <summary>
        /// Returns vector with (1,0) values.
        /// </summary>
        public static readonly Float2 Right = new Float2 (1f, 0f);

        /// <summary>
        /// Returns vector with (0,1) values.
        /// </summary>
        public static readonly Float2 Up = new Float2 (0f, 1f);

        [MethodImpl (MethodImplOptions.AggressiveInlining)]
        public Float2 (float x, float y) {
            X = x;
            Y = y;
        }

        /// <summary>
        /// Reverses vector direction inplace.
        /// </summary>
        [MethodImpl (MethodImplOptions.AggressiveInlining)]
        public void Neg () {
            X = -X;
            Y = -Y;
        }

        /// <summary>
        /// Sets vector component values.
        /// </summary>
        [MethodImpl (MethodImplOptions.AggressiveInlining)]
        public void Set (float x, float y) {
            X = x;
            Y = y;
        }

        /// <summary>
        /// Normalizes vector inplace.
        /// </summary>
        [MethodImpl (MethodImplOptions.AggressiveInlining)]
        public void Normalize () {
            var length = (float) Math.Sqrt(x * x + y * y);
            if (length != 0)
            {
                x /= length;
                y /= length;
            }
        }

#if DEBUG
        public override string ToString () {
            return string.Format (System.Globalization.CultureInfo.InvariantCulture, "({0:F5}, {1:F5})", X, Y);
        }
#endif
        /// <summary>
        /// Returns dot product of vectors.
        /// </summary>
        [MethodImpl (MethodImplOptions.AggressiveInlining)]
        public static float Dot (in Float2 lhs, in Float2 rhs) {
            return lhs.X * rhs.X + lhs.Y * rhs.Y;
        }

        /// <summary>
        /// Sets components to min values from 2 vectors.
        /// </summary>
        /// <param name="lhs">First vector.</param>
        /// <param name="rhs">Second vector.</param>
        [MethodImpl (MethodImplOptions.AggressiveInlining)]
        public static Float2 Min (in Float2 lhs, in Float2 rhs) {
            Float2 res;
            res.X = lhs.X <= rhs.X ? lhs.X : rhs.X;
            res.Y = lhs.Y <= rhs.Y ? lhs.Y : rhs.Y;
            return res;
        }

        /// <summary>
        /// Sets components to max values from 2 vectors.
        /// </summary>
        /// <param name="lhs">First vector.</param>
        /// <param name="rhs">Second vector.</param>
        [MethodImpl (MethodImplOptions.AggressiveInlining)]
        public static Float2 Max (in Float2 lhs, in Float2 rhs) {
            Float2 res;
            res.X = lhs.X >= rhs.X ? lhs.X : rhs.X;
            res.Y = lhs.Y >= rhs.Y ? lhs.Y : rhs.Y;
            return res;
        }

        /// <summary>
        /// Returns linear interpolated vector value between start and end vectors.
        /// </summary>
        /// <param name="lhs">Start vector.</param>
        /// <param name="rhs">End vector.</param>
        /// <param name="t">Factor in range [0f,1f].</param>
        [MethodImpl (MethodImplOptions.AggressiveInlining)]
        public static Float2 Lerp (in Float2 lhs, in Float2 rhs, float t) {
            if (t > 1f) {
                return rhs;
            } else {
                if (t < 0f) {
                    return lhs;
                }
            }
            Float2 res;
            res.X = (rhs.X - lhs.X) * t + lhs.X;
            res.Y = (rhs.Y - lhs.Y) * t + lhs.Y;
            return res;
        }

        /// <summary>
        /// Returns square magnitude of vector.
        /// </summary>
        [MethodImpl (MethodImplOptions.AggressiveInlining)]
        public float GetSqrMagnitude () {
            return X * X + Y * Y;
        }

        /// <summary>
        /// Returns magnitude of vector.
        /// </summary>
        [MethodImpl (MethodImplOptions.AggressiveInlining)]
        public float GetMagnitude () {
            return (float) Math.Sqrt (X * X + Y * Y);
        }

        /// <summary>
        /// Returns normalized version of vector.
        /// </summary>
        [MethodImpl (MethodImplOptions.AggressiveInlining)]
        public Float2 GetNormalized () {
            Float2 res;
            var invMagnitude = 1f / (float) Math.Sqrt (X * X + Y * Y);
            res.X = X * invMagnitude;
            res.Y = Y * invMagnitude;
            return res;
        }

        [MethodImpl (MethodImplOptions.AggressiveInlining)]
        public static Float2 operator + (in Float2 lhs, in Float2 rhs) {
            Float2 res;
            res.X = lhs.X + rhs.X;
            res.Y = lhs.Y + rhs.Y;
            return res;
        }

        [MethodImpl (MethodImplOptions.AggressiveInlining)]
        public static Float2 operator - (in Float2 lhs, in Float2 rhs) {
            Float2 res;
            res.X = lhs.X - rhs.X;
            res.Y = lhs.Y - rhs.Y;
            return res;
        }

        [MethodImpl (MethodImplOptions.AggressiveInlining)]
        public static Float2 operator * (in Float2 lhs, in Float2 rhs) {
            Float2 res;
            res.X = lhs.X * rhs.X;
            res.Y = lhs.Y * rhs.Y;
            return res;
        }

        [MethodImpl (MethodImplOptions.AggressiveInlining)]
        public static Float2 operator * (in Float2 lhs, float rhs) {
            Float2 res;
            res.X = lhs.X * rhs;
            res.Y = lhs.Y * rhs;
            return res;
        }

        [MethodImpl (MethodImplOptions.AggressiveInlining)]
        public static Float2 operator / (in Float2 lhs, float rhs) {
            Float2 res;
            res.X = lhs.X / rhs;
            res.Y = lhs.Y / rhs;
            return res;
        }

        [MethodImpl (MethodImplOptions.AggressiveInlining)]
        public static Float2 operator - (in Float2 lhs) {
            Float2 res;
            res.X = -lhs.X;
            res.Y = -lhs.Y;
            return res;
        }

        [MethodImpl (MethodImplOptions.AggressiveInlining)]
        public static bool operator == (in Float2 lhs, in Float2 rhs) {
            return (lhs.X - rhs.X) * (lhs.X - rhs.X) + (lhs.Y - rhs.Y) * (lhs.Y - rhs.Y) < MathFast.EpsilonSqr;
        }

        [MethodImpl (MethodImplOptions.AggressiveInlining)]
        public static bool operator != (in Float2 lhs, in Float2 rhs) {
            return (lhs.X - rhs.X) * (lhs.X - rhs.X) + (lhs.Y - rhs.Y) * (lhs.Y - rhs.Y) >= MathFast.EpsilonSqr;
        }

        [MethodImpl (MethodImplOptions.AggressiveInlining)]
        public override int GetHashCode () {
            return X.GetHashCode () ^ (Y.GetHashCode () << 2);
        }

        [MethodImpl (MethodImplOptions.AggressiveInlining)]
        public override bool Equals (object other) {
            if (!(other is Float2)) {
                return false;
            }
            var rhs = (Float2) other;
            return (X - rhs.X) * (X - rhs.X) + (Y - rhs.Y) * (Y - rhs.Y) < MathFast.EpsilonSqr;
        }

#if UNITY_2018_3_OR_NEWER
        [MethodImpl (MethodImplOptions.AggressiveInlining)]
        public static implicit operator UnityEngine.Vector2 (in Float2 lhs) {
            UnityEngine.Vector2 res;
            res.x = lhs.X;
            res.y = lhs.Y;
            return res;
        }

        [MethodImpl (MethodImplOptions.AggressiveInlining)]
        public static implicit operator Float2 (in UnityEngine.Vector2 lhs) {
            Float2 res;
            res.X = lhs.x;
            res.Y = lhs.y;
            return res;
        }
#endif
    }
}
