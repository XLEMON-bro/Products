using System;
using System.Collections.Generic;
using System.Text;

namespace ProductServices.DataModels
{
    public class ViewModel
    {
        public string Id { get; set; }
        public string ProductId { get; set; }
        public int TotalViews { get; set; }
        public int TodayViews { get; set; }
    }
}
