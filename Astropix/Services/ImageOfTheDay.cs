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

        ///// <summary>
        ///// A picture in standard quality 1024*768
        ///// </summary>
        //public string Image { get; set; }
        ///// <summary>
        ///// A picture in 4k quality.
        ///// </summary>
        //public string ImageHd { get; set; }

    }
}