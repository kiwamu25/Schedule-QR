using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Schedule_QR
{
    public class iCalendar : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        public string PRODID { get; set; }
        public string Version { get; set; }
        public string DTStart { get; set; }
        public string DTEnd { get; set; }

        private static readonly PropertyChangedEventArgs SummaryPropertyChangedEventArgs = new PropertyChangedEventArgs(nameof(Summary));
        private string summary;
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

        private static readonly PropertyChangedEventArgs DescriptionPropertyChangedEventArgs = new PropertyChangedEventArgs(nameof(Description));
        private string description;
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


    }

}
