// FileName: Video.cs
// Author: Lewis Brockman-Horsley
// Email: 101533222@students.swinburne.edu.au
// Date: 27/09/2019
using System;
namespace MediaOrganiser.src
{
    /// <summary>
    /// Video.
    /// </summary>
    public class Video : Media
    {
        private bool _availability;

        /// <summary>
        /// Initializes a new instance of the Video class.
        /// </summary>
        public Video()
        {
            Availability = false;
        }

        /// <summary>
        /// Gets or sets a value indicating whether this Video is available.
        /// </summary>
        /// <value><c>true</c> if available; otherwise, <c>false</c>.</value>
        public bool Availability
        {
            get { return _availability; }
            set { _availability = value; }
        }

        /// <summary>
        /// Play this instance.
        /// </summary>
        /// <returns>The play.</returns>
        public override String Play()
        {
            String msg = "Video is unavailable";
            if (Availability)
            {
                msg = "Video is now ready to play";
            }

            return msg;
        }
    }
}
