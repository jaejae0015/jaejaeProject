using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace jaejaeBoard.Models
{
    public class JsonResults
    {
        public long ResultCode { get; set; }
        public string Message { get; set; }

        public string List { get; set; }
        public string Html { get; set; }
        public int currentPage { get; set; }
        public int totalRow { get; set; }
        public int pageSize { get; set; }
        public int pageCount { get; set; }

        public int uploaded { get; set; }
        public string fileName { get; set; }
        public string url { get; set; }
        public string width { get; set; }
        public string height { get; set; }
    }
}