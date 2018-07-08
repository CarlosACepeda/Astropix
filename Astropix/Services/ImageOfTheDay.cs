using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.Graphics;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Newtonsoft.Json;
using System.Xml;
using System.Xml.Serialization;

namespace Astropix.Services
{
    /// <summary>
    /// A class used to build a 'Image of the day' that the Activity will use to show Information about this image and the image itself
    /// </summary>
    class ImageOfTheDay
    {
        private static ImageOfTheDay instance;

        public Bitmap Image { get; internal set; }

        /// <summary>
        /// The date of the picture
        /// </summary>
        [XmlElement(ElementName ="date")]
        public DateTime Date { get; set; }
        /// <summary>
        /// The title of the picture
        /// </summary>
        [XmlElement(ElementName ="title")]
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
        [XmlElement(ElementName ="url")]
        public string Url { get; set; }
        /// <summary>
        /// A picture url in 4k quality.
        /// </summary>
        [XmlElement(ElementName ="hdurl")]
        public string Hdurl { get; set; }



        private ImageOfTheDay()
        {

        }
        //Singleton, is only allowed to be a single Image of the day;
        public static ImageOfTheDay ImageOfTheDayInstance()
        {
            if (instance == null)
            {
                instance = new ImageOfTheDay();
            }
            return instance;
        }

    }
}