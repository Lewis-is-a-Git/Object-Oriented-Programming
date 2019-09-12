// /**
//  * Student Number: 101533222
//  * Student Name: Lewis Brockman-Horsley
//  * Date: 12/09/2019
//  * Learning Outcomes: 
// **/
using System;
using NUnit.Framework;
namespace MediaOrganiser
{
	/// <summary>
	/// Media tests.
	/// </summary>
	[TestFixture]
	public class MediaTests
	{
		/// <summary>
		/// Tests the type returns the correct string
		/// </summary>
		[Test]
		public void TestType()
		{
			Media m1 = new Media("title", 20, MediaType.Audio);
			Assert.AreEqual("Ready for some light music!\n", m1.Play());
			Media m2 = new Media("title", 20, MediaType.Video);
			Assert.AreEqual("Be entertained by the visual effect!\n", m2.Play());
			Media m3 = new Media("title", 20, MediaType.Image);
			Assert.AreEqual("High resolution image provided!\n", m3.Play());
		}

		/// <summary>
		/// Tests chaning the title.
		/// </summary>
		[Test]
		public void TestChangeTitle()
		{
			Media m4 = new Media("First Title", 30, MediaType.Video);
			Assert.AreEqual("First Title", m4.Title);

			m4.Title = "New Title";
			Assert.AreNotEqual("First Title", m4.Title);
		}
	}
}
