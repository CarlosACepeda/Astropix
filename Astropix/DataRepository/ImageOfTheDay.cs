using Android.Graphics;
using System;
using System.Xml.Serialization;

namespace Astropix.DataRepository
{
    internal class ImageOfTheDay
    {
        /// <summary>
        /// A class used to build a 'Image of the day' that the Activity will use to show Information about this image and the image itself
        /// </summary>


        /// <summary>
        /// The date of the picture
        /// </summary>
        [XmlElement(ElementName = "date")]
        public DateTime Date { get; set; }

        /// <summary>
        /// The title of the picture
        /// </summary>
        [XmlElement(ElementName = "title")]
        public string Title { get; set; }

        /// <summary>
        /// Copyright of the picture, can be null.
        /// </summary>
        [XmlElement(ElementName = "copyright")]
        public string Copyright { get; set; }

        /// <summary>
        /// Description of the Image
        /// </summary>
        [XmlElement(ElementName = "explanation")]
        public string Explanation { get; set; }

        /// <summary>
        /// A picture url in standard quality 1024*768
        /// </summary>
        [XmlElement(ElementName = "url")]
        public string Url { get; set; }
        /// <summary>
        /// A picture url in 4k quality.
        /// </summary>
        [XmlElement(ElementName = "hdurl")]
        public string Hdurl { get; set; }

        [XmlElement(ElementName = "media_type")]
        public string Media_Type { get; set; }

        public ImageOfTheDay()
        {
        }

    }
}