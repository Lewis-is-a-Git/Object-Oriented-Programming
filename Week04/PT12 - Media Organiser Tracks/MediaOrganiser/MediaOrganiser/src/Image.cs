// FileName: Image.cs
// Author: Lewis Brockman-Horsley
// Email: 101533222@students.swinburne.edu.au
// Date: 29/09/2019
using System;
namespace MediaOrganiser.src
{
    /// <summary>
    /// Image.
    /// </summary>
    public class Image : Media
    {
        private int _pixelsInWidth;
        private int _pixelsInHeight;

        /// <summary>
        /// Initializes a new instance of the Image class.
        /// </summary>
        /// <param name="width">Width.</param>
        /// <param name="height">Height.</param>
        public Image(int width, int height)
        {
            PixelsInWidth = width;
            PixelsInHeight = height;
        }

        /// <summary>
        /// Gets or sets the height of the pixels.
        /// </summary>
        /// <value>The height of the pixels.</value>
        public int PixelsInHeight
        {
            get { return _pixelsInHeight; }
            set { _pixelsInHeight = value; }
        }
        /// <summary>
        /// Gets or sets the width of the pixels.
        /// </summary>
        /// <value>The width of the pixels.</value>
        public int PixelsInWidth
        {
            get { return _pixelsInWidth; }
            set { _pixelsInWidth = value; }
        }

        /// <summary>
        /// Play this instance.
        /// </summary>
        /// <returns>The play.</returns>
        public override String Play()
        {
            return (PixelsInWidth * PixelsInHeight).ToString();
        }
    }
}
