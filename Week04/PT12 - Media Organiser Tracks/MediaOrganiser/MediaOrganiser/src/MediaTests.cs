// /**
//  * Student Number: 101533222
//  * Student Name: Lewis Brockman-Horsley
//  * Date: 29/09/2019
//  * Learning Outcomes: 
// **/
using System;
using MediaOrganiser.src;
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
        /// Tests creating media.
        /// </summary>
        [Test]
        public void TestMedia()
        {
            Media m1 = new Audio("artist", "album", 200);
            Assert.NotNull(m1, "An Audio Object is created");

            Media m2 = new Video();
            Assert.NotNull(m2, "A Video was created");

            Media m3 = new Image(100, 200);
            Assert.NotNull(m3, "An image was created");
        }

        /// <summary>
        /// Tests the audio object.
        /// Play method, Artist, Album, Duration properties.
        /// Tests the parent porperties.
        /// </summary>
        [Test]
        public void TestAudio()
        {
            Audio a1 = new Audio("art", "alb", 200);
            Assert.AreEqual(a1.Play(), a1.Artist + a1.Album + a1.Duration.ToString());

            Audio a2 = new Audio("artist", "album", 1)
            {
                Title = "song title",
                Size = 300
            };
            Assert.AreEqual("song title", a2.Title);
            Assert.AreEqual(300, a2.Size);
        }

        /// <summary>
        /// Tests the video.
        /// </summary>
        [Test]
        public void TestVideo()
        {
            Video v1 = new Video();
            Assert.NotNull(v1);

            Video v2 = new Video()
            {
                Title = "new video",
                Size = 3000
            };
            Assert.AreEqual("new video", v2.Title);
            Assert.AreEqual(3000, v2.Size);

            Video v3 = new Video();
            Assert.AreEqual("Video is unavailable", v3.Play());
            v3.Availability = true;
            Assert.AreEqual(true, v3.Availability);
            Assert.AreEqual("Video is now ready to play", v3.Play());
        }

        /// <summary>
        /// Tests the image.
        /// </summary>
        [Test]
        public void TestImage()
        {
            Image i1 = new Image(10, 20);
            Assert.NotNull(i1);

            Image i2 = new Image(2, 3);
            Assert.AreEqual(2, i2.PixelsInWidth, "pixels in width are equal");
            Assert.AreEqual(3, i2.PixelsInHeight, "pixels in height are equal");

            Image i3 = new Image(1, 1)
            {
                Title = "image",
                Size = 300
            };
            Assert.AreEqual("image", i3.Title);
            Assert.AreEqual(300, i3.Size);

            Image i4 = new Image(3, 4);
            Assert.AreEqual("12", i4.Play());
        }

        /// <summary>
        /// Tests changing the title.
        /// </summary>
        [Test]
        public void TestChangeTitle()
        {
            Image m4 = new Image(600, 800)
            {
                Title = "Small Image"
            };
            Assert.AreEqual("Small Image", m4.Title);

            m4.Title = "New Title";
            Assert.AreNotEqual("Small Image", m4.Title);
        }
    }
}
