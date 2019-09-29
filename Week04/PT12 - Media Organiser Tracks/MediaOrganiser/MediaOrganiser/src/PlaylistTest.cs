// /**
//  * Student Number: 101533222
//  * Student Name: Lewis Brockman-Horsley
//  * Date: 29/09/2019
//  * Learning Outcomes: Unit Testing
// **/
using System;
using MediaOrganiser.src;
using NUnit.Framework;

namespace MediaOrganiser
{
    /// <summary>
    /// Playlist test.
    /// </summary>
    [TestFixture]
    public class TestPlaylist
    {
        /// <summary>
        /// Tests the playlist add.
        /// </summary>
        [Test]
        public void TestPlaylistAdd()
        {
            Playlist p = new Playlist();
            p.Add(new Audio("song title", "song album", 40));
            p.Add(new Audio("song title", "song album", 40));
            p.Add(new Audio("song title", "song album", 40));

            Assert.IsNotNull(p, "The playlist is not empty after adding a new song.");
        }

        /// <summary>
        /// Tests the playlist remove.
        /// </summary>
        [Test]
        public void TestPlaylistRemove()
        {
            Playlist p = new Playlist();
            Audio testMedia = new Audio("human music", "album", 100);
            p.Add(testMedia);

            Assert.IsNotNull(p, "The playlist is not empty.");

            p.Remove(testMedia);

            Assert.AreEqual(p.Length, 0, "The media has been removed.");
        }

        /// <summary>
        /// Tests the fetch indexer.
        /// </summary>
        [Test]
        public void TestFetch()
        {
            Playlist p = new Playlist();
            Image testMedia = new Image(1, 2);
            Video testMedia2 = new Video();
            p.Add(testMedia);
            p.Add(testMedia2);

            Assert.AreEqual(p[1], testMedia2, "The indexer is working.");
        }

        /// <summary>
        /// Tests the length of the playlist.
        /// </summary>
        [Test]
        public void TestLength()
        {
            Playlist p = new Playlist();

            Assert.AreEqual(p.Length, 0, "The playlist length is 0.");

            p.Add(new Audio("song", "a", 20));

            Assert.AreEqual(p.Length, 1, "The length is 1.");
        }
    }
}
