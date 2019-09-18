// /**
//  * Student Number: 101533222
//  * Student Name: Lewis Brockman-Horsley
//  * Date: 18/09/2019
//  * Learning Outcomes: 
// **/
using System;
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
			p.Add(new Media("song", 30, MediaType.Audio));

			Assert.IsNotNull(p, "The playlist is not empty after adding a new song.");
		}

		/// <summary>
		/// Tests the playlist remove.
		/// </summary>
		[Test]
		public void TestPlaylistRemove()
		{
			Playlist p = new Playlist();
			Media testMedia = new Media("video", 300, MediaType.Video);
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
			Media testMedia = new Media("image", 1, MediaType.Image);
			Media testMedia2 = new Media("video", 300, MediaType.Video);
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

			p.Add(new Media("song", 20, MediaType.Audio));

			Assert.AreEqual(p.Length, 1, "The length is 1.");
		}
	}
}
