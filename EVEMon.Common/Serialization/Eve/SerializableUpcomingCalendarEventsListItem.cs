using System;
using System.Xml.Serialization;
using EVEMon.Common.Extensions;

namespace EVEMon.Common.Serialization.Eve
{
    public sealed class SerializableUpcomingCalendarEventsListItem
    {
        [XmlAttribute("eventID")]
        public long EventID { get; set; }

        [XmlAttribute("ownerID")]
        public long OwnerID { get; set; }

        [XmlAttribute("ownerName")]
        public string OwnerNameXml
        {
            get { return OwnerName; }
            set { OwnerName = value == null ? String.Empty : value.HtmlDecode(); }
        }

        [XmlAttribute("eventTitle")]
        public string EventTitleXml
        {
            get { return EventTitle; }
            set { EventTitle = value == null ? String.Empty : value.HtmlDecode(); }
        }

        [XmlAttribute("eventText")]
        public string EventTextXml
        {
            get { return EventText; }
            set { EventText = value == null ? String.Empty : value.HtmlDecode(); }
        }

        [XmlAttribute("duration")]
        public int Duration { get; set; }

        [XmlAttribute("importance")]
        public bool Importance { get; set; }

        [XmlAttribute("response")]
        public string ResponseXml
        {
            get { return Response; }
            set { Response = value == null ? String.Empty : value.HtmlDecode(); }
        }

        [XmlAttribute("eventDate")]
        public string EventDateXml
        {
            get { return EventDate.DateTimeToTimeString(); }
            set
            {
                if (!String.IsNullOrEmpty(value))
                    EventDate = value.TimeStringToDateTime();
            }
        }

        [XmlIgnore]
        public string OwnerName { get; set; }

        [XmlIgnore]
        public string EventTitle { get; set; }

        [XmlIgnore]
        public string EventText { get; set; }

        [XmlIgnore]
        public string Response { get; set; }

        [XmlIgnore]
        public DateTime EventDate { get; set; }
    }
}