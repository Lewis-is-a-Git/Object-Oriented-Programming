// /**
//  * Student Number: 101533222
//  * Student Name: Lewis Brockman-Horsley
//  * Date: 18/09/2019
//  * Learning Outcomes: 
// **/
using System;
using System.Collections.Generic;
namespace MediaOrganiser
{
	public class Playlist
	{
		private List<Media> _media;

		public Playlist()
		{
			_media = new List<Media>();
		}

		/// <summary>
		/// Gets the length.
		/// </summary>
		/// <value>The length.</value>
		public int Length
		{
			get { return _media.Count; }
		}

		/// <summary>
		/// Add the specified media.
		/// </summary>
		/// <param name="media">Media.</param>
		public void Add(Media media)
		{
			_media.Add(media);
		}

		/// <summary>
		/// Remove the specified testMedia.
		/// </summary>
		/// <param name="media">Media.</param>
		public void Remove(Media media)
		{
			_media.Remove(media);
		}

		/// <summary>
		/// Gets the media at index [i].
		/// </summary>
		/// <param name="i">The index.</param>
		public Media this[int i]
		{
			get { return _media[i]; }
		}
	}
}
