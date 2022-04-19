using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml.Media.Imaging;

namespace Schedule_QR
{
    public class iCalendar : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        public string PRODID { get; set; }
        public string Version { get; set; }
        public string DTStart { get; set; }
        public string DTEnd { get; set; }



        private static readonly PropertyChangedEventArgs iCALPropertyChangedEventArgs = new PropertyChangedEventArgs(nameof(iCAL));
        private string ical;
        public string iCAL
        {
            get { return this.ical; }
            set
            {
                if (this.ical == value) { return; }
                this.ical = value;
                this.PropertyChanged?.Invoke(this, iCALPropertyChangedEventArgs);
            }
        }


        private static readonly PropertyChangedEventArgs SummaryPropertyChangedEventArgs = new PropertyChangedEventArgs(nameof(Summary));
        private string summary = string.Empty;
        public string Summary
        {
            get { return this.summary; }
            set
            {
                if (this.summary == value) { return; }
                this.summary = value;
                this.PropertyChanged?.Invoke(this, SummaryPropertyChangedEventArgs);
            }
        }

        private static readonly PropertyChangedEventArgs LocationPropertyChangedEventArgs = new PropertyChangedEventArgs(nameof(Location));
        private string location = string.Empty;
        public string Location
        {
            get { return this.location; }
            set
            {
                if (this.location == value) { return; }
                this.location = value;
                this.PropertyChanged?.Invoke(this, LocationPropertyChangedEventArgs);
            }
        }


        private static readonly PropertyChangedEventArgs DescriptionPropertyChangedEventArgs = new PropertyChangedEventArgs(nameof(Description));
        private string description = String.Empty;
        public string Description
        {
            get { return this.description; }
            set
            {
                if (this.description == value) { return; }
                this.description = value;
                this.PropertyChanged?.Invoke(this, DescriptionPropertyChangedEventArgs);
            }
        }

        private static readonly PropertyChangedEventArgs StartPropertyChangedEventArgs = new PropertyChangedEventArgs(nameof(Start));
        private DateTimeOffset start = new DateTimeOffset(DateTime.Now);
        public DateTimeOffset Start
        {
            get { return this.start; }
            set
            {
                if (this.start == value) { return; }
                this.start = value;
                this.PropertyChanged?.Invoke(this, StartPropertyChangedEventArgs);
            }
        }

        private static readonly PropertyChangedEventArgs StartTimePropertyChangedEventArgs = new PropertyChangedEventArgs(nameof(StartTime));
        private TimeSpan startTime = new TimeSpan();
        public TimeSpan StartTime
        {
            get { return this.startTime; }
            set
            {
                if (this.startTime == value) { return; }
                this.startTime = value;
                this.PropertyChanged?.Invoke(this, StartTimePropertyChangedEventArgs);
            }
        }


        private static readonly PropertyChangedEventArgs EndPropertyChangedEventArgs = new PropertyChangedEventArgs(nameof(End));
        private DateTimeOffset end = new DateTimeOffset(DateTime.Now);
        public DateTimeOffset End
        {
            get { return this.end; }
            set
            {
                if (this.end == value) { return; }
                this.end = value;
                this.PropertyChanged?.Invoke(this, EndPropertyChangedEventArgs);
            }
        }

        private static readonly PropertyChangedEventArgs EndTimePropertyChangedEventArgs = new PropertyChangedEventArgs(nameof(EndTime));
        private TimeSpan endTime = new TimeSpan();
        public TimeSpan EndTime
        {
            get { return this.endTime; }
            set
            {
                if (this.endTime == value) { return; }
                this.endTime = value;
                this.PropertyChanged?.Invoke(this, EndTimePropertyChangedEventArgs);
            }
        }

        public WriteableBitmap CreateCalendar()
        {
            iCAL = "BEGIN:VCALENDAR\r\n"
                    + "VERSION:2.0\r\n"
                    + "PRODID:-//ishigame-machine-technology.net/NONSGML v1.0//EN\r\n"
                    + "BEGIN:VEVENT\r\n"
                    + $"DESCRIPTION:{Description}\r\n"
                    + "DTSTART;TZID=Asia/Tokyo:" + Start.ToString("yyyyMMdd") + "T" + StartTime.ToString("hhmmss") + "Z\r\n"
                    + "DTEND;TZID=Asia/Tokyo:" + End.ToString("yyyyMMdd") + "T" + EndTime.ToString("hhmmss") + "Z\r\n"
                    + $"SUMMARY:{Summary}\r\n"
                    + $"LOCATION:{Location}\r\n"
                    + "END:VEVENT\r\n"
                    + "END:VCALENDAR";
            var barcodeWriter = new ZXing.BarcodeWriter();
            barcodeWriter.Format = ZXing.BarcodeFormat.QR_CODE;
            barcodeWriter.Options.Hints.Add(ZXing.EncodeHintType.CHARACTER_SET,"UTF-8");
            barcodeWriter.Options.Hints.Add(ZXing.EncodeHintType.ERROR_CORRECTION, ZXing.QrCode.Internal.ErrorCorrectionLevel.L);
            barcodeWriter.Options.Height = 200;
            barcodeWriter.Options.Width = 200;
            barcodeWriter.Options.Margin = 0;
            barcodeWriter.Options.PureBarcode = true;
            return barcodeWriter.Write(iCAL);
        }

    }

}
