using System;
using System.Linq;

namespace VariablesAndExpressions
{   
    /// <summary>
    /// Contains methods for <see cref="Size" />.
    /// </summary>
    class MySizeHandler
    {
        /// <summary>
        /// Rotates a Size object by given angle.
        /// </summary>
        /// <param name="oldSize"><see cref="Size" /> before the rotation.</param>
        /// <param name="angleOfRotation">Angle of the rotation.</param>
        /// <returns>The new <see cref="Size" />.</returns>
        public static Size GetRotatedSize(Size oldSize, double angleOfRotation)
        {
            double newWidth = Math.Abs(Math.Cos(angleOfRotation)) * oldSize.Width
                + Math.Abs(Math.Sin(angleOfRotation)) * oldSize.Height;

            double newHeight = Math.Abs(Math.Sin(angleOfRotation)) * oldSize.Width
                + Math.Abs(Math.Cos(angleOfRotation)) * oldSize.Height;

            return new Size(newWidth, newHeight);
        }
    }
}