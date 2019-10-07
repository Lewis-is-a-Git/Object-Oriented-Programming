// FileName: Audio.cs
// Author: Lewis Brockman-Horsley
// Email: 101533222@students.swinburne.edu.au
// Date: 29/09/2019
using System;
namespace MediaOrganiser.src
{
    /// <summary>
    /// Audio.
    /// </summary>
    public class Audio : Media
    {
        /// <summary>
        /// The artist.
        /// </summary>
        private String _artist;
        /// <summary>
        /// The album.
        /// </summary>
        private String _album;
        /// <summary>
        /// The duration.
        /// </summary>
        private int _duration;

        /// <summary>
        /// Initializes a new instance of the Audio class.
        /// </summary>
        /// <param name="artist">Artist.</param>
        /// <param name="album">Album.</param>
        /// <param name="duration">Duration.</param>
        public Audio(String artist, String album, int duration)
        {
            _artist = artist;
            _album = album;
            _duration = duration;
        }

        /// <summary>
        /// Gets or sets the artist.
        /// </summary>
        /// <value>The artist.</value>
        public string Artist
        {
            get { return _artist; }
            set { _artist = value; }
        }
        /// <summary>
        /// Gets or sets the album.
        /// </summary>
        /// <value>The album.</value>
        public string Album
        {
            get { return _album; }
            set { _album = value; }
        }
        /// <summary>
        /// Gets or sets the duration.
        /// </summary>
        /// <value>The duration.</value>
        public int Duration
        {
            get { return _duration; }
            set { _duration = value; }
        }

        /// <summary>
        /// Play this instance.
        /// </summary>
        /// <returns>The play.</returns>
        public override String Play()
        {
            return _artist + _album + _duration.ToString();
        }
    }
}
